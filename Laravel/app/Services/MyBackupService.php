<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/10/24
 * Time: 下午 07:27
 */

namespace App\Services;


/**
 * Class MyBackupService
 * @author steve.tsao
 * @package App\Services
 */
class MyBackupService
{
    /**
     * @var array 存放JsonManager物件陣列
     */
    private $managers = [];

    /**
     * MyBackupService constructor.
     * @author steve.tsao
     */
    public function __construct()
    {
        // DI 依賴注入 JsonManager 物件到陣列
        $this->managers = collect(func_get_args())->reject(function ($item) {
            // reject 非繼承 JsonManager
            return !$item instanceof JsonManager;
        })->all();
    }

    /**
     * 解析JSON檔案
     * @author steve.tsao
     */
    public function ProcessJsonConfigs()
    {
        // 呼叫JsonManager子類別實作的ProcessJsonConfig函數
        collect($this->managers)->map(function ($item) {
            /**
             * @var JsonManager $item
             */
            $item->ProcessJsonConfig();
        });
    }
}
