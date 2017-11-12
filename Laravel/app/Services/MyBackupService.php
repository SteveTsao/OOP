<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/10/24
 * Time: 下午 07:27
 */

namespace App\Services;


use App\Services\Configs\Candidate;
use App\Services\Configs\Config;
use App\Services\Configs\ConfigManager;
use App\Services\Configs\JsonManager;
use App\Services\Configs\ScheduleManager;
use App\Services\Finders\FileFinderFactory;
use App\Services\Handlers\HandlerFactory;
use App\Services\Handlers\IHandler;

/**
 * 備份執行類別
 * Class MyBackupService
 * @author steve.tsao
 * @package App\Services
 */
class MyBackupService
{
    /**
     * @var array 存放JsonManager物件陣列
     */
    private $managers = [];

    /**
     * @var array 存放JsonManager的ProcessJsonConfig結果
     */
    private $configs = [];

    /**
     * 建構子 依賴注入
     * MyBackupService constructor.
     * @author steve.tsao
     * @param ConfigManager $configManager
     * @param ScheduleManager $scheduleManager
     */
    public function __construct(ConfigManager $configManager, ScheduleManager $scheduleManager)
    {
        // DI 依賴注入 JsonManager 物件到陣列
        // Laravel 自動注入機制，使用 func_get_args 寫法來讀取建構子的注入物件
        // 若要爌充類別，只須在 __construct( ..., PlatformManager $platformManager) 增加傳入型別參數即可輕易達成
        $this->managers = collect(func_get_args())->reject(function ($item) {
            // 排除非繼承 JsonManager 的物件
            return !$item instanceof JsonManager;
        })->all();
    }

    /**
     * 處理JSON檔案執行設定
     * @author steve.tsao
     */
    public function ProcessJsonConfigs(): array
    {
        // 呼叫JsonManager子類別實作的ProcessJsonConfig函數
        return collect($this->managers)->map(function ($item, $key) {
            /**
             * @var JsonManager $item
             */
            $configs = $item->ProcessJsonConfig();

            $this->configs[$key] = $configs;

            return $configs;

        })->all();
    }

    /**
     * 所有檔案進行備份
     * @author steve.tsao
     */
    public function DoBackup()
    {
        collect($this->managers)->each(function ($item, $key) {

            // 找到 ConfigManager 型別物件
            if ($item instanceof ConfigManager && !empty($this->configs[$key]) && is_array($this->configs[$key])) {

                // 建立 FileFinder 物件
                $fileFinder = FileFinderFactory::Create('file');

                collect($this->configs[$key])->each(function ($config) use ($fileFinder) {

                    // 取得所有備份檔案
                    $fileFinder->FileFinder($config);

                    collect($fileFinder)->each(function ($candidate) {

                        // 執行檔案備份
                        $this->BroadcastToHandlers($candidate);
                    });
                });
            }
        });

        exit;
    }

    /**
     * 取得所有備份檔案
     * @author steve.tsao
     * @return array
     */
    /*
    private function FindFiles(): array
    {
        return collect($this->managers)->map(function ($item, $key) {

            // 找到 ConfigManager 型別物件
            if (!$item instanceof ConfigManager || empty($this->configs[$key]) || !is_array($this->configs[$key])) {
                return [];
            }

            return collect($this->configs[$key])->map(function ($obj) {

                // 取得目錄下所有檔案並過濾類型
                return collect(glob($obj->Location . '\\*.' . $obj->Ext))->map(function ($path) use ($obj) {

                    $info = pathinfo($path);

                    // 加入備份檔案
                    return new Candidate($obj, date('Y/m/d H:i:s', fileatime($path)), $info['basename'], $info['basename'], filesize($path));

                });

            });

        })->flatten()->all();
    }
    */

    /**
     * 執行檔案備份
     * @author steve.tsao
     * @param Candidate $candidate 擋案資訊內容
     */
    private function BroadcastToHandlers(Candidate $candidate)
    {
        $target = null;

        collect($this->FindHandlers($candidate))->each(function (IHandler $handler) use ($candidate, &$target) {
            $target = $handler->PerForm($candidate, $target);
        });
    }

    /**
     * 根據檔案類型，建立處理方式
     * @author steve.tsao
     * @param Candidate $candidate 檔案資訊
     * @return array 檔案將進行的處理方式
     */
    private function FindHandlers(Candidate $candidate): array
    {
        /**
         * @var Config
         */
        $config = $candidate->Config;

        // 讀取檔案 + 檔案處理
        $arr = array_merge(['file'], $config->Handlers);

        // 目錄備份
        if (!empty($config->Destination)) {
            $arr[] = 'directory';
        }

        return collect($arr)->map(function (string $item) {
            // 建立處理方式類別
            return HandlerFactory::Create($item);
        })->all();
    }
}
