<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/25
 * Time: 下午 11:15
 */

namespace App\Services\Handlers\DBHandlers;


use App\Services\Configs\Candidate;
use DB;

/**
 * 備份記錄檔
 * Class DBLogHandler
 * @author steve.tsao
 * @package App\Services\Handlers\DBHandlers
 */
class DBLogHandler extends AbstractDBHandler
{
    /**
     * 備份記錄檔處理
     * @author steve.tsao
     * @param Candidate $candidate 檔案資訊
     * @param null|string $target 檔案內容
     * @return string 檔案內容
     */
    public function Perform(Candidate $candidate, $target): string
    {
        DB::insert('INSERT INTO Logs (Log_filename, Log_datetime) VALUES (?, ?)', [
            $this->ConvertFileName($candidate->Name),
            date('Y-m-d H:i:s'),
        ]);

        return $target;
    }
}
