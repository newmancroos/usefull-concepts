using System;
using System.Threading.Tasks;

namespace HowAsyncWork
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Step1");
            Console.WriteLine("Step2");
            Console.WriteLine("Step3");
            var task =  SomeProcess(); //Process start and SomeProcess running at this stage. this start a separate thread
            Console.WriteLine("Step4");
            Console.WriteLine("Step5");
            Console.WriteLine("Step6");
            var output = await task;   //Check if the SomeProcess compete and wait for complete
            Console.WriteLine("Step7");
            Console.WriteLine("Step8");
            Console.WriteLine("Step9");
            Console.ReadKey();
        }

        static async Task<string> SomeProcess()
        {
            await Task.Delay(10000);
            return "Completed";
        }
    }
}
