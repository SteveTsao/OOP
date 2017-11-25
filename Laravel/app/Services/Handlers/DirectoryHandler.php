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
     * @param Candidate $candidate 檔案資訊
     * @param string|null $target 檔案內容
     * @return string 檔案內容
     */
    public function PerForm(Candidate $candidate, $target): string
    {
        $fileName = $this->GenFileName($candidate->Name) . '.bak';

        $this->ConvertStringToFile($candidate->Config->Dir . $fileName, $target);

        return $target;
    }
}
