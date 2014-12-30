using System;
using System.Collections.Generic;
using System.Text;

namespace PerfTest1Xamarin
{
    public static class PrimeNumbers
    {
        public static int GetPrimesFromSieve(int maxValue)
        {
            var primes = new byte[maxValue + 1];
            for (var i = 0; i <=maxValue; i++)
            {
                primes[i] = 0;
            }
            var largestPrimeFound = 1;

            for (var i = 2; i <=maxValue; i++)
            {
                if (primes[i - 1] == 0)
                {
                    primes[i - 1] = 1;
                    largestPrimeFound = i;
                }

                var c = 2;
                var mul = i*c;
                for (; mul <= maxValue;)
                {
                    primes[mul - 1] = 1;
                    c++;
                    mul = i*c;
                }
            }
            return largestPrimeFound;
        }
    }
}