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
