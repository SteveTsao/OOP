<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/5
 * Time: 下午 09:29
 */

namespace App\Services\Configs;


/**
 * 備份檔案資訊
 * Class Candidate
 * @author steve.tsao
 * @package App\Services\Configs
 */
class Candidate
{
    use PropReadOnlyTrait; // 設定類別唯讀屬性

    private $config;
    private $fileDateTime = '';
    private $name = '';
    private $processName = '';
    private $size = 0;

    /**
     * 建構子 屬性初始設定
     * Candidate constructor.
     * @author steve.tsao
     * @param Config $config 檔案處理設定
     * @param string $fileDateTime 檔案日期
     * @param string $name 檔案名稱
     * @param string $processName 處理名稱
     * @param int $size 檔案大小
     */
    public function __construct(Config $config, string $fileDateTime, string $name, string $processName, int $size)
    {
        $this->config = $config;
        $this->fileDateTime = $fileDateTime;
        $this->name = $name;
        $this->processName = $processName;
        $this->size = $size;
    }
}
