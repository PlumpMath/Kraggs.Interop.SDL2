using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

// mapp to system intptr
using SDL_Window = System.IntPtr;
using SDL_GLContext = System.IntPtr;
using SDL_Surface = System.IntPtr;
using SDL_Cursor = System.IntPtr;
using SDL_SysWMmsg = System.IntPtr;

namespace Kraggs.Interop.SDL2
{
    [StructLayout(LayoutKind.Explicit)]
    public struct SDL2Event
    {
        /// <summary>
        /// Event type, shared with all events
        /// </summary>
        [FieldOffset(0)]
        public SDL2EventTypeEnum EventType;

        /* Structures in the union */
        /// <summary>
        /// Common event data 
        /// </summary>
        [FieldOffset(0)]
        public SDL2CommonEvent Common;
        /// <summary>
        /// Window event data 
        /// </summary>
        [FieldOffset(0)]
        public SDL2WindowEvent Window;

        /// <summary>
        /// Keyboard event data
        /// </summary>
        //[FieldOffset(0)]
        //public SDL2KeyboardEvent Key;

        /// <summary>
        /// Text editing event data 
        /// </summary>
        [FieldOffset(0)]
        public SDL2TextEditingEvent Edit;

        /// <summary>
        /// Text input event data
        /// </summary>
        [FieldOffset(0)]
        public SDL2TextInputEvent Text;

        /// <summary>
        /// Mouse motion event data
        /// </summary>
        [FieldOffset(0)]
        public SDL2MouseMotionEvent Motion;
        /// <summary>
        /// Mouse button event data
        /// </summary>
        [FieldOffset(0)]
        public SDL2MouseButtonEvent Button;
        /// <summary>
        /// Mouse wheel event data
        /// </summary>
        [FieldOffset(0)]
        public SDL2MouseWheelEvent Wheel;

        /*        
        SDL_JoyAxisEvent jaxis;         // Joystick axis event data 
        SDL_JoyBallEvent jball;         // Joystick ball event data 
        SDL_JoyHatEvent jhat;           // Joystick hat event data 
        SDL_JoyButtonEvent jbutton;     // Joystick button event data 
        SDL_JoyDeviceEvent jdevice;     // Joystick device change event data 
        SDL_ControllerAxisEvent caxis;      // Game Controller axis event data 
        SDL_ControllerButtonEvent cbutton;  // Game Controller button event data 
        SDL_ControllerDeviceEvent cdevice;  // Game Controller device event data 
        SDL_TouchFingerEvent tfinger;   // Touch finger event data 
        SDL_MultiGestureEvent mgesture; // Gesture event data 
        SDL_DollarGestureEvent dgesture; // Gesture event data 
        SDL_DropEvent drop;             // Drag and drop event data 
        */

        /// <summary>
        /// Quit request event data 
        /// </summary>
        [FieldOffset(0)]
        public SDL2QuitEvent Quit;
        /// <summary>
        /// Custom event data
        /// </summary>
        [FieldOffset(0)]
        public SDL2UserEvent User;
        /// <summary>
        /// System dependent window event data
        /// </summary>
        [FieldOffset(0)]
        public SDL2SysWMEvent SysWM;

        /// <summary>
        /// padding to force correct struct size.
        /// </summary>
        [FieldOffset(52)]
        private int padding;
    }

    /// <summary>
    /// Fields shared by every event
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL2CommonEvent
    {        
        public SDL2EventTypeEnum EventType;
        public uint Timestamp;
    }

    /// <summary>
    /// Window state change event data (event.window.*)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL2WindowEvent
    {
        public SDL2EventTypeEnum EventType;
        public uint Timestamp;

        /// <summary>
        /// The associated window
        /// </summary>
        public uint WindowID;

        /// <summary>
        /// ::SDL_WindowEventID
        /// </summary>
        public byte Event;

        private byte Padding1;
        private byte Padding2;
        private byte Padding3;

        /// <summary>
        /// event dependent data
        /// </summary>
        public int Data1;
        /// <summary>
        /// event dependent data
        /// </summary>
        public int Data2;
    }

    
    /// <summary>
    /// Keyboard button event structure (event.key.*)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL2KeyboardEvent
    {
        public SDL2EventTypeEnum EventType;
        public uint Timestamp;

        /// <summary>
        /// The window with keyboard focus, if any
        /// </summary>
        public uint WindowID;

        /// <summary>
        /// ::SDL_PRESSED or ::SDL_RELEASED
        /// </summary>
        public byte State;

        /// <summary>
        /// Non-zero if this is a key repeat
        /// </summary>
        public byte Repeat;

        private byte Padding2;
        private byte Padding3;

        [Obsolete("Need implementation of SDL_keysym.")]
        public int KeySym;
        //public SDL2KeySym KeySym;
    }
    

