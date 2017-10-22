<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/10/22
 * Time: 下午 05:37
 */

namespace App\Services;


class Schedule
{
    private $ext = '';
    private $time = '';
    private $interval = '';

    /**
     * Schedule constructor.
     * @param string $ext
     * @param string $time
     * @param string $interval
     */
    public function __construct(string $ext, string $time, string $interval)
    {
        $this->ext = $ext;
        $this->time = $time;
        $this->interval = $interval;
    }
}