<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/10/24
 * Time: 下午 07:06
 */

namespace App\Services\Configs;


/**
 * 物件Manager抽象類別
 * Class JsonManager
 * @author steve.tsao
 * @package App\Services\Configs
 */
abstract class JsonManager
{
    use PropReadOnlyTrait; // 設定類別唯讀屬性: this->Count

    /**
     * 實作解析JSON轉換物件
     */
    abstract public function ProcessJsonConfig();

    /**
     * @var int 陣列的物件總數
     */
    private $count = 0;

    /**
     * 解析Json檔案回傳Manager物件陣列
     * @param string $path 檔案位置
     * @param string $key 物件陣列在JSON的起始節點
     * @param \Closure $map 回傳物件處理函數
     * @return array
     */
    protected function GetJsonObject(string $path, string $key, \Closure $map): array
    {
        $data = json_decode(file_get_contents($path), JSON_OBJECT_AS_ARRAY);

        if (!is_array($data) || empty($data[$key]) || !is_array($data[$key])) {
            return [];
        }

        $item = collect($data[$key])->map($map);

        $this->count = $item->count();

        return $item->all();
    }
}