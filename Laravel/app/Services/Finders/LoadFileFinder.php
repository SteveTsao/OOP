<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/11/12
 * Time: 下午 07:52
 */

namespace App\Services\Finders;


use App\Services\Configs\Candidate;
use App\Services\Configs\Config;
use Illuminate\Support\Collection;

/**
 * 備份來源:檔案
 * Class LoadFileFinder
 * @author steve.tsao
 * @package App\Services\Finders
 */
class LoadFileFinder extends AbstractFileFinder
{
    /**
     * 取得目錄下所有檔案，包含子目錄
     * @author steve.tsao
     * @param Config $config 檔案設定
     * @param string $filePath 檔案位置
     * @return Collection 所有檔案集合
     */
    private function GetFiles(Config $config, string $filePath = '*'): Collection
    {
        return collect(glob($filePath))->map(function ($item) use ($config) {

            if (is_dir($item)) {
                return $config->SubDirectory ? $this->GetFiles($config, $item . '\\*') : '';
            }

            $info = pathinfo($item);

            return ($info['extension'] == $config->Ext) ? $item : '';
        });
    }

    /**
     * 取得備份來源資訊
     * @author steve.tsao
     * @param Config $config 檔案設定
     */
    public function FileFinder(Config $config)
    {
        // TODO: Implement FileFinder() method.

        // 設定來源位置
        $this->config = $config;

        // 指定目錄
        $this->files = $this->GetFiles($config, $config->Location . '*')
            ->flatten()
            ->reject(function ($item) {
                return ($item === '');
            })
            ->toArray();
    }

    /**
     * 設定備份檔案
     * @author steve.tsao
     * @param string $fileName 檔案位置
     * @return Candidate 檔案資訊
     */
    protected function CreateCandidate(string $fileName): Candidate
    {
        $fileDate = date('Y/m/d H:i:s', filectime($fileName));

        return new Candidate($this->config, $fileDate, $fileName, $fileName, filesize($fileName));
    }
}
