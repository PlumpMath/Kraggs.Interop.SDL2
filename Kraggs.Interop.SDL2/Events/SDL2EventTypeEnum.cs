using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

// mapp to system intptr
using SDL_Window = System.IntPtr;
using SDL_GLContext = System.IntPtr;
using SDL_Surface = System.IntPtr;

namespace Kraggs.Interop.SDL2
{
    public enum SDL2EventTypeEnum
    {
        /// <summary>
        /// Unused (do not remove)
        /// </summary>
        FirstEvent      = 0,

        /* Application events */
        /// <summary>
        /// User-requested quit
        /// </summary>
        Quit            = 0x100,


        /* These application events have special meaning on iOS, see README.iOS for details */
        /// <summary>
        /// The application is being terminated by the OS
        /// Called on iOS in applicationWillTerminate()
        /// Called on Android in onDestroy()
        /// </summary>
        AppTerminating,

        /// <summary>
        ///  The application is low on memory, free memory if possible.
        ///  Called on iOS in applicationDidReceiveMemoryWarning()
        ///  Called on Android in onLowMemory()
        /// </summary>
        AppLowMemory,

        /// <summary>
        /// The application is about to enter the background
        /// Called on iOS in applicationWillResignActive()
        /// Called on Android in onPause()
        /// </summary>
        AppWillEnterBackground,

        /// <summary>
        /// The application did enter the background and may not get CPU for some time
        /// Called on iOS in applicationDidEnterBackground()
        /// Called on Android in onPause()
        /// </summary>
        AppDidEnterBackground,

        /// <summary>
        /// The application is about to enter the foreground
        /// Called on iOS in applicationWillEnterForeground()
        /// Called on Android in onResume()
        /// </summary>
        AppWillEnterForeground,

        /// <summary>
        /// The application is now interactive
        /// Called on iOS in applicationDidBecomeActive()
        /// Called on Android in onResume()
        /// </summary>
        AppDidEnterForeground,

        /* Window events */
        /// <summary>
        /// Window state change
        /// </summary>
        WindowEvent         = 0x200,

        /// <summary>
        /// System specific event
        /// </summary>
        SysWMEvent,

        /* Keyboard events */
        /// <summary>
        /// Key pressed
        /// </summary>
        KeyDown             = 0x300,
        
        /// <summary>
        /// Key released
        /// </summary>
        KeyUp,

        /// <summary>
        /// Keyboard text editing (composition)
        /// </summary>
        TextEditing,

        /// <summary>
        /// Keyboard text input
        /// </summary>
        TextInput,

        /* Mouse events */
        /// <summary>
        /// Mouse moved
        /// </summary>
        MouseMotion         = 0x400,

        /// <summary>
        /// Mouse button pressed
        /// </summary>
        MouseButtonDown,

        /// <summary>
        /// Mouse button released
        /// </summary>
        MouseButtonUp,

        /// <summary>
        /// Mouse wheel motion
        /// </summary>
        MouseWheel,

        /* Joystick events */
        /// <summary>
        /// Joystick axis motion
        /// </summary>
        JoystickAxisMotion      = 0x600,

        /// <summary>
        /// Joystick trackball motion
        /// </summary>
        JoystickBallMotion,

        /// <summary>
        /// Joystick hat position change
        /// </summary>
        JoystickHatPosition,

        /// <summary>
        /// Joystick button pressed
        /// </summary>
        JoystickButtonDown,

        /// <summary>
        /// Joystick button released
        /// </summary>
        JoystickButtonUp,

        /// <summary>
        /// A new joystick has been inserted into the system
        /// </summary>
        JoystickDeviceAdded,

        /// <summary>
        /// An opened joystick has been removed
        /// </summary>
        JoystickDeviceRemoved,

        /* Game controller events */
        /// <summary>
        /// Game controller axis motion
        /// </summary>
        ControllerAxisMotion        = 0x650,
        /// <summary>
        /// Game controller button pressed
        /// </summary>
        ControllerButtonDown,
        /// <summary>
        /// Game controller button released
        /// </summary>
        ControllerButtonUp,
        /// <summary>
        /// A new Game controller has been inserted into the system
        /// </summary>
        ControllerDeviceAdded,
        /// <summary>
        /// An opened Game controller has been removed
        /// </summary>
        ControllerDeviceRemoved,
        /// <summary>
        /// The controller mapping was updated
        /// </summary>
        ControllerDeviceRemapped,

        /* Touch events */
        FingerDown                  = 0x700,
        FingerUp,
        FingerMotion,

        /* Gesture events */
        DollarGesture               = 0x800,
        DollarRecord,
        MultiGesture,

        /* Clipboard events */
        /// <summary>
        /// The clipboard changed
        /// </summary>
        ClipboardUpdate             = 0x900,

        /* Drag and drop events */
        /// <summary>
        /// The system requests a file open
        /// </summary>
        DropFile                    = 0x1000,

        /// <summary>
        /// Events ::SDL_USEREVENT through ::SDL_LASTEVENT are for your use, and should be allocated with SDL_RegisterEvents()
        /// </summary>
        UserEvent                   = 0x8000,

        /// <summary>
        /// This last event is only for bounding internal arrays
        /// </summary>
        LastEvent                   = 0xFFFF,
    }
}
