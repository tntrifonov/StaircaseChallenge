using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;

namespace StaircaseChallenge
{
    static class StaircaseChallengeSolver
    {
        public static BigInteger Solve(int N, int[] Steps)
        {
            // Input Validation

            if (N == 0)
            {
                Console.WriteLine("Invalid staircase!");
                return 0;
            }

            int[] X = Steps.Distinct<int>().ToArray();

            bool isSetValidForN = false;

            foreach (int x in X)
            {
                if (x == 0)
                {
                    Console.WriteLine("Infinite ways - zero step in input!");
                    return -1;
                }

                if (x <= N)
                {
                    isSetValidForN = true;
                }
            }

            if (!isSetValidForN)
            {
                Console.WriteLine("Zero ways - all steps are bigger than the staircase!");
                return 0;
            }

            // ---------------------------------------------------------------------------

            // The set X and the set of multipliers form a multiset
            int[] MaxMultipliers = new int[X.Length];

            for (int i = 0; i < X.Length; i++)
            {
                MaxMultipliers[i] = N / X[i];
            }

            int[] CurrentMultipliers = new int[X.Length];

            Array.Copy(MaxMultipliers, 0, CurrentMultipliers, 0, MaxMultipliers.Length);

            BigInteger allPotentialWays = 1;

            for (int i = 0; i < MaxMultipliers.Length; i++)
            {
                allPotentialWays *= MaxMultipliers[i] + 1;
            }

            BigInteger uniqueWays = 0;

            int currentSum = 0;

            for (BigInteger way = 0; way < allPotentialWays; way++)
            {
                for (int i = 0; i < X.Length; i++)
                {
                    currentSum += X[i] * CurrentMultipliers[i];
                }

                // If a possible way is found, find all arrangements
                if (currentSum == N)
                {
                    BigInteger currentMultipliersSum = CurrentMultipliers.Sum();

                    BigInteger permutationDivisor = 1;

                    for (int i = 0; i < CurrentMultipliers.Length; i++)
                    {
                        permutationDivisor *= Factorial(CurrentMultipliers[i]);
                    }

                    // Permutation with repetition
                    uniqueWays += Factorial(currentMultipliersSum) / permutationDivisor;
                }

                currentSum = 0;

                // Iterate to next potential values for multipliers
                for (int i = CurrentMultipliers.Length - 1; i >= 0; i--)
                {
                    if (CurrentMultipliers[i] > 0)
                    {
                        CurrentMultipliers[i]--;
                        break;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            break;
                        }
                        else
                        {
                            CurrentMultipliers[i] = MaxMultipliers[i];
                        }
                    }
                }
            }

            return uniqueWays;
        }

        private static BigInteger Factorial(BigInteger n)
        {
            BigInteger factorial = 1;

            for (BigInteger i = n; i > 1; i--)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
