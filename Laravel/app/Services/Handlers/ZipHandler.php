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
 * 壓縮處理
 * Class ZipHandler
 * @author steve.tsao
 * @package App\Services\Handlers
 */
class ZipHandler extends AbstractHandler
{
    /**
     * 檔案壓縮
     * @author steve.tsao
     * @param Candidate $candidate 檔案資訊
     * @param string $target 檔案
     * @return string 壓縮後檔案
     */
    public function PerForm(Candidate $candidate, $target): string
    {
        return gzcompress($target);
    }
}
