<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/12
 * Time: 下午 07:35
 */

namespace App\Services\Finders;


use App\Services\Configs\Config;

/**
 * 備份來源介面
 * Interface IFileFinder
 * @author steve.tsao
 * @package App\Services\Finders
 */
interface IFileFinder
{
    /**
     * 來源讀取
     * @author steve.tsao
     * @param Config $config 檔案設定
     */
    function FileFinder(Config $config);
}
