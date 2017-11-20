<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/20
 * Time: 下午 09:15
 */

namespace App\Services\Tasks;


use App\Services\Configs\Config;
use App\Services\Configs\Schedule;

/**
 * 排程備份
 * Class ScheduleTask
 * @author steve.tsao
 * @package App\Services\Tasks
 */
class ScheduledTask extends AbstractTask
{
    /**
     * @var string 處理時間
     */
    private $taskTime = '';

    /**
     * @var array 處理排程
     */
    private $taskSchedules = [];

    /**
     * 是否處理檔案
     * @author steve.tsao
     * @param Config $config 檔案設定
     * @return bool 是否處理檔案
     */
    protected function IsTask(Config $config): bool
    {
        return collect($this->taskSchedules)->filter(function (Schedule $item) use ($config) {
                return ($item->Ext === $config->Ext && $item->Time === $this->taskTime);
            })->count() > 0;
    }

    /**
     * 執行備份
     * @author steve.tsao
     * @param array $configs 檔案處理設定
     * @param array $schedules 自動排程時間
     */
    public function Execute(array $configs, array $schedules)
    {
        $this->taskSchedules = $schedules;

        while (true) {

            $this->taskTime = date('h:i');

            parent::Execute($configs, $schedules);

            sleep(1);
        }
    }
}
