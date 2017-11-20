<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/20
 * Time: 下午 09:37
 */

namespace App\Services\Tasks;


/**
 * 執行備份工廠模式
 * Class TaskFactory
 * @author steve.tsao
 * @package App\Services\Tasks
 */
class TaskFactory
{
    const InstanceNamespace = __NAMESPACE__ . '\\'; // 執行備份類別命名空間

    /**
     * 執行備份類別物件
     * @author steve.tsao
     * @param string $task 執行備份類別
     * @return ITask 備份類別物件
     */
    public static function Create(string $task): ITask
    {
        // 讀取執行備份類別設定檔
        $tasks = json_decode(file_get_contents('task_mapping.json'), JSON_OBJECT_AS_ARRAY);

        // 執行備份類別
        $instance = self::InstanceNamespace . $tasks[$task];

        // 建立執行備份類別
        return new $instance();
    }
}
