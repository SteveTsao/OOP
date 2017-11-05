<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/5
 * Time: 下午 11:32
 */

namespace App\Services\Handlers;


use App\Services\Configs\Candidate;

/**
 * 檔案處理
 * Class FileHandler
 * @author steve.tsao
 * @package App\Services\Handlers
 */
class FileHandler extends AbstractHandler
{
    /**
     * 讀取、暫存檔案
     * @author steve.tsao
     * @param Candidate $candidate 檔案資訊
     * @param string|null $target 檔案內容
     * @return string 處理後檔案內容
     */
    public function PerForm(Candidate $candidate, $target): string
    {
        if (is_null($target)) {
            return $this->ConvertFileToByteArray($candidate); // 轉換成 btyes
        }

        // 暫存檔案
        $this->ConvertStringToFile($candidate->Name, $target);

        return $target;
    }

    /**
     * 讀取檔案轉換成btye型態
     * @author steve.tsao
     * @param Candidate $candidate 檔案資訊
     * @return string 檔案內容
     */
    public function ConvertFileToByteArray(Candidate $candidate): string
    {
        $fp = fopen($candidate->Config->Location . $candidate->Name, 'r');

        $str = '';
        $tmp = fgets($fp);

        while ($tmp !== false) {
            $str .= $tmp;
            $tmp = fgets($fp);
        }

        fclose($fp);

        return $str;
    }
}
