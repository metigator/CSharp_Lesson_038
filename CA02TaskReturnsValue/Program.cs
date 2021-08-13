using System;
using System.Threading.Tasks;

namespace CA02TaskReturnsValue
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<DateTime> task = Task.Run(GetCurrentDatetime);
            //Console.WriteLine(task.Result); // block thead until result is ready

            Console.WriteLine(task.GetAwaiter().GetResult());
            Console.ReadKey();
        }

        static DateTime GetCurrentDatetime() => DateTime.Now;
    }
}
