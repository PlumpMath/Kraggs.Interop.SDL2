#region License
/*
  SDL v2.0.0 C# Interop Library
  Copyright (C) 2013 Jarle Hansen <jarle.hansen@gmail.com>

  This software is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this software.

  Permission is granted to anyone to use this software for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this software must not be misrepresented; you must not
     claim that you wrote the original software. If you use this software
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original software.
  3. This notice may not be removed or altered from any source distribution.
*/
#endregion

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
