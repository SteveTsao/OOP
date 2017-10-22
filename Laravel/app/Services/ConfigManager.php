<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/10/22
 * Time: 下午 05:20
 */

namespace App\Services;


/**
 * Class ConfigManager
 * @author steve.tsao
 * @package App\Services
 */
class ConfigManager
{
    private $configs = [];

    /**
     * @author steve.tsao
     * @param string $path
     * @return array
     */
    public function ProcessConfigs(string $path = 'configs.json'): array
    {
        $data = json_decode(file_get_contents($path), JSON_OBJECT_AS_ARRAY);

        if (!is_array($data) || empty($data['configs']) || !is_array($data['configs'])) {
            return [];
        }

        $this->configs = collect($data['configs'])->map(function ($item) {
            return new Config(
                $item['ext'],
                $item['location'],
                $item['subDirectory'],
                $item['unit'],
                $item['remove'],
                $item['handler'],
                $item['destination'],
                $item['dir'],
                $item['connectionString']
            );
        })->toArray();

        return $this->configs;
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
            return count($this->configs);
        }
    }
}
