<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/10/22
 * Time: 下午 05:37
 */

namespace App\Services;


/**
 * 自動排程時間類別
 * Class Schedule
 * @author steve.tsao
 * @package App\Services
 */
class Schedule
{
    use PropReadOnlyTrait; // 設定類別唯讀屬性

    private $ext = '';
    private $time = '';
    private $interval = '';

    /**
     * Schedule constructor.
     * @param string $ext 處理檔案格式
     * @param string $time 排程時間
     * @param string $interval 排程間隔
     */
    public function __construct(string $ext, string $time, string $interval)
    {
        $this->ext = $ext;
        $this->time = $time;
        $this->interval = $interval;
    }
}
