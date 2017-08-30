using System;


namespace SeiveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            string S;
            int N;
            

            // Get user input for highest number to check for prime
            S = getNumberCeiling();

            // Check that user input is able to be parsed into a positive integer
            while (!int.TryParse(S, out N) || N < 1)
            {
                // Prompt user for new input if previous input was unable to be parsed
                Console.WriteLine("Your input was not able to be converted to an integer!");
                S = getNumberCeiling();
            }

            DateTime start = DateTime.Now;     

            // Create a number array where true denotes prime
            bool[] isPrime = new bool[N];
            isPrime[0] = false;
            for (int c = 1; c < N; c++)
            {
                isPrime[c] = true;
            }

            // check each number for being prime
            for (int i = 2; i <= N; i++)
            {
                // i is prime if it hasn't been labeled false yet;
                if (isPrime[i - 1])
                {
                    Console.Write(i + " ");
                    // Mark all multiples of this number as false 
                    for (int j = 2 * i; j <= N; j += i)
                    {
                        isPrime[j - 1] = false;
                    }
                }
            }

            DateTime end = DateTime.Now;
            TimeSpan diff = end - start;

            Console.WriteLine("\n \n TIME " + diff);

            Console.ReadKey();
        }

        static string getNumberCeiling()
        {
            Console.WriteLine("Enter the prime number ceiling: ");
            return Console.ReadLine();
        }
    }
}