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
     * 解析JSON檔案轉成Schedule物件陣列
     * @author steve.tsao
     * @param string $path 檔案位置
     * @return array 物件陣列
     */
    public function ProcessJsonConfig(string $path = 'schedules.json')
    {
        $this->configs = $this->GetJsonObject($path, 'schedules', function ($item) {
            return new Schedule(
                $item['ext'],
                $item['time'],
                $item['interval']
            );
        });
    }
}
