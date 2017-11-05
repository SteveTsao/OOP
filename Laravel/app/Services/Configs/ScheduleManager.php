<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/10/22
 * Time: 下午 05:43
 */

namespace App\Services\Configs;


/**
 * 封裝Schedule物件類別
 * Class ScheduleManager
 * @author steve.tsao
 * @package App\Services\Configs
 */
class ScheduleManager extends JsonManager
{
    /**
     * @var array 陣列儲存多筆Schedule物件
     */
    private $schedules = [];

    /**
     * 解析JSON檔案轉成Schedule物件陣列
     * @author steve.tsao
     * @param string $path 檔案位置
     * @return array
     */
    public function ProcessJsonConfig(string $path = 'schedules.json'): array
    {
        $this->schedules = $this->GetJsonObject($path, 'schedules', function ($item) {
            return new Schedule(
                $item['ext'],
                $item['time'],
                $item['interval']
            );
        });

        return $this->schedules;
    }
}
