//
//  ViewController.m
//  PerfTest2-ObjC
//
//  Created by kevin Ford on 12/29/14.
//  Copyright (c) 2014 kevin Ford. All rights reserved.
//

#import "MainViewController.h"

@interface MainViewController () {
    NSString *menuItems[ 6 ];
    NSString *dbPath;
    queryType nativationQueryType;
}

@end

@implementation MainViewController


const int menuCleanUp = 0;
const int menuAddRecords = 1;
const int menuDisplayAll = 2;
const int menuDisplayWithWhere = 3;
const int menuSaveLargeFile = 4;
const int menuLoadAndDisplayFile = 5;

- (void)viewDidLoad {
    [super viewDidLoad];
    
    dbPath = NSTemporaryDirectory();
    dbPath = [dbPath stringByAppendingPathComponent:@"testDB.sql3"];
    [[NSUserDefaults standardUserDefaults] setValue:dbPath forKey:@"dbPath"];
    [[NSUserDefaults standardUserDefaults] synchronize];
    
    menuItems[menuCleanUp] = @"Clean up and prepare for tests";
    menuItems[menuAddRecords] = @"Add 1,000 records to SQLite";
    menuItems[menuDisplayAll] = @"Display all records";
    menuItems[menuDisplayWithWhere] = @"Display all records that contain 1";
    menuItems[menuSaveLargeFile] = @"Save large file";
    menuItems[menuLoadAndDisplayFile] = @"Load and display large file";
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    if ([segue.identifier isEqualToString:@"sguToSQLiteTableView"]) {
        SQLiteTableViewController *destViewController = segue.destinationViewController;
        destViewController.TableQueryType = nativationQueryType;
    }
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    return 6;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    static NSString *simpleTableIdentifier = @"MyReuseIdentifier";
    
    UITableViewCell *cell =  NULL;
    
    cell = [tableView dequeueReusableCellWithIdentifier:simpleTableIdentifier];
    
    if (cell == nil) {
        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:simpleTableIdentifier];
    }

    cell.textLabel.text = menuItems[indexPath.item];
    return cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    if (indexPath.row == menuCleanUp) {
        [self cleanUp];
    } else if (indexPath.row == menuAddRecords) {
        [self addRecords];
    } else if (indexPath.row == menuDisplayAll) {
        [self showAllRecords];
    } else if (indexPath.row == menuDisplayWithWhere) {
        [self showRecordsWith];
    } else if (indexPath.row == menuSaveLargeFile) {
        [self saveLargeFile];
    } else if (indexPath.row == menuLoadAndDisplayFile) {
        [self loadAndDisplayFile];
    }
}

- (void)cleanUp {
    NSString* errMsg = @"";
    bool hasError = false;
    sqliteUtilities* sqlUtilities;
    fileUtilities* fUtilities;
    
    sqlUtilities = [[sqliteUtilities alloc]init];
    fUtilities = [[fileUtilities alloc]init];
    
    //Get Temporary Directory
    NSError *error;
    
    [sqlUtilities deleteFile:&error];
    if (error) {
        hasError = true;
        errMsg = @"Problem removing old version of SQLite DB.";
    }
    
    if (!hasError) {
        [sqlUtilities openConnection:&error];
        if (error) {
            hasError = true;
            errMsg = @"Problem removing old version of SQLite DB.";
        }
    }
    
    if (!hasError) {
        [sqlUtilities createTable:&error];
        if (error) {
            hasError = true;
            errMsg = @"Problem creating table.";
        }
    }
    
    [sqlUtilities closeConnection:&error];
    if (error) {
        hasError = true;
        errMsg = [NSString stringWithFormat:@"Problem closing connection: %@", error.description];
    }
    
    
    if (!hasError) {
        [fUtilities deleteFile:&error];
        if (error) {
            hasError = true;
            errMsg = @"Problem deleting old file.";
        }
    }
    
    if (!hasError) {
        [fUtilities createFile:&error];
        if (error) {
            hasError = true;
            errMsg = @"Problem creating new file.";
        }
    }
    
    
    if (!hasError) {
        UIAlertController *alert = [UIAlertController alertControllerWithTitle:@"Cleanup and Prepare for Tests Successful" message:@"Completed Test Setup" preferredStyle: UIAlertControllerStyleAlert];
        
        UIAlertAction *alertAction = [UIAlertAction actionWithTitle: @"OK"
                                                              style: UIAlertActionStyleDestructive
                                                            handler: NULL];
        
        [alert addAction: alertAction];
        [self presentViewController: alert animated: YES completion: nil];
    } else {
        UIAlertController *alert = [UIAlertController alertControllerWithTitle:@"Cleanup and Prepare for Tests Error" message:[NSString stringWithFormat:@"%@%@", @"Error: ", errMsg] preferredStyle: UIAlertControllerStyleAlert];
        
        UIAlertAction *alertAction = [UIAlertAction actionWithTitle: @"OK"
                                                              style: UIAlertActionStyleDestructive
                                                            handler: NULL];
        
        [alert addAction: alertAction];
        [self presentViewController: alert animated: YES completion: nil];
    }
}

