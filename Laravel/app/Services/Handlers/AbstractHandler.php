<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/5
 * Time: 下午 11:30
 */

namespace App\Services\Handlers;


use App\Services\Configs\Candidate;

/**
 * 備份檔案處理抽象類別
 * Class AbstractHandler
 * @author steve.tsao
 * @package App\Services\Handlers
 */
class AbstractHandler implements IHandler
{
    /**
     * 儲存檔案
     * @author steve.tsao
     * @param Candidate $candidate 檔案資訊
     * @param string|null $target 檔案內容
     * @return string 處理後檔案內容
     */
    public function PerForm(Candidate $candidate, $target): string
    {
        // TODO: Implement PerForm() method.

        return $target;
    }

    /**
     * 儲存檔案
     * @author steve.tsao
     * @param string $path 儲存位置
     * @param string $target 檔案
     */
    protected function ConvertStringToFile(string $path, string $target)
    {
        $fp = fopen($path, 'w');
        fwrite($fp, $target);
        fclose($fp);
    }

    /**
     * 產生檔案名稱
     * @author steve.tsao
     * @param string $path
     * @return string
     */
    protected function GenFileName(string $path):string
    {
        return str_replace(['%', ':', '/', '\\'], ['%25', '%3A', '%2F', '%5C'], $path);
    }

    /*
    protected function string2Byte(string $str): array
    {
        return unpack('C*', $str);
    }

    protected function byte2String(array $arr): string
    {
        return pack('C*', ...$arr);
    }
    */
}
