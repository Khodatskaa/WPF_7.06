namespace WPF_7._06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of threads:");
            int numThreads = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the beginning of the range:");
            int start = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the end of the range:");
            int end = int.Parse(Console.ReadLine());

            for (int i = 0; i < numThreads; i++)
            {
                int threadStart = start + (i * ((end - start + 1) / numThreads));
                int threadEnd = start + ((i + 1) * ((end - start + 1) / numThreads)) - 1;
                Thread thread = new Thread(() => DisplayNumbers(threadStart, threadEnd));
                thread.Start();
            }

            Console.ReadLine();
        }

        static void DisplayNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
    }
}
