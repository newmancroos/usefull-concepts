using System;
using System.Threading;
using System.Threading.Tasks;

namespace FireAndForget
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Task.Run(() => FireAndForgetIt("Newman")).ConfigureAwait(false); // If exception in the calling function will stop the application
            Task.Run(() => FireAndForgetIt("Newmancroos")).Forget();
            Console.WriteLine("Hello World111!");
            //---------------------------
            DateTime dateTime1 = DateTime.Now.AddMinutes(-10);
            int MinDiff = ((TimeSpan)(DateTime.Now - dateTime1)).Minutes;
            Console.WriteLine($"Difference : {MinDiff}");
            //-----------------------------
            Console.ReadLine();
        }

        public static void FireAndForgetIt(string input)
        {
            
            Thread.Sleep(5000);
            Console.WriteLine(input);
            throw new ArgumentException("Error"); 
        }
    }


}
