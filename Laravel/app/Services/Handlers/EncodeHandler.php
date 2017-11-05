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
 * 加密處理
 * Class EncodeHandler
 * @author steve.tsao
 * @package App\Services\Handlers
 */
class EncodeHandler extends AbstractHandler
{
    /**
     * 檔案加密
     * @author steve.tsao
     * @param Candidate $candidate 檔案資訊
     * @param string $target 檔案內容
     * @return string 加密後檔案
     */
    public function PerForm(Candidate $candidate, $target): string
    {
        return base64_encode($target);
    }
}
