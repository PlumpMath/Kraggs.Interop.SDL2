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
    public enum SDL2SystemCursorEnum
    {
        /// <summary>
        /// Arrow
        /// </summary>
        Arrow,
        /// <summary>
        /// I-beam
        /// </summary>
        IBeam,     
        /// <summary>
        /// Wait
        /// </summary>
        Wait,      
        /// <summary>
        /// Crosshair
        /// </summary>
        Crosshair, /* Crosshair */
        /// <summary>
        /// Small wait cursor (or Wait if not available)
        /// </summary>
        WaitArrow, /* Small wait cursor (or Wait if not available) */
        /// <summary>
        /// Double arrow pointing northwest and southeast
        /// </summary>
        SizeNorthWestSouthEast,  /* Double arrow pointing northwest and southeast */
        /// <summary>
        /// Double arrow pointing northeast and southwest 
        /// </summary>
        SizeNorthEastSouthWest,  /* Double arrow pointing northeast and southwest */
        /// <summary>
        /// Double arrow pointing west and east
        /// </summary>
        SizeWestEast,    /* Double arrow pointing west and east */
        /// <summary>
        /// Double arrow pointing north and south
        /// </summary>
        SizeNorthSouth,    /* Double arrow pointing north and south */
        /// <summary>
        /// Four pointed arrow pointing north, south, east, and west
        /// </summary>
        SizeAll,   /* Four pointed arrow pointing north, south, east, and west */
        /// <summary>
        /// Slashed circle or crossbones
        /// </summary>
        NO,        /* Slashed circle or crossbones */
        /// <summary>
        /// Hand
        /// </summary>
        HAND,      /* Hand */

        SDL_NUM_SYSTEM_CURSORS

    }
}
