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
