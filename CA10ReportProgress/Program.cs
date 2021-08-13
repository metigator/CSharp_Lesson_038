using System;
using System.Threading.Tasks;

namespace CA10ReportProgress
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Action<int> progress = (p) => { Console.Clear(); Console.WriteLine($"{p}%"); };
            await Copy(progress);
            Console.ReadKey();
        }

        static Task Copy(Action<int> onProgressPercentChanged)
        {
            return Task.Run(() => {
                for (int i = 0; i <= 100; i++)
                {
                    Task.Delay(50).Wait();
                    if (i % 10 == 0)
                        onProgressPercentChanged(i);
                }
            });
        }
    }
}
