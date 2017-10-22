using System;

namespace ConsoleOop
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigManager configs = new ConfigManager();

            configs.ProcessConfig("configs.json");

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

            ScheduleManager schedules = new ScheduleManager();

            schedules.ProcessSchedule("schedule.json");

            for (int i = 0; i < schedules.Count; i++)
            {
                Console.WriteLine("schedules[" + i + "].Ext=" + schedules[i].Ext);
                Console.WriteLine("schedules[" + i + "].Time=" + schedules[i].Time);
                Console.WriteLine("schedules[" + i + "].Interval=" + schedules[i].Interval);
            }

            Console.ReadKey(true);
        }
    }
}
