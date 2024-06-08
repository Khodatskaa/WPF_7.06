namespace WPF_7._06
{
    class Program
    {
        static int[] numbers = new int[10000];
        static int max = int.MinValue;
        static int min = int.MaxValue;
        static double sum = 0;
        static object lockObj = new object();

        static void Main(string[] args)
        {
            Random random = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1000); 
            }

            Thread maxThread = new Thread(FindMax);
            Thread minThread = new Thread(FindMin);
            Thread meanThread = new Thread(CalculateMean);

            maxThread.Start();
            minThread.Start();
            meanThread.Start();

            maxThread.Join();
            minThread.Join();
            meanThread.Join();

            Console.WriteLine($"Maximum: {max}");
            Console.WriteLine($"Minimum: {min}");
            Console.WriteLine($"Arithmetic Mean: {sum / numbers.Length}");

            Console.ReadLine();
        }

        static void FindMax()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                lock (lockObj)
                {
                    if (numbers[i] > max)
                    {
                        max = numbers[i];
                    }
                }
            }
        }

        static void FindMin()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                lock (lockObj)
                {
                    if (numbers[i] < min)
                    {
                        min = numbers[i];
                    }
                }
            }
        }

        static void CalculateMean()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                lock (lockObj)
                {
                    sum += numbers[i];
                }
            }
        }
    }
}
