﻿using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

// mapp to system intptr
using SDL_Window = System.IntPtr;
using SDL_GLContext = System.IntPtr;
using SDL_Surface = System.IntPtr;

namespace Kraggs.Interop.SDL2
{
    //TODO: Determine if this should be 8bit or 32 bit. GetMouseState vs SDL2MouseButtonEvent
    [Flags]
    public enum SDL2Button
    {
        Left    = 1,
        Middle  = 2,
        Right   = 4,
        X1      = 8,
        X2      = 16,
    }
}
