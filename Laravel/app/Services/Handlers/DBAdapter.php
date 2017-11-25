<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/25
 * Time: 下午 10:42
 */

namespace App\Services\Handlers;


use App\Services\Configs\Candidate;
use App\Services\Handlers\DBHandlers\DBBackupHandler;
use App\Services\Handlers\DBHandlers\DBLogHandler;

/**
 * 資料庫轉換類別
 * Class DBAdapter
 * @author steve.tsao
 * @package App\Services\Handlers
 */
class DBAdapter extends AbstractHandler
{
    /**
     * @var DBBackupHandler 備份檔案
     */
    private $backHandler;

    /**
     * @var DBLogHandler 備份記錄檔
     */
    private $logHandler;

    /**
     * 建構子
     * DBAdapter constructor.
     * @author steve.tsao
     */
    public function __construct()
    {
        $this->backHandler = new DBBackupHandler();
        $this->logHandler = new DBLogHandler();
    }

    /**
     * 資料庫備份處理
     * @author steve.tsao
     * @param Candidate $candidate 檔案資訊
     * @param null|string $target 檔案內容
     * @return string 檔案內容
     */
    public function PerForm(Candidate $candidate, $target): string
    {
        $this->SaveBackupToDB($candidate, $target);
        $this->SaveLogToDB($candidate, $target);

        return (string)$target;
    }

    /**
     * 備份檔案
     * @author steve.tsao
     * @param Candidate $candidate 檔案資訊
     * @param string $target 檔案內容
     */
    private function SaveBackupToDB(Candidate $candidate, string $target)
    {
        $this->backHandler->OpenConnection();
        $this->backHandler->Perform($candidate, $target);
        $this->backHandler->CloseConnection();
    }

    /**
     * 備份記錄檔
     * @author steve.tsao
     * @param Candidate $candidate 檔案資訊
     * @param string $target 檔案內容
     */
    private function SaveLogToDB(Candidate $candidate, string $target)
    {
        $this->logHandler->OpenConnection();
        $this->logHandler->Perform($candidate, $target);
        $this->logHandler->CloseConnection();
    }
}
