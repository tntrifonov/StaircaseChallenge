using System;

namespace StaircaseChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;

            Console.Write("N = ");
            
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Not valid! Try again:");
                Console.Write("N = ");
            }

            int numOfSteps;

            while (true)
            {
                Console.WriteLine("How many elements in the set of positive integers X?");

                if (int.TryParse(Console.ReadLine(), out numOfSteps))
                {
                    if (numOfSteps > 0)
                    {
                        break;
                    }
                }

                Console.WriteLine("Not valid! Try again:");
            }

            int[] x = new int[numOfSteps];

            int index = 0;

            while (index < x.Length)
            {
                Console.Write("X[" + index + "] = ");
                if (int.TryParse(Console.ReadLine(), out x[index]))
                {
                    if (x[index] > 0)
                    {
                        index++;
                    }
                    else
                    {
                        Console.WriteLine("Not valid! Try again:");
                    }
                }
                else
                {
                    Console.WriteLine("Not valid! Try again:");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Inputs:");
            Console.WriteLine("N = " + n);
            Console.WriteLine("X = { " + string.Join(", ", x) + " }");
            Console.WriteLine();
            Console.WriteLine("Output:");
            Console.Write("Unique ways = " + StaircaseChallengeSolver.Solve(n, x));
            Console.WriteLine();
        }
    }
}
