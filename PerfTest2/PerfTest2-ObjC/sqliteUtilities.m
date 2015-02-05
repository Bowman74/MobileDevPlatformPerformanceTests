//
//  SQLiteUtilities.m
//  PerfTest2-ObjC
//
//  Created by kevin Ford on 1/8/15.
//  Copyright (c) 2015 kevin Ford. All rights reserved.
//

#import "sqliteUtilities.h"

@interface sqliteUtilities () {
    NSString* dbPath;
    sqlite3* dbConn;
}
@end

@implementation sqliteUtilities

- (id)init {
    self = [super init];
    if (self) {
        dbConn = nil;
        dbPath = NSTemporaryDirectory();
        dbPath = [dbPath stringByAppendingPathComponent:@"testDB.sql3"];
    }
    return self;
}

- (void)openConnection:(NSError**)error {
    *error = nil;

    if (dbConn != nil) {
        [self closeConnection:error];
    }

    if (*error == nil) {
    int result = sqlite3_open([dbPath UTF8String], &dbConn);
    
    
        if (result != SQLITE_OK) {
            NSMutableDictionary *errorDetail = [NSMutableDictionary dictionary];
            [errorDetail setValue:@"Could not open connection" forKey:NSLocalizedDescriptionKey];
            *error = [NSError errorWithDomain:@"testDomain" code:101 userInfo:errorDetail];
        }
    }
}

- (void)closeConnection:(NSError**)error {
    *error = nil;

    if (dbConn == nil) {
        NSMutableDictionary *errorDetail = [NSMutableDictionary dictionary];
        [errorDetail setValue:@"Connection not open to close" forKey:NSLocalizedDescriptionKey];
        *error = [NSError errorWithDomain:@"testDomain" code:101 userInfo:errorDetail];
    } else {
        int result = sqlite3_close(dbConn);
        if (result != SQLITE_OK) {
            NSMutableDictionary *errorDetail = [NSMutableDictionary dictionary];
            [errorDetail setValue:@"Could not close connection" forKey:NSLocalizedDescriptionKey];
            *error = [NSError errorWithDomain:@"testDomain" code:101 userInfo:errorDetail];
            
        }
        dbConn = nil;
    }
}

- (void)deleteFile:(NSError**)error {
    *error = nil;

    if([[NSFileManager defaultManager] fileExistsAtPath:dbPath] == YES) {
        [[NSFileManager defaultManager] removeItemAtPath:dbPath error: error];
    }
}

- (void)createTable:(NSError**)error {
    *error = nil;
    
    if (dbConn == nil) {
        [self openConnection:error];
    }
    
    if (*error == nil) {
        const char* createTableQuery = "CREATE TABLE IF NOT EXISTS testTable (id INTEGER PRIMARY KEY AUTOINCREMENT, firstName varchar(30), lastName varchar(30), misc TEXT)";
        
        char *errInfo ;
        int result = sqlite3_exec(dbConn, createTableQuery, nil, nil, &errInfo);
        
        if (result != SQLITE_OK) {
            NSMutableDictionary *errorDetail = [NSMutableDictionary dictionary];
            [errorDetail setValue:@"Could not create table" forKey:NSLocalizedDescriptionKey];
            *error = [NSError errorWithDomain:@"testDomain" code:101 userInfo:errorDetail];
        }
    }
}

- (void)addRecord:(NSString*)firstName withLastName:(NSString*)lastName withIndex:(int)index withMisc:(NSString*)misc withError:(NSError**)error {
    NSString *sqlStatement = NULL;
    char *errInfo;
    *error = nil;

    if (dbConn == nil) {
        [self openConnection:error];
        return;
    }
    
    sqlStatement = [NSString stringWithFormat:@"%@%@%@%@%d%@%@%@", @"INSERT INTO testTable (firstName, lastName, misc) VALUES ('", firstName, @"', '", lastName, index, @"', '", misc, @"')"];
    
    int result = sqlite3_exec(dbConn, [sqlStatement UTF8String], nil, nil, &errInfo);
    
    if (result != SQLITE_OK) {
        NSMutableDictionary *errorDetail = [NSMutableDictionary dictionary];
        [errorDetail setValue:[NSString stringWithFormat:@"%@%s", @"Error writing record to database: ", errInfo] forKey:NSLocalizedDescriptionKey];
        *error = [NSError errorWithDomain:@"testDomain" code:101 userInfo:errorDetail];
    }
}

- (NSMutableArray*)getAllRecords:(NSError**) error {
    NSString *sqlStatement = NULL;
    NSMutableArray *results;
    sqlite3_stmt *sqlResult;
    char *errInfo;
    *error = nil;
    
    if (dbConn == nil) {
        [self openConnection:error];
        return nil;
    }
    
    sqlStatement = @"SELECT * FROM testTable";
    results = [[NSMutableArray alloc] init];

    int result = sqlite3_exec(dbConn, [sqlStatement UTF8String], nil, nil, &errInfo);
    
    result = sqlite3_prepare_v2(dbConn, [sqlStatement UTF8String], -1, &sqlResult, nil);
    
    if (result == SQLITE_OK) {
        while (sqlite3_step(sqlResult)==SQLITE_ROW) {
            NSString* firstName = [NSString stringWithFormat:@"%s", (char*)sqlite3_column_text(sqlResult, 1)];
            NSString* lastName = [NSString stringWithFormat:@"%s", (char*)sqlite3_column_text(sqlResult, 2)];
            NSString* fullName = [NSString stringWithFormat:@"%@ %@", firstName, lastName];
        
            [results addObject:fullName];
        }
        sqlite3_finalize(sqlResult);
        return results;
    } else {
        NSMutableDictionary *errorDetail = [NSMutableDictionary dictionary];
        [errorDetail setValue:@"Error loading records" forKey:NSLocalizedDescriptionKey];
        *error = [NSError errorWithDomain:@"testDomain" code:101 userInfo:errorDetail];
        return nil;
    }
}

- (NSMutableArray*)getRecordsWith1:(NSError**) error {
    NSString* sqlStatement = NULL;
    NSMutableArray* results;
    sqlite3_stmt* sqlResult;
    char* errInfo;
    *error = nil;

    if (dbConn == nil) {
        [self openConnection:error];
        return nil;
    }
    
    sqlStatement = @"SELECT * FROM testTable WHERE lastName LIKE '%1%'";
    results = [[NSMutableArray alloc] init];
    
    int result = sqlite3_exec(dbConn, [sqlStatement UTF8String], nil, nil, &errInfo);
    
    result = sqlite3_prepare_v2(dbConn, [sqlStatement UTF8String], -1, &sqlResult, nil);
    
    if (result == SQLITE_OK) {
        while (sqlite3_step(sqlResult)==SQLITE_ROW) {
            NSString* firstName = [NSString stringWithFormat:@"%s", (char*)sqlite3_column_text(sqlResult, 1)];
            NSString* lastName = [NSString stringWithFormat:@"%s", (char*)sqlite3_column_text(sqlResult, 2)];
            NSString* fullName = [NSString stringWithFormat:@"%@ %@", firstName, lastName];
            
            [results addObject:fullName];
        }
        sqlite3_finalize(sqlResult);
        return results;
    } else {
        NSMutableDictionary *errorDetail = [NSMutableDictionary dictionary];
        [errorDetail setValue:@"Error loading records" forKey:NSLocalizedDescriptionKey];
        *error = [NSError errorWithDomain:@"testDomain" code:101 userInfo:errorDetail];
        return nil;
    }
}
@end