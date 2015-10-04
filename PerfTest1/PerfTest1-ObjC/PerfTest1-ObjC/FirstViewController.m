//
//  FirstViewController.m
//  PerfTest1-ObjC
//
//  Created by kevin Ford on 12/2/14.
//  Copyright (c) 2014 kevin Ford. All rights reserved.
//

#import "FirstViewController.h"

@interface FirstViewController ()

@end


@implementation FirstViewController
{
    NSArray *tableData;
    MSClient *client;
}

@synthesize grdRegistrations;

- (void)viewDidLoad {
    [super viewDidLoad];
    client  = [MSClient clientWithApplicationURLString:@"https://malor2014jsmobileservice.azure-mobile.net/" applicationKey:@"pdFskoBXcwzaDNTpuRWdVRhUIRYcFF14"];
}

-(IBAction) btnClearClicked:(id)sender {
    tableData = [NSArray new];
    [self.grdRegistrations reloadData];
}

-(IBAction) btnFetchClicked:(id)sender {
    
    MSTable *table = [client tableWithName:@"Registration"];

    MSQuery *query = [table query];
    
    query.fetchLimit = 1000;
    
    [query readWithCompletion:^(MSQueryResult *items, NSError *error) {
        if(error) {
            NSLog(@"ERROR %@", error);
        } else {
            tableData = items.items;
            [self.grdRegistrations reloadData];
        }
    }];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.

}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return [tableData count];
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *simpleTableIdentifier = @"SimpleTableItem";
    
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:simpleTableIdentifier];
    
    if (cell == nil) {
        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:simpleTableIdentifier];
    }
    
    NSMutableDictionary *item = [tableData objectAtIndex:indexPath.row];
    
    cell.textLabel.text = [item objectForKey:@"screenname"];
    return cell;
}

@end
