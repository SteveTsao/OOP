<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/10/22
 * Time: 下午 05:20
 */

namespace App\Services\Configs;


/**
 * 封裝Config物件類別
 * Class ConfigManager
 * @author steve.tsao
 * @package App\Services\Configs
 */
class ConfigManager extends JsonManager
{
    /**
     * 解析JSON檔案轉成Config物件陣列
     * @author steve.tsao
     * @param string $path 檔案位置
     * @return array 物件陣列
     */
    public function ProcessJsonConfig(string $path = 'configs.json')
    {
        $this->configs = $this->GetJsonObject($path, 'configs', function ($item) {
            return new Config(
                $item['ext'],
                $item['location'],
                $item['subDirectory'],
                $item['unit'],
                $item['remove'],
                $item['handlers'],
                $item['destination'],
                $item['dir'],
                $item['connectionString']
            );
        });
    }
}
