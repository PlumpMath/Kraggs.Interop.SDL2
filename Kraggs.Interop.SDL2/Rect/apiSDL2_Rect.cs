using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

// mapp to system intptr
using SDL_Window = System.IntPtr;
using SDL_GLContext = System.IntPtr;
using SDL_Surface = System.IntPtr;

namespace Kraggs.Interop.SDL2
{
    partial class apiSDL2
    {
        /*
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_HasIntersection", CallingConvention = SDL2_CALL)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RectHasIntersection(ref SDL2Rect A, ref SDL2Rect B);
        */
    }
}
