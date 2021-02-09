#import <Foundation/Foundation.h>
#import <ApplicationServices/ApplicationServices.h>
//#import <unistd.h>

extern "C"{
    void SetMousePosition(int x, int y);
    void Click(int x, int y);
    CGPoint GetMousePosition();
}

void Click(int x, int y)
{
    CGEventRef down =
    CGEventCreateMouseEvent(
                            NULL,
                            kCGEventLeftMouseDown,
                            CGPointMake(x, y),
                            kCGMouseButtonLeft
                            );

    CGEventRef up =
    CGEventCreateMouseEvent(
                            NULL,
                            kCGEventLeftMouseUp,
                            CGPointMake(x, y),
                            kCGMouseButtonLeft
                            );

    CGEventPost(kCGHIDEventTap, down);
    CGEventPost(kCGHIDEventTap, up);
    
    CFRelease(up);
    CFRelease(down);
}

CGPoint GetMousePosition()
{
    CGEventRef event = CGEventCreate(NULL);
    CGPoint cursor = CGEventGetLocation(event);
    CFRelease(event);
    return cursor;
}

void SetMousePosition(int x, int y){
    CGEventRef move =
    CGEventCreateMouseEvent(
                            NULL,
                            kCGEventMouseMoved,
                            CGPointMake(x, y),
                            kCGMouseButtonLeft
                            );
    
    CGEventPost(kCGHIDEventTap, move);
    CFRelease(move);
}
