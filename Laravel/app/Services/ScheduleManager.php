<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/10/22
 * Time: 下午 05:43
 */

namespace App\Services;


class ScheduleManager
{
    private $shedules = [];

    /**
     * @author steve.tsao
     * @param string $path
     * @return array
     */
    public function ProcessSchedules(string $path = 'schedules.json'): array
    {
        $data = json_decode(file_get_contents($path), JSON_OBJECT_AS_ARRAY);

        if (!is_array($data) || empty($data['schedules']) || !is_array($data['schedules'])) {
            return [];
        }

        $this->shedules = collect($data['schedules'])->map(function ($item) {
            return new Schedule(
                $item['ext'],
                $item['time'],
                $item['interval']
            );
        })->toArray();

        return $this->shedules;
    }

    /**
     * @author steve.tsao
     * @param string $name
     * @return int
     */
    public function __get(string $name)
    {
        // TODO: Implement __get() method.

        if ($name === 'Count') {
            return count($this->shedules);
        }
    }
}