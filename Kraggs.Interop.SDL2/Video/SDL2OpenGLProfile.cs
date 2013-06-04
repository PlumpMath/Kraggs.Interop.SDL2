using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

// mapp to system intptr
using SDL_Window = System.IntPtr;
using SDL_GLContext = System.IntPtr;
using SDL_Surface = System.IntPtr;

namespace Kraggs.Interop.SDL2
{
    public enum SDL2OpenGLProfile
    {
        Core            = 0x0001,
        Compatibility   = 0x0002,
        ES              = 0x0004,
    }
}
