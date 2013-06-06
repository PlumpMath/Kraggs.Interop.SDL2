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
    /// <summary>
    /// Enumeration of valid key mods (possibly OR'd together).
    /// </summary>
    public enum SDL2KeyMod : ushort
    {
        None            = 0x0000,
        LeftShift       = 0x0001,
        RightShift      = 0x0002,
        LeftControl     = 0x0040,
        RightControl    = 0x0080,
        Leftalt         = 0x0100,
        RightAlt        = 0x0200,
        LeftGui         = 0x0400,
        RightGui        = 0x0800,
        Numlock         = 0x1000,
        Capslock        = 0x2000,
        Mode            = 0x4000,
        Reserved        = 0x8000,

        Control         = LeftControl | RightControl,
        Shift           = LeftShift | RightShift,
        Alt             = Leftalt | RightAlt,
        Gui             = LeftGui | RightGui,

    }
}
