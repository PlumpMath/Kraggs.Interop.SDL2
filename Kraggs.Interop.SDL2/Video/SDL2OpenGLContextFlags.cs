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
    /// OpenGL Context Flags
    /// </summary>
    [Flags]
    public enum SDL2OpenGLContextFlags
    {
        DebugFlag               = 0x0001,
        ForwardCompatibleFlag   = 0x0002,
        RobustAccessFlag        = 0x0004,
        ResetIsolationFlag      = 0x0008,
    }
}
