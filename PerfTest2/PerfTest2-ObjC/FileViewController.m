//
//  FileViewController.m
//  PerfTest2-ObjC
//
//  Created by kevin Ford on 1/10/15.
//  Copyright (c) 2015 kevin Ford. All rights reserved.
//

#import "FileViewController.h"

@interface FileViewController() {
    NSArray *results;
}

@end

@implementation FileViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    [self loadFileResults];
}

-(NSInteger)tableView:(UITableView*)tableView numberOfRowsInSection:(NSInteger)section {
    if (results == nil) {
        return 0;
    } else {
        return [results count];
    }
}

-(UITableViewCell*)tableView:(UITableView*)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    static NSString *simpleTableIdentifier = @"FileReuseIdentifier";
    
    UITableViewCell *cell =  NULL;
    
    cell = [tableView dequeueReusableCellWithIdentifier:simpleTableIdentifier];
    
    if (cell == nil) {
        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:simpleTableIdentifier];
    }
    
    cell.textLabel.text = results[indexPath.item];
    return cell;
}


-(void) loadFileResults {
    fileUtilities *utilities;
    NSError *error;
    
    utilities = [[fileUtilities alloc]init];
    
    [utilities openFile:&error];
    
    if (!error) {
        results = [utilities readFileContents:&error];
        [utilities closeFile:&error];
    }
}

@end
