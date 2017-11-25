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
 * 備份檔案
 * Class DBBackupHandler
 * @author steve.tsao
 * @package App\Services\Handlers\DBHandlers
 */
class DBBackupHandler extends AbstractDBHandler
{
    /**
     * 備份檔案處理
     * @author steve.tsao
     * @param Candidate $candidate 檔案資訊
     * @param null|string $target 檔案內容
     * @return string 檔案內容
     */
    public function Perform(Candidate $candidate, $target): string
    {
        $sql = 'INSERT INTO Backups (Backup_filename, Backup_filedatetime, Backup_filesize, Backup_blob)'
            . '        VALUES (?, ?, ?, ?)';

        DB::insert($sql, [
            $this->ConvertFileName($candidate->Name),
            $candidate->FileDateTime,
            $candidate->Size,
            $target,
        ]);

        return $target;
    }
}
