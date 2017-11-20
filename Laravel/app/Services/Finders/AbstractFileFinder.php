<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/12
 * Time: 下午 07:39
 */

namespace App\Services\Finders;


use App\Services\Configs\Candidate;
use App\Services\Configs\Config;

/**
 * 備份來源抽象類別
 * Class AbstractFileFinder
 * @author steve.tsao
 * @package App\Services\Finders
 */
abstract class AbstractFileFinder implements IFileFinder, \ArrayAccess, \Iterator
{
    /**
     * 檔案設定
     */
    protected $config;

    /**
     * 備份來源
     * @var array
     */
    protected $files = [];

    /**
     * 建立備份來源檔案抽象函數
     * @param string $fileName 檔案位置
     * @return Candidate 備份檔案資訊
     */
    abstract protected function CreateCandidate(string $fileName): Candidate;

    /**
     * 建構子
     * AbstractFileFinder constructor.
     * @author steve.tsao
     * @param Config $config 檔案設定
     */
    public function __construct(Config $config)
    {
        $this->config = $config;

        $this->FileFinder($config);
    }

    /**
     * ArrayAccess 實作物件陣列是否存在
     * @author steve.tsao
     * @param mixed $offset
     * @return bool
     */
    public function offsetExists($offset)
    {
        // TODO: Implement offsetExists() method.

        return isset($this->files[$offset]);
    }

    /**
     * ArrayAccess 實作取得物件陣列內容
     * @author steve.tsao
     * @param mixed $offset 陣列鍵值
     * @return Candidate|null 返回內容
     */
    public function offsetGet($offset)
    {
        // TODO: Implement offsetGet() method.

        return isset($this->files[$offset]) ? $this->CreateCandidate($this->files[$offset]) : null;
    }

    /**
     * ArrayAccess 實作設定物件陣列內容
     * @author steve.tsao
     * @param mixed $offset 陣列鍵值
     * @param mixed $value 設定內容
     */
    public function offsetSet($offset, $value)
    {
        // TODO: Implement offsetSet() method.

        if (is_null($offset)) {
            $this->files[] = $value;
        } else {
            $this->files[$offset] = $value;
        }
    }

    /**
     * ArrayAccess 實作物件移除陣列內容
     * @author steve.tsao
     * @param mixed $offset 陣列鍵值
     */
    public function offsetUnset($offset)
    {
        // TODO: Implement offsetUnset() method.

        unset($this->files[$offset]);
    }

    /**
     * Iterator 實作迭代器返回元素
     * @author steve.tsao
     * @return Candidate 返回元素(備份檔案資訊物件)
     */
    public function current()
    {
        // TODO: Implement current() method.

        return $this->CreateCandidate(current($this->files));
    }

    /**
     * Iterator 實作迭代器返回元素的鍵值
     * @author steve.tsao
     * @return int|null|string 元素鍵值
     */
    public function key()
    {
        // TODO: Implement key() method.

        return key($this->files);
    }

    /**
     * Iterator 實作迭代器移動到下一個元素
     * @author steve.tsao
     */
    public function next()
    {
        // TODO: Implement next() method.

        next($this->files);
    }

    /**
     * Iterator 實作迭代器回到第一個元素
     * @author steve.tsao
     */
    public function rewind()
    {
        // TODO: Implement rewind() method.

        reset($this->files);
    }

    /**
     * Iterator 實作迭代器檢查當前元素是否存在
     * @author steve.tsao
     * @return bool 是否存在
     */
    public function valid()
    {
        // TODO: Implement valid() method.

        $key = key($this->files);

        return ($key !== NULL && $key !== FALSE);
    }
}
