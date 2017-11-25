<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/5
 * Time: 下午 11:10
 */

namespace App\Services\Handlers;


use App\Services\Configs\Candidate;

/**
 * 備份處理介面
 * Interface IHandler
 * @author steve.tsao
 * @package App\Services\Handlers
 */
interface IHandler
{
    /**
     * 處理方式
     * @author steve.tsao
     * @param Candidate $candidate 檔案資訊
     * @param string|null $target 檔案內容
     * @return string 檔案內容
     */
    public function PerForm(Candidate $candidate, $target): string;
}
