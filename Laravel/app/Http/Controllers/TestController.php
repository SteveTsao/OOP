<?php

namespace App\Http\Controllers;

use App\Services\ConfigManager;
use App\Services\MyBackupService;
use App\Services\ScheduleManager;
use Illuminate\Http\Request;

class TestController extends Controller
{
    //
    public function index()
    {
        $configs = new ConfigManager();

        collect($configs->ProcessJsonConfig())->map(function ($item, $key) {
            print_r("\n<br/>Config[$key]->Ext=" . $item->Ext);
            print_r("\n<br/>Config[$key]->Location=" . $item->Location);
            print_r("\n<br/>Config[$key]->SubDirectory=" . var_export($item->SubDirectory, true));
            print_r("\n<br/>Config[$key]->Unit=" . $item->Unit);
            print_r("\n<br/>Config[$key]->Remove=" . var_export($item->Remove, true));
            print_r("\n<br/>Config[$key]->Handler=" . $item->Handler);
            print_r("\n<br/>Config[$key]->Destination=" . $item->Destination);
            print_r("\n<br/>Config[$key]->Dir=" . $item->Dir);
            print_r("\n<br/>Config[$key]->ConnectionString=" . $item->ConnectionString);
        });

        print_r("\n<br/>ConfigManager->Count=" . $configs->Count);

        $schedules = new ScheduleManager();

        collect($schedules->ProcessJsonConfig())->map(function ($item, $key) {
            print_r("\n<br/>Schedule[$key]->Ext=" . $item->Ext);
            print_r("\n<br/>Schedule[$key]->Time=" . $item->Time);
            print_r("\n<br/>Schedule[$key]->Interval=" . $item->Interval);
        });

        print_r("\n<br/>ScheduleManager->Count=" . $schedules->Count);

        $myBackupService = resolve(MyBackupService::class);

        print_r($myBackupService->ProcessJsonConfigs());
    }
}
