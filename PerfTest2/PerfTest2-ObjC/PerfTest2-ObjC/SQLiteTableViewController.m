//
//  SQLiteTableViewController.m
//  PerfTest2-ObjC
//
//  Created by kevin Ford on 1/2/15.
//  Copyright (c) 2015 kevin Ford. All rights reserved.
//

#import "SQLiteTableViewController.h"

@interface SQLiteTableViewController() {
    NSMutableArray *results;
}

@end

@implementation SQLiteTableViewController

@synthesize TableQueryType;

- (void)viewDidLoad {
    [super viewDidLoad];
    
    results = [[NSMutableArray alloc] init];
    
    [self loadSqlResults];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

-(NSInteger)tableView:(UITableView*)tableView numberOfRowsInSection:(NSInteger)section {
    if (results == nil) {
        return 0;
    } else {
        return [results count];
    }
}

-(UITableViewCell*)tableView:(UITableView*)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    static NSString *simpleTableIdentifier = @"SQLiteReuseIdentifier";
    
    UITableViewCell *cell =  NULL;
    
    cell = [tableView dequeueReusableCellWithIdentifier:simpleTableIdentifier];
    
    if (cell == nil) {
        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:simpleTableIdentifier];
    }
    
    cell.textLabel.text = results[indexPath.item];
    return cell;
}

-(void)loadSqlResults {
    sqliteUtilities* utilities;
    NSError* error;
    
    utilities = [[sqliteUtilities alloc]init];
    
    [utilities openConnection:&error];
    if (error) {
        UIAlertController *alert = [UIAlertController alertControllerWithTitle:@"Error" message:@"EError opening connection" preferredStyle: UIAlertControllerStyleAlert];
        
        UIAlertAction *alertAction = [UIAlertAction actionWithTitle: @"OK"
                                                              style: UIAlertActionStyleDestructive
                                                            handler: NULL];
        
        [alert addAction: alertAction];
        [self presentViewController: alert animated: YES completion: nil];
        
        return;
    }

    if (TableQueryType == (queryType)All) {
        results = [utilities getAllRecords:&error];
    } else {
        results = [utilities getRecordsWith1:&error];
    }
    if (error) {
        UIAlertController *alert = [UIAlertController alertControllerWithTitle:@"Error" message:[NSString stringWithFormat:@"%@%@", @"Error executing select statement: ", error.description] preferredStyle: UIAlertControllerStyleAlert];
        
        UIAlertAction *alertAction = [UIAlertAction actionWithTitle: @"OK"
                                                              style: UIAlertActionStyleDestructive
                                                            handler: NULL];
        
        [alert addAction: alertAction];
        [self presentViewController: alert animated: YES completion: nil];
        
        return;
    }
}

@end