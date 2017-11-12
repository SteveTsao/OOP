<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/12
 * Time: 下午 08:36
 */

namespace App\Services\Finders;


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
     * @param string $handler 備份來源
     * @return IFileFinder 處理備份來源類別物件
     */
    public static function Create(string $handler)
    {
        // 讀取備份來源類別設定檔
        $handlers = json_decode(file_get_contents('finder_mapping.json'), JSON_OBJECT_AS_ARRAY);

        // 備份來源類別
        $instance = self::InstanceNamespace . $handlers[$handler];

        // 建立備份來源類別
        return new $instance();
    }
}
