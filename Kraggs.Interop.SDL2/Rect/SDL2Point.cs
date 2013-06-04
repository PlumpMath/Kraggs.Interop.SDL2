using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

// mapp to system intptr
using SDL_Window = System.IntPtr;
using SDL_GLContext = System.IntPtr;
using SDL_Surface = System.IntPtr;

namespace Kraggs.Interop.SDL2
{
    /// <summary>
    /// The structure that defines a point
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL2Point
    {
        public int x;
        public int y;
    }
}
