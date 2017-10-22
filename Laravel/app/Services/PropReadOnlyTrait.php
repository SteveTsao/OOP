<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/10/22
 * Time: 下午 05:17
 */

namespace App\Services;


/**
 * Trait PropReadOnlyTrait
 * @author steve.tsao
 * @package App\Services
 */
trait PropReadOnlyTrait
{
    /**
     * @author steve.tsao
     * @param string $name
     * @return mixed
     */
    public function __get(string $name)
    {
        // TODO: Implement __get() method.

        // 類別屬性字首小寫
        $key = lcfirst($name);

        // 類別屬性是否存在
        if ($key !== $name && property_exists($this, $key)) {
            return $this->$key;
        }
    }
}