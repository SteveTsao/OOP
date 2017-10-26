<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/10/22
 * Time: 下午 04:59
 */

namespace App\Services;


/**
 * 檔案處理設定類別
 * Class Config
 * @author steve.tsao
 * @package App\Services
 */
class Config
{
    use PropReadOnlyTrait; // 設定類別唯讀屬性

    private $ext = '';
    private $location = '';
    private $subDirectory = true;
    private $unit = '';
    private $remove = false;
    private $handler = '';
    private $destination = '';
    private $dir = '';
    private $connectionString = '';

    /**
     * Config constructor.
     * @author steve.tsao
     * @param string $ext 檔案格式
     * @param string $location 備份檔案的目錄
     * @param bool $subDirectory 是否處理子目錄
     * @param string $unit 設定備份單位
     * @param bool $remove 處理完是否刪除檔案
     * @param string $handler 處理方式
     * @param string $destination 
     * @param string $dir 處理後的目錄
     * @param string $connectionString 資料庫連接字串
     */
    public function __construct(
        string $ext,
        string $location,
        bool $subDirectory,
        string $unit,
        bool $remove,
        string $handler,
        string $destination,
        string $dir,
        string $connectionString
    )
    {
        $this->ext = $ext;
        $this->location = $location;
        $this->subDirectory = $subDirectory;
        $this->unit = $unit;
        $this->remove = $remove;
        $this->handler = $handler;
        $this->destination = $destination;
        $this->dir = $dir;
        $this->connectionString = $connectionString;
    }
}
