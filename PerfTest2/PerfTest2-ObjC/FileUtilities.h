//
//  FileUtilities.h
//  PerfTest2-ObjC
//
//  Created by kevin Ford on 1/8/15.
//  Copyright (c) 2015 kevin Ford. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface fileUtilities : NSObject

- (void)openFile:(NSError**)error;
- (void)closeFile:(NSError**)error;
- (void)deleteFile:(NSError**)error;
- (void)createFile:(NSError**)error;
- (void)writeLineToFile:(NSError**)error withTextToWrite:(NSData*)textToWrite;
- (NSData*)readFileContents:(NSError**)error;

@end
