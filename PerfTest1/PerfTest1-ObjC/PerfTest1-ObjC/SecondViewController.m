//
//  SecondViewController.m
//  PerfTest1-ObjC
//
//  Created by kevin Ford on 12/2/14.
//  Copyright (c) 2014 kevin Ford. All rights reserved.
//

#import "SecondViewController.h"


@interface SecondViewController ()

@end

@implementation SecondViewController

@synthesize txtMaxPrime;

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view, typically from a nib.
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

-(BOOL)textFieldShouldReturn:(UITextField *)textfield {
    [textfield resignFirstResponder];
    return YES;
}

-(IBAction) btnCalcPrimesClicked:(id)sender {
    //[self performSelector:@selector(createViewController) withObject:nil afterDelay:0];
    NSScanner* scan = [NSScanner scannerWithString:txtMaxPrime.text];
    int val;
    
    if ([scan scanInt:&val] && [scan isAtEnd]) {
        int returnValue = [self getPrimesFromSieve: val];
        NSString *returnString = [NSString stringWithFormat:@"%d", returnValue];
        UIAlertController *alert = [UIAlertController alertControllerWithTitle:@"Prime Calculation Complete" message:[NSString stringWithFormat:@"%@%@", @"Largest prime found: ", returnString] preferredStyle: UIAlertControllerStyleAlert];
        
        UIAlertAction *alertAction = [UIAlertAction actionWithTitle: @"Dismiss"
                                                              style: UIAlertActionStyleDestructive
                                                            handler: NULL];
        
        [alert addAction: alertAction];
        [self presentViewController: alert animated: YES completion: nil];
    } else {
        
        UIAlertController *alert = [UIAlertController alertControllerWithTitle:@"Prime Calculation Error" message:[NSString stringWithFormat:@"%@%@", @"Must enter a numeric max value: ", txtMaxPrime.text] preferredStyle: UIAlertControllerStyleAlert];
        
        UIAlertAction *alertAction = [UIAlertAction actionWithTitle: @"Dismiss"
                                                              style: UIAlertActionStyleDestructive
                                                            handler: NULL];
        
        [alert addAction: alertAction];
        [self presentViewController: alert animated: YES completion: nil];
    }
}

- (int) getPrimesFromSieve: (int) maxValue {
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
