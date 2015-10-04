#import "PrimeCalculator.h"

@interface PrimeCalculator()

@end

@implementation PrimeCalculator

+ (int) getPrimesFromSieve: (int) maxValue {
    Byte *primes;
    primes = (Byte *) malloc(maxValue * sizeof(Byte));
    //NSMutableArray *primes = [NSMutableArray arrayWithCapacity:maxValue];
    //primes = {0};
    for (int i=1; i<=maxValue; i++)
    {
        primes[i-1] = 0;
    }
    
    int largestPrimeFound;
    largestPrimeFound = 1;
    
    
    for (int i=2; i<=maxValue; i++)
    {
        if(primes[i-1] == 0)
        {
            primes[i-1] = 1;
            largestPrimeFound = i;
        }
        
        
        // mark all multiples of prime selected above as non primes
        int c=2;
        int mul = i*c;
        for(; mul <= maxValue;)
        {
            primes[mul-1] = 1;
            c++;
            mul = i*c;
        }
    }
    
    return largestPrimeFound;
}

@end