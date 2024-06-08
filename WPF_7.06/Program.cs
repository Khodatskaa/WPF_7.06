using System;
using System.Threading;

namespace WPF_7._06
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(DisplayNumbers));
            thread.Start();
            Console.ReadLine();
        }

        static void DisplayNumbers()
        {
            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
    }
}
