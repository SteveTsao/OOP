using System;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleOop
{
    class Program
    {
        static void Main(string[] args)
        {
            /// 封裝Config物件類別
            var configs = new ConfigManager();

            configs.ProcessJsonConfig();

            for (int i = 0; i < configs.Count; i++)
            {
                Console.WriteLine("configs[" + i + "].Ext=" + configs[i].Ext);
                Console.WriteLine("configs[" + i + "].Location=" + configs[i].Location);
                Console.WriteLine("configs[" + i + "].SubDirectory=" + configs[i].SubDirectory.ToString());
                Console.WriteLine("configs[" + i + "].Unit=" + configs[i].Unit);
                Console.WriteLine("configs[" + i + "].Remove=" + configs[i].Remove.ToString());
                Console.WriteLine("configs[" + i + "].Handler=" + configs[i].Handler);
                Console.WriteLine("configs[" + i + "].Destination=" + configs[i].Destination);
                Console.WriteLine("configs[" + i + "].Dir=" + configs[i].Dir);
                Console.WriteLine("configs[" + i + "].ConnectionString=" + configs[i].ConnectionString);
            }

            /// 封裝Schedule物件類別
            var schedules = new ScheduleManager();

            schedules.ProcessJsonConfig();

            for (int i = 0; i < schedules.Count; i++)
            {
                Console.WriteLine("schedules[" + i + "].Ext=" + schedules[i].Ext);
                Console.WriteLine("schedules[" + i + "].Time=" + schedules[i].Time);
                Console.WriteLine("schedules[" + i + "].Interval=" + schedules[i].Interval);
            }

            /// Dependency Injection 依賴注入
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ConfigManager>()
                .AddSingleton<ScheduleManager>()
                .AddSingleton<MyBackupService>()
                .BuildServiceProvider();

            /// 備份執行類別
            var bkService = serviceProvider.GetService<MyBackupService>();

            bkService.ProcessJsonConfigs();

            Console.ReadKey(true);
        }
    }
}
