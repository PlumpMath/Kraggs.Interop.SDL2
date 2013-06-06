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
    /// The SDL keysym structure, used in key events.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL2KeySym
    {
        /// <summary>
        /// SDL physical key code - see ::SDL_Scancode for details
        /// </summary>
        public SDL2ScanCode ScanCode;
        /// <summary>
        /// SDL virtual key code - see ::SDL_Keycode for details
        /// </summary>
        public SDL2KeyCode Sym;

        /// <summary>
        /// current key modifiers
        /// </summary>
        public SDL2KeyMod Mod;

        /// <summary>
        /// deprecated use SDL_TextInputEvent instead
        /// </summary>
        [Obsolete("deprecated use SDL_TextInputEvent instead")]
        public uint Unicode;
    }
}
