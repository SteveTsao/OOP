<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/20
 * Time: 下午 09:36
 */

namespace App\Services\Tasks;


use App\Services\Configs\ConfigManager;
use App\Services\Configs\JsonManager;
use App\Services\Configs\ScheduleManager;

class TaskDispatcher
{
    /**
     * @var ITask $task 執行備份物件
     */
    private $task;

    /**
     * 取得指定類別物件陣列
     * @author steve.tsao
     * @param array $managers 抽象類別
     * @param string $instance 物件名稱
     * @return array 類別物件陣列
     */
    private function GetManagerItems(array $managers, string $instance): array
    {
        return collect($managers)->map(function (JsonManager $manager) use ($instance) {

            if (!$manager instanceof $instance) {
                return [];
            }

            return collect($manager)->map(function ($item) {
                return $item;
            })->toArray();

        })->collapse()->toArray();
    }

    /**
     * 排程備份
     * @author steve.tsao
     * @param array $managers 抽象類別
     */
    public function SimpleTask(array $managers)
    {
        $this->task = TaskFactory::Create('simple');
        $this->task->Execute($this->GetManagerItems($managers, ConfigManager::class), []);
    }

    /**
     * @author steve.tsao
     * @param array $managers 抽象類別
     */
    public function ScheduleTask(array $managers)
    {
        $this->task = TaskFactory::Create('schedule');
        $this->task->Execute($this->GetManagerItems($managers, ConfigManager::class), $this->GetManagerItems($managers, ScheduleManager::class));
    }
}