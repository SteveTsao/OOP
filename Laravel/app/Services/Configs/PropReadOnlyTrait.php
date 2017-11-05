<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/10/22
 * Time: 下午 05:17
 */

namespace App\Services\Configs;


/**
 * 類別唯讀屬性實作
 * Trait PropReadOnlyTrait
 * @author steve.tsao
 * @package App\Services\Configs
 */
trait PropReadOnlyTrait
{
    /**
     * 取得類別屬性內容
     * @author steve.tsao
     * @param string $name
     * @return mixed
     */
    public function __get(string $name)
    {
        // TODO: Implement __get() method.

        // 類別屬性字首小寫
        $key = lcfirst($name);

        // 類別屬性不存在
        if ($key === $name || !property_exists($this, $key)) {
            return null;
        }

        return $this->$key;
    }

    /**
     * 類別屬性是否存在
     * @author steve.tsao
     * @param string $name
     * @return bool
     */
    public function __isset(string $name): bool
    {
        // TODO: Implement __isset() method.

        // 類別屬性字首小寫
        $key = lcfirst($name);

        return ($key !== $name && property_exists($this, $key));
    }
}
