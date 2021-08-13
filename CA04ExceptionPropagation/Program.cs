using System;
using System.Threading;
using System.Threading.Tasks;

namespace CA04ExceptionPropagation
{
    class Program
    {
        static void Main(string[] args)
        {
            // -- 1 --
            //try
            //{
            //    var th = new Thread(ThrowException);
            //    th.Start();
            //    th.Join();
            //}
            //catch
            //{
            //    Console.WriteLine("Exception is thrown!!");
            //}

            // -- 2 --
            //var th = new Thread(ThrowExceptionWithTryCatchBlock);
            //th.Start();
            //th.Join();

            // -- 3 --

            try
            {
                Task.Run(ThrowException).Wait();
            }
            catch 
            {
                Console.WriteLine("Exception is thrown!!");

            }
            Console.ReadKey();
        } 

        static void ThrowException()
        {
            throw new NullReferenceException();
        }

        static void ThrowExceptionWithTryCatchBlock()
        {
            try
            {
                throw new NullReferenceException();

            }
            catch 
            {
                Console.WriteLine("Exception is thrown!!");

                throw;
            }
        }
    }
}
