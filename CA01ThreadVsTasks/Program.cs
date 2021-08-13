using System;
using System.Threading;
using System.Threading.Tasks;

namespace CA01ThreadVsTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var th = new Thread(() => Display("Metigator using thread !!!"));
            th.Start();
            th.Join();

            Task.Run(() => Display("Metigator using task !!!")).Wait();
            Console.ReadKey();
        } 

        static void Display(string message)
        {
            ShowThreadInfo(Thread.CurrentThread);
            Console.WriteLine(message);
        }

        private static void ShowThreadInfo(Thread th)
        {
            Console.WriteLine($"TID: {th.ManagedThreadId}, Pooled: {th.IsThreadPoolThread}, Background: {th.IsBackground}");
        }
    }
}