- (void)addRecords {
    sqliteUtilities* utilities;
    NSError* error;

    utilities = [[sqliteUtilities alloc]init];
    
    [utilities openConnection:&error];
    if (error) {
        UIAlertController *alert = [UIAlertController alertControllerWithTitle:@"Error" message:@"Error opening connection" preferredStyle: UIAlertControllerStyleAlert];
        
        UIAlertAction *alertAction = [UIAlertAction actionWithTitle: @"OK"
                                                              style: UIAlertActionStyleDestructive
                                                            handler: NULL];
        
        [alert addAction: alertAction];
        [self presentViewController: alert animated: YES completion: nil];

        return;
    }
    
    for (int i = 0; i <= 999; i++) {
        [utilities addRecord:@"test" withLastName:@"person" withIndex:i withMisc:@"12345678901234567890123456789012345678901234567890" withError:&error];
        
        if (error) {
            UIAlertController *alert = [UIAlertController alertControllerWithTitle:@"Error" message:error.description preferredStyle: UIAlertControllerStyleAlert];
            
            UIAlertAction *alertAction = [UIAlertAction actionWithTitle: @"OK"
                                                                  style: UIAlertActionStyleDestructive
                                                                handler: NULL];
            
            [alert addAction: alertAction];
            [self presentViewController: alert animated: YES completion: nil];
            
            [utilities closeConnection:&error];
            return;
        }
    }
    
    [utilities closeConnection:&error];
    if (error) {
        UIAlertController *alert = [UIAlertController alertControllerWithTitle:@"Error" message:@"Error closing connection" preferredStyle: UIAlertControllerStyleAlert];
        
        UIAlertAction *alertAction = [UIAlertAction actionWithTitle: @"OK"
                                                              style: UIAlertActionStyleDestructive
                                                            handler: NULL];
        
        [alert addAction: alertAction];
        [self presentViewController: alert animated: YES completion: nil];
        
        return;
    }

    UIAlertController *alert = [UIAlertController alertControllerWithTitle:@"Success" message:@"All records written to database" preferredStyle: UIAlertControllerStyleAlert];
    
    UIAlertAction *alertAction = [UIAlertAction actionWithTitle: @"OK"
                                                          style: UIAlertActionStyleDestructive
                                                        handler: NULL];
    
    [alert addAction: alertAction];
    [self presentViewController: alert animated: YES completion: nil];
}

- (void)showAllRecords {
    nativationQueryType = (queryType)All;
    [self performSegueWithIdentifier: @"sguToSQLiteTableView"
                              sender: self];
}

- (void)showRecordsWith {
    nativationQueryType = (queryType)Contain1;
    [self performSegueWithIdentifier: @"sguToSQLiteTableView"
                              sender: self];
}

- (void)saveLargeFile {
    fileUtilities* utilities;
    NSError* error;
    
    utilities = [[fileUtilities alloc]init];
    
    [utilities openFile:&error];
    if (error) {
        UIAlertController *alert = [UIAlertController alertControllerWithTitle:@"Error" message:@"Error opening file" preferredStyle: UIAlertControllerStyleAlert];
        
        UIAlertAction *alertAction = [UIAlertAction actionWithTitle: @"OK"
                                                              style: UIAlertActionStyleDestructive
                                                            handler: NULL];
        
        [alert addAction: alertAction];
        [self presentViewController: alert animated: YES completion: nil];
        
        return;
    }
    
    for (int i = 0; i <= 999; i++) {
        NSString *myString = [NSString stringWithFormat:@"Writing line to file at index: %d\r\n", i];
        const char *utfString = [myString UTF8String];
        NSData *textLine = [NSData dataWithBytes: utfString length: strlen
                         (utfString)];
        [utilities writeLineToFile:&error withTextToWrite:textLine];
        
        if (error) {
            UIAlertController *alert = [UIAlertController alertControllerWithTitle:@"Error" message:error.description preferredStyle: UIAlertControllerStyleAlert];
            
            UIAlertAction *alertAction = [UIAlertAction actionWithTitle: @"OK"
                                                                  style: UIAlertActionStyleDestructive
                                                                handler: NULL];
            
            [alert addAction: alertAction];
            [self presentViewController: alert animated: YES completion: nil];
            
            [utilities closeFile:&error];
            return;
        }
    }
    
    [utilities closeFile:&error];
    if (error) {
        UIAlertController *alert = [UIAlertController alertControllerWithTitle:@"Error" message:@"Error closing file" preferredStyle: UIAlertControllerStyleAlert];
        
        UIAlertAction *alertAction = [UIAlertAction actionWithTitle: @"OK"
                                                              style: UIAlertActionStyleDestructive
                                                            handler: NULL];
        
        [alert addAction: alertAction];
        [self presentViewController: alert animated: YES completion: nil];
        
        return;
    }
    
    UIAlertController *alert = [UIAlertController alertControllerWithTitle:@"Success" message:@"All lines written to file" preferredStyle: UIAlertControllerStyleAlert];
    
    UIAlertAction *alertAction = [UIAlertAction actionWithTitle: @"OK"
                                                          style: UIAlertActionStyleDestructive
                                                        handler: NULL];
    
    [alert addAction: alertAction];
    [self presentViewController: alert animated: YES completion: nil];
}

- (void)loadAndDisplayFile {
    [self performSegueWithIdentifier: @"sguToFileTableView"
                              sender: self];
}

@end