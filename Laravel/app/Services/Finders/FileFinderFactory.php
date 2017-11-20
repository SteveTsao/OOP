<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/12
 * Time: 下午 08:36
 */

namespace App\Services\Finders;


use App\Services\Configs\Config;

/**
 * 備份來源工廠模式
 * Class FileFinderFactory
 * @author steve.tsao
 * @package App\Services\Finders
 */
class FileFinderFactory
{
    const InstanceNamespace = __NAMESPACE__ . '\\'; // 備份來源類別命名空間

    /**
     * 建立備份來源類別物件
     * @author steve.tsao
     * @param string $finder 備份來源
     * @param Config $config 檔案處理設定
     * @return IFileFinder 處理備份來源類別物件
     */
    public static function Create(string $finder, Config $config): IFileFinder
    {
        // 讀取備份來源類別設定檔
        $finders = json_decode(file_get_contents('finder_mapping.json'), JSON_OBJECT_AS_ARRAY);

        // 備份來源類別
        $instance = self::InstanceNamespace . $finders[$finder];

        // 建立備份來源類別
        return new $instance($config);
    }
}
