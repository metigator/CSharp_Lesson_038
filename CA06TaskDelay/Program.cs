using System;
using System.Threading;
using System.Threading.Tasks;

namespace CA06TaskDelay
{
    class Program
    {
        static void Main(string[] args)
        {
            DelayUsingTask(5000);
            Console.ReadKey();
        } 

        static void DelayUsingTask(int ms)
        {
            Task.Delay(ms).GetAwaiter().OnCompleted(() => { 
            Console.WriteLine($"Completed after Task.Delay({ms})");

            });
        }
          
        static void SleepUsingThread(int ms)
        {
            Thread.Sleep(ms);
            Console.WriteLine($"Completed after Thread.Sleep({ms})");

        }
    }
}