    /// <summary>
    /// Keyboard text editing event structure (event.edit.*)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL2TextEditingEvent
    {
        public SDL2EventTypeEnum EventType;
        public uint Timestamp;

        /// <summary>
        /// The window with keyboard focus, if any
        /// </summary>
        public uint WindowID;

        /// <summary>
        /// The editing text
        /// </summary>
        public fixed char Text[32];

        /// <summary>
        /// The start cursor of selected editing text
        /// </summary>
        public int Start;
        /// <summary>
        /// The length of selected editing text
        /// </summary>
        public int Length;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL2TextInputEvent
    {
        public SDL2EventTypeEnum EventType;
        public uint Timestamp;

        /// <summary>
        /// The window with keyboard focus, if any
        /// </summary>
        public uint WindowID;

        /// <summary>
        /// The input text
        /// </summary>
        public fixed char Text[32];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL2MouseMotionEvent
    {
        public SDL2EventTypeEnum EventType;
        public uint Timestamp;

        /// <summary>
        /// The window with mouse focus, if any
        /// </summary>
        public uint WindowID;
        /// <summary>
        /// The mouse instance id, or SDL_TOUCH_MOUSEID
        /// </summary>
        public uint Which;
        /// <summary>
        /// The current button state
        /// </summary>
        public uint State;
        /// <summary>
        /// X coordinate, relative to window
        /// </summary>
        public int X;
        /// <summary>
        /// Y coordinate, relative to window
        /// </summary>
        public int Y;
        /// <summary>
        /// The relative motion in the X direction
        /// </summary>
        public int XRelative;
        /// <summary>
        /// The relative motion in the Y direction
        /// </summary>
        public int YRelative;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct SDL2MouseButtonEvent
    {
        public SDL2EventTypeEnum EventType;
        public uint Timestamp;

        /// <summary>
        /// The window with mouse focus, if any
        /// </summary>
        public uint WindowID;
        /// <summary>
        /// The mouse instance id, or SDL_TOUCH_MOUSEID
        /// </summary>
        public uint Which;
        /// <summary>
        /// The mouse button index
        /// </summary>
        public byte Button;
        /// <summary>
        /// ::SDL_PRESSED or ::SDL_RELEASED
        /// </summary>
        public byte State;

        private byte Padding1;
        private byte Padding2;

        /// <summary>
        /// X coordinate, relative to window
        /// </summary>
        public int X;
        /// <summary>
        /// Y coordinate, relative to window
        /// </summary>
        public int Y;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct SDL2MouseWheelEvent
    {
        public SDL2EventTypeEnum EventType;
        public uint Timestamp;

        /// <summary>
        /// The window with mouse focus, if any
        /// </summary>
        public uint WindowID;
        /// <summary>
        /// The mouse instance id, or SDL_TOUCH_MOUSEID
        /// </summary>
        public uint Which;
        /// <summary>
        /// The amount scrolled horizontally
        /// </summary>
        public int X;
        /// <summary>
        /// The amount scrolled vertically
        /// </summary>
        public int Y;
    }

    /* A lot more events here */

    /// <summary>
    /// The "quit requested" event
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL2QuitEvent
    {
        public SDL2EventTypeEnum EventType;
        public uint Timestamp;
    }

    /// <summary>
    /// OS Specific event
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL2OSEvent
    {
        public SDL2EventTypeEnum EventType;
        public uint Timestamp;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL2UserEvent
    {
        /// <summary>
        /// ::SDL_USEREVENT through ::SDL_NUMEVENTS-1
        /// </summary>
        public SDL2EventTypeEnum EventType;
        public uint Timestamp;

        /// <summary>
        /// The associated window if any
        /// </summary>
        public uint WindowID;
        /// <summary>
        /// User defined event code
        /// </summary>
        public int Code;

        /// <summary>
        /// User defined data pointer
        /// </summary>
        public IntPtr Data1;
        /// <summary>
        /// User defined data pointer
        /// </summary>
        public IntPtr Data2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL2SysWMEvent
    {
        /// <summary>
        /// ::SDL_SYSWMEVENT
        /// </summary>
        public SDL2EventTypeEnum EventType;
        public uint Timestamp;
        /// <summary>
        /// driver dependent data, defined in SDL_syswm.h
        /// </summary>
        private SDL_SysWMmsg msg;
    }

    /*
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL2ExampleEvent
    {
        public SDL2EventTypeEnum EventType;
        public uint Timestamp;
    }
     */

}
