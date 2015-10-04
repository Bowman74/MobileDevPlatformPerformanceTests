//
//  SQLiteTableViewController.h
//  PerfTest2-ObjC
//
//  Created by kevin Ford on 1/2/15.
//  Copyright (c) 2015 kevin Ford. All rights reserved.
//
#import <UIKit/UIKit.h>
#import <sqlite3.h>
#import "queryType.h"
#import "sqliteUtilities.h"

@interface SQLiteTableViewController : UITableViewController <UITableViewDelegate, UITableViewDataSource>

@property (nonatomic, assign, readwrite) queryType TableQueryType;

@end