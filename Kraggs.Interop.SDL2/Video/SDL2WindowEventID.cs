using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

// mapp to system intptr
using SDL_Window = System.IntPtr;
using SDL_GLContext = System.IntPtr;
using SDL_Surface = System.IntPtr;

namespace Kraggs.Interop.SDL2
{
    public enum SDL2WindowEventID
    {
        /// <summary>
        /// Never used
        /// </summary>
        None,
        /// <summary>
        /// Window has been shown
        /// </summary>
        Shown,
        /// <summary>
        /// Window has been hidden
        /// </summary>
        Hidden,
        /// <summary>
        /// Window has been exposed and should be redrawn
        /// </summary>
        Exposed,
        /// <summary>
        /// Window has been moved to data1, data2
        /// </summary>
        Moved,
        /// <summary>
        /// Window has been resized to data1xdata2
        /// </summary>
        Resized,
        /// <summary>
        /// The window size has changed, either as a result of an API call or through the system or user changing the window size.
        /// </summary>
        SizeChanged,
        /// <summary>
        /// Window has been minimized
        /// </summary>
        Minimized,
        /// <summary>
        /// Window has been maximized
        /// </summary>
        Maximized,
        /// <summary>
        /// Window has been restored to normal size and position
        /// </summary>
        Restored,
        /// <summary>
        /// Window has gained mouse focus
        /// </summary>
        Enter,
        /// <summary>
        /// Window has lost mouse focus
        /// </summary>
        Leave,
        /// <summary>
        /// Window has gained keyboard focus
        /// </summary>
        FocusGained,
        /// <summary>
        /// Window has lost keyboard focus
        /// </summary>
        FocusLost,
        /// <summary>
        /// The window manager requests that the window be closed
        /// </summary>
        Close,
    }
}
