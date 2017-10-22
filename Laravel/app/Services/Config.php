<?php
/**
 * Created by PhpStorm.
 * User: tsao
 * Date: 2017/10/22
 * Time: 下午 04:59
 */

namespace App\Services;


/**
 * Class Config
 * @author steve.tsao
 * @package App\Services
 */
class Config
{
    use PropReadOnlyTrait;

    private $ext = '';
    private $location = '';
    private $subDirectory = true;
    private $unit = '';
    private $remove = false;
    private $handler = '';
    private $destination = '';
    private $dir = '';
    private $connectionString = '';

    /**
     * Config constructor.
     * @author steve.tsao
     * @param string $ext
     * @param string $location
     * @param bool $subDirectory
     * @param string $unit
     * @param bool $remove
     * @param string $handler
     * @param string $destination
     * @param string $dir
     * @param string $connectionString
     */
    public function __construct(
        string $ext,
        string $location,
        bool $subDirectory,
        string $unit,
        bool $remove,
        string $handler,
        string $destination,
        string $dir,
        string $connectionString
    )
    {
        $this->ext = $ext;
        $this->location = $location;
        $this->subDirectory = $subDirectory;
        $this->unit = $unit;
        $this->remove = $remove;
        $this->handler = $handler;
        $this->destination = $destination;
        $this->dir = $dir;
        $this->connectionString = $connectionString;
    }
}