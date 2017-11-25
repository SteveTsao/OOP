<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/25
 * Time: 下午 10:49
 */

namespace App\Services\Handlers\DBHandlers;


use App\Services\Configs\Candidate;

/**
 * 資料庫介面
 * Interface IDBHandler
 * @author steve.tsao
 * @package App\Services\Handlers\DBHandlers
 */
interface IDBHandler
{
    /**
     * 開啟資料庫連線
     * @author steve.tsao
     */
    function OpenConnection();

    /**
     * 關閉資料庫連線
     * @author steve.tsao
     */
    function CloseConnection();

    /**
     * 備份到資料庫處理
     * @author steve.tsao
     * @param Candidate $candidate 檔案資訊
     * @param string|null $target 檔案內容
     * @return string 檔案內容
     */
    function Perform(Candidate $candidate, $target): string;
}
