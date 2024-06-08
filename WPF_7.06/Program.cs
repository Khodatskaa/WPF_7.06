namespace WPF_7._06
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the beginning of the range:");
            int start = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the end of the range:");
            int end = int.Parse(Console.ReadLine());

            Thread thread = new Thread(() => DisplayNumbers(start, end));
            thread.Start();
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
