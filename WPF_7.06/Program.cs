using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter the beginning of the range:");
            int startRange = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the end of the range:");
            int endRange = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of threads:");
            int threadCount = int.Parse(Console.ReadLine());

            if (startRange > endRange || threadCount <= 0)
            {
                Console.WriteLine("Invalid input. Please enter valid range and thread count.");
                return;
            }

            int rangePerThread = (endRange - startRange + 1) / threadCount;
            Thread[] threads = new Thread[threadCount];

            for (int i = 0; i < threadCount; i++)
            {
                int start = startRange + i * rangePerThread;
                int end = (i == threadCount - 1) ? endRange : start + rangePerThread - 1;

                threads[i] = new Thread(() => PrintNumbers(start, end));
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("All threads completed.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter valid integer values.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Input is too large or too small.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    static void PrintNumbers(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            Console.WriteLine(i);
        }
    }
}
