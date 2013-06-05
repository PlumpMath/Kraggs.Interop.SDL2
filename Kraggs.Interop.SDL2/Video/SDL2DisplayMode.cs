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
    /// The structure that defines a display mode
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL2DisplayMode
    {
        /// <summary>
        /// pixel format
        /// </summary>
        public uint PixelFormat;
        /// <summary>
        /// width
        /// </summary>
        public int Width;
        /// <summary>
        /// height
        /// </summary>
        public int Height;
        /// <summary>
        /// refresh rate (or zero for unspecified)
        /// </summary>
        public int RefreshRate;
        /// <summary>
        /// driver-specific data, initialize to 0
        /// </summary>
        private IntPtr DriverData;
    }
}
