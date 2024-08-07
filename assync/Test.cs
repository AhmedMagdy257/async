using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace async
{
    public class Test
    {

        public void Demo()
        {
            try
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();

                Task.Run(() => First());// call first alone (will display last one) 8 sec
                Task.Run(() => Second());// call second alone (will display second) 3 sec
                Task.Run(() => Third());// cal1 third alone (will display first) 2 sec
                ////////Execution Time => time of execut program only /
                ///////ex:19 millisec display first line




                //var task1 = First();
                //var task2 = Second();
                //var task3 = Third();
                //Task.WaitAll(task1, task2, task3); // wait task1 then task2 then task3
                //////////////////Execution Time =>8+3+2=13 Sec display last one



                watch.Stop();
                Console.WriteLine($"Execution Time:{watch.ElapsedMilliseconds} Milliseconds");
                throw new Exception();
            }
            catch (Exception ex)
            {
                Log.Logger = new LoggerConfiguration()
                  .MinimumLevel.Debug()
                  .WriteTo.File(@"C:\Users\amabdelhamid\source\repos\assync\assync\console_log.txt", rollingInterval: RollingInterval.Day)
                  .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
                  .CreateLogger();
                
                  //Log.Information("Error Info : " +ex.ToString());
                  //Log.Fatal("Error Fatal : " +ex.ToString());
                  Log.Error("Error Occur : "+ex.ToString());
                
            }

        }
        public static async Task First()
        {
            Thread.Sleep(8000);
            Console.WriteLine("First Started");
        }
        public static async Task Second()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Second Started");
        }
        public static async Task  Third()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Third Started");
        }

    }
}
