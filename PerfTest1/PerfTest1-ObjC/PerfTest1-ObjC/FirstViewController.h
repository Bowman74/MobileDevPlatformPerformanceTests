//
//  FirstViewController.h
//  PerfTest1-ObjC
//
//  Created by kevin Ford on 12/2/14.
//  Copyright (c) 2014 kevin Ford. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <WindowsAzureMobileServices/WindowsAzureMobileServices.h>

@interface FirstViewController : UIViewController <UITableViewDelegate, UITableViewDataSource>

@property (strong, nonatomic) IBOutlet UITableView *grdRegistrations;

@end

