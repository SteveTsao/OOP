<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/20
 * Time: 下午 08:50
 */

namespace App\Services\Tasks;


use App\Services\Configs\Candidate;
use App\Services\Configs\Config;
use App\Services\Finders\FileFinderFactory;
use App\Services\Handlers\HandlerFactory;
use App\Services\Handlers\IHandler;

/**
 * 執行備份抽象類別
 * Class AbstractTask
 * @author steve.tsao
 * @package App\Services\Tasks
 */
abstract class AbstractTask implements ITask
{
    /**
     * @var \App\Services\Finders\IFileFinder $fileFinder
     */
    private $fileFinder;

    /**
     * 是否處理檔案
     * @author steve.tsao
     * @param Config $config 檔案設定
     * @return bool 是否處理檔案
     */
    protected function IsTask(Config $config): bool
    {
        return true;
    }

    /**
     * 執行備份
     * @author steve.tsao
     * @param array $configs 檔案處理設定
     * @param array $schedules 自動排程時間
     */
    public function Execute(array $configs, array $schedules)
    {
        collect($configs)->each(function (Config $item) {

            if (!$this->IsTask($item)) {
                return true;
            }

            $this->fileFinder = FileFinderFactory::Create('file', $item);

            collect($this->fileFinder)->each(function (Candidate $candidate) {
                $this->BroadcastToHandlers($candidate);
            });
        });
    }

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
         * @var Config $config
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
