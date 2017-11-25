<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/25
 * Time: 下午 10:57
 */

namespace App\Services\Handlers\DBHandlers;


use App\Services\Configs\Candidate;
use DB;

class AbstractDBHandler implements IDBHandler
{
    /**
     * 檔名轉成UTF-8
     * @author steve.tsao
     * @param string $str
     * @return string
     */
    protected function ConvertFileName(string $str): string
    {
        return mb_convert_encoding($str, 'UTF-8', 'Big5');
    }

    /**
     * 備份到資料庫
     * @author steve.tsao
     * @param Candidate $candidate 檔案資訊
     * @param null|string $target 檔案內容
     * @return string 檔案內容
     */
    public function Perform(Candidate $candidate, $target): string
    {
        return (string)$target;
    }

    /**
     * 資料庫連線開啟
     * @author steve.tsao
     */
    public function OpenConnection()
    {
        // TODO: Implement OpenConnection() method.

        DB::connection();
    }

    /**
     * 資料庫連線關閉
     * @author steve.tsao
     */
    public function CloseConnection()
    {
        // TODO: Implement CloseConnection() method.

        DB::disconnect();
    }
}