<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/5
 * Time: 下午 11:12
 */

namespace App\Services\Handlers;


/**
 * 備份檔案處理工廠模式
 * Class HandlerFactory
 * @author steve.tsao
 * @package App\Services\Handlers
 */
class HandlerFactory
{
    const InstanceNamespace = '\\App\\Services\\Handlers\\'; //檔案處理方式類別命名空間

    /**
     * 建立處理方式類別物件
     * @author steve.tsao
     * @param string $handler 處理方式
     * @return IHandler 處理方式類別物件
     */
    public static function Create(string $handler)
    {
        // 讀取處理方式類別設定檔
        $handlers = json_decode(file_get_contents('handler_mapping.json'), JSON_OBJECT_AS_ARRAY);

        // 取得對應處理方式
        $instance = self::InstanceNamespace . $handlers[$handler];

        // 建立處理方式類別
        return new $instance();
    }
}
