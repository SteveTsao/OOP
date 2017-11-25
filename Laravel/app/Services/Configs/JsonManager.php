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
abstract class JsonManager implements \ArrayAccess, \Iterator
{
    use PropReadOnlyTrait; // 設定類別唯讀屬性: this->Count

    /**
     * @var array 多筆Config或Schedule物件陣列
     */
    protected $configs = [];

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
     * @return array 物件陣列
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

    /**
     * ArrayAccess 實作物件陣列是否存在
     * @author steve.tsao
     * @param mixed $offset 陣列索引
     * @return bool 是否存在
     */
    public function offsetExists($offset)
    {
        // TODO: Implement offsetExists() method.

        return isset($this->configs[$offset]);
    }

    /**
     * ArrayAccess 實作取得物件陣列內容
     * @author steve.tsao
     * @param mixed $offset 陣列索引
     * @return Config|null 返回內容
     */
    public function offsetGet($offset)
    {
        // TODO: Implement offsetGet() method.

        return $this->configs[$offset] ?? null;
    }

    /**
     * ArrayAccess 實作設定物件陣列內容
     * @author steve.tsao
     * @param mixed $offset 陣列索引
     * @param mixed $value 設定內容
     */
    public function offsetSet($offset, $value)
    {
        // TODO: Implement offsetSet() method.

        if (is_null($offset)) {
            $this->configs[] = $value;
        } else {
            $this->configs[$offset] = $value;
        }
    }

    /**
     * ArrayAccess 實作物件移除陣列內容
     * @author steve.tsao
     * @param mixed $offset 陣列索引
     */
    public function offsetUnset($offset)
    {
        // TODO: Implement offsetUnset() method.

        unset($this->configs[$offset]);
    }

    /**
     * Iterator 實作迭代器返回元素
     * @author steve.tsao
     * @return Candidate 返回元素(備份檔案資訊物件)
     */
    public function current()
    {
        // TODO: Implement current() method.

        return current($this->configs);
    }

    /**
     * Iterator 實作迭代器返回元素的索引
     * @author steve.tsao
     * @return int|null|string 元素索引
     */
    public function key()
    {
        // TODO: Implement key() method.

        return key($this->configs);
    }

    /**
     * Iterator 實作迭代器移動到下一個元素
     * @author steve.tsao
     */
    public function next()
    {
        // TODO: Implement next() method.

        next($this->configs);
    }

    /**
     * Iterator 實作迭代器回到第一個元素
     * @author steve.tsao
     */
    public function rewind()
    {
        // TODO: Implement rewind() method.

        reset($this->configs);
    }

    /**
     * Iterator 實作迭代器檢查當前元素是否存在
     * @author steve.tsao
     * @return bool 是否存在
     */
    public function valid()
    {
        // TODO: Implement valid() method.

        $key = key($this->configs);

        return ($key !== NULL && $key !== FALSE);
    }
}
