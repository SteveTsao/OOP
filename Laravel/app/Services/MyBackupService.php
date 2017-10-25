<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/10/24
 * Time: 下午 07:27
 */

namespace App\Services;


/**
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
     * 解析JSON檔案
     * @author steve.tsao
     */
    public function ProcessJsonConfigs(): array
    {
        // 呼叫JsonManager子類別實作的ProcessJsonConfig函數
        return collect($this->managers)->map(function ($item) {
            /**
             * @var JsonManager $item
             */
            return $item->ProcessJsonConfig();
        })->all();
    }
}
