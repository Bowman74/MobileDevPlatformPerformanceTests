//
//  FileUtilities.m
//  PerfTest2-ObjC
//
//  Created by kevin Ford on 1/8/15.
//  Copyright (c) 2015 kevin Ford. All rights reserved.
//

#import "fileUtilities.h"

@interface fileUtilities () {
    NSString *filePath;
    NSFileHandle *fileHandle;
}
@end

@implementation fileUtilities


- (id)init {
    self = [super init];
    if (self) {
        filePath = NSTemporaryDirectory();
        filePath = [filePath stringByAppendingPathComponent:@"testFile.txt"];
        fileHandle = nil;
    }
    return self;
}

- (void)openFile:(NSError**)error {
    *error = nil;

    fileHandle = [NSFileHandle fileHandleForUpdatingAtPath: filePath];
    
    if (fileHandle == nil) {
        NSMutableDictionary *errorDetail = [NSMutableDictionary dictionary];
        [errorDetail setValue:@"Not able to open file" forKey:NSLocalizedDescriptionKey];
        *error = [NSError errorWithDomain:@"testDomain" code:101 userInfo:errorDetail];
    }
}

- (void)closeFile:(NSError**)error {
    if (fileHandle != nil) {
        [fileHandle closeFile];
        fileHandle = nil;
    }
}

- (void)deleteFile:(NSError**)error {
    *error = nil;

    if([[NSFileManager defaultManager] fileExistsAtPath:filePath] == YES) {
        [[NSFileManager defaultManager] removeItemAtPath:filePath error: error];
    }
}

- (void)createFile:(NSError**)error {
    NSFileManager *filemgr;
    *error = nil;

    filemgr = [NSFileManager defaultManager];
    
    if([[NSFileManager defaultManager] fileExistsAtPath:filePath] == NO) {
        [[NSFileManager defaultManager] createFileAtPath:filePath contents:nil attributes:nil];
    } else {
        NSMutableDictionary *errorDetail = [NSMutableDictionary dictionary];
        [errorDetail setValue:@"File already exists at path" forKey:NSLocalizedDescriptionKey];
        *error = [NSError errorWithDomain:@"testDomain" code:101 userInfo:errorDetail];
    }
}

- (void)writeLineToFile:(NSError**)error withTextToWrite:(NSData*)textToWrite {
    *error = nil;

    if (fileHandle == nil) {
        [self openFile:error];
    }
    
    if (*error == nil) {
        [fileHandle seekToEndOfFile];
        [fileHandle writeData:textToWrite];
    }
}

- (NSArray*)readFileContents:(NSError**)error {
    *error = nil;

    if (fileHandle == nil) {
        [self openFile:error];
    }
    
    if (*error == nil) {
        [fileHandle seekToFileOffset: 0];
        NSData* fileContents = [fileHandle readDataToEndOfFile];
        NSString *fileString = [[NSString alloc] initWithData:fileContents encoding:NSUTF8StringEncoding];
        return [fileString componentsSeparatedByString:@"\r\n"];
        
    } else {
        return nil;
    }
}
@end