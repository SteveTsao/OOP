<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/5
 * Time: 下午 11:33
 */

namespace App\Services\Handlers;


use App\Services\Configs\Candidate;

/**
 * 備份目錄
 * Class DirectoryHandler
 * @author steve.tsao
 * @package App\Services\Handlers
 */
class DirectoryHandler extends AbstractHandler
{
    /**
     * 處理檔案目錄備份
     * @author steve.tsao
     * @param Candidate $candidate
     * @param string $target 檔案內容
     * @return string
     */
    public function PerForm(Candidate $candidate, $target): string
    {
        $this->ConvertStringToFile($candidate->Config->Dir . $candidate->Name . '.bak', $target);

        return $target;
    }
}