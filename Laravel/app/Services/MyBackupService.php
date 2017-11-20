<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/10/24
 * Time: 下午 07:27
 */

namespace App\Services;


use App\Services\Configs\ConfigManager;
use App\Services\Configs\JsonManager;
use App\Services\Configs\ScheduleManager;
use App\Services\Tasks\TaskDispatcher;

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
     * @var TaskDispatcher $taskDispatcher
     */
    private $taskDispatcher;

    /**
     * 建構子
     * MyBackupService constructor.
     * @author steve.tsao
     */
    public function __construct()
    {
        $this->managers = [
            new ConfigManager(),
            new ScheduleManager(),
        ];

        $this->taskDispatcher = new TaskDispatcher();

        $this->Init();
    }

    /**
     * 物件初始化
     * @author steve.tsao
     */
    private function Init()
    {
        $this->ProcessJsonConfigs();
    }

    /**
     * 處理JSON檔案執行設定
     * @author steve.tsao
     */
    private function ProcessJsonConfigs()
    {
        // 呼叫JsonManager子類別實作的ProcessJsonConfig函數
        collect($this->managers)->each(function (JsonManager $item) {
            $item->ProcessJsonConfig();
        });
    }

    /**
     * 簡單備份
     * @author steve.tsao
     */
    public function SimpleTask()
    {
        $this->taskDispatcher->SimpleTask($this->managers);
    }

    /**
     * 排程備份
     * @author steve.tsao
     */
    public function ScheduleTask()
    {
        $this->taskDispatcher->ScheduleTask($this->managers);
    }
}
