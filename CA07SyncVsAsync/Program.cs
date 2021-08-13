using System;
using System.Threading;
using System.Threading.Tasks;

namespace CA07SyncVsAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowThreadInfo(Thread.CurrentThread, 11);
            CallSynchronous();
        
            ShowThreadInfo(Thread.CurrentThread, 14);
            CallAsynchronous();

            ShowThreadInfo(Thread.CurrentThread, 17);
            Console.ReadKey();
        }

        static void CallSynchronous()
        {
            Thread.Sleep(4000);
            ShowThreadInfo(Thread.CurrentThread, 24);
            Task.Run(() => Console.WriteLine("++++++++++ Synchronous +++++++++++")).Wait();
        }

        static void CallAsynchronous()
        { 
            ShowThreadInfo(Thread.CurrentThread, 30);
            Task.Delay(4000).GetAwaiter().OnCompleted(() => {
                ShowThreadInfo(Thread.CurrentThread, 32);
                Console.WriteLine("++++++++++ Asynchronous +++++++++++");
            }); 
        }


        private static void ShowThreadInfo(Thread th, int line)
        {
            Console.WriteLine($"Line#: {line}, TID: {th.ManagedThreadId}, Pooled: {th.IsThreadPoolThread}, Background: {th.IsBackground}");
        }
    }
}
