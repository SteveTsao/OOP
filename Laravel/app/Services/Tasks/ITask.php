<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/20
 * Time: 下午 08:48
 */

namespace App\Services\Tasks;


/**
 * 執行備份介面
 * Interface ITask
 * @author steve.tsao
 * @package App\Services\Tasks
 */
interface ITask
{
    /**
     * 執行備份
     * @author steve.tsao
     * @param array $configs 檔案處理設定
     * @param array $schedules 自動排程時間
     */
    public function Execute(array $configs, array $schedules);
}
