//
//  SQLiteUtilities.h
//  PerfTest2-ObjC
//
//  Created by kevin Ford on 1/8/15.
//  Copyright (c) 2015 kevin Ford. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <sqlite3.h>

@interface sqliteUtilities : NSObject

- (void)openConnection:(NSError**)error;
- (void)closeConnection:(NSError**)error;
- (void)deleteFile:(NSError**)error;
- (void)createTable:(NSError**)error;
- (void)addRecord:(NSString*)firstName withLastName:(NSString*)lastName withIndex:(int)index withMisc:(NSString*)misc withError:(NSError**)error;
- (NSMutableArray*)getAllRecords:(NSError**)error;
- (NSMutableArray*)getRecordsWith1:(NSError**) error;

@end
