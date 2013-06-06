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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kraggs.Interop.SDL2
{
    /// <summary>
    /// The type used to identify a window
    /// </summary>
    [Flags]
    public enum SDL2WindowFlags : uint
    {
        /// <summary>
        /// fullscreen window
        /// </summary>
		Fullscreen          = 0x00000001,         /**< fullscreen window */
        /// <summary>
        /// window usable with OpenGL context
        /// </summary>
		OpenGL              = 0x00000002,             /**< window usable with OpenGL $ */
        
		Shown               = 0x00000004,              /**< window is visible */
		Hidden              = 0x00000008,             /**< window is not visible */
		BorderLess          = 0x00000010,         /**< no window decoration */
		Resizeable          = 0x00000020,          /**< window can be resized */
		Minimized           = 0x00000040,          /**< window is minimized */
		Maximized           = 0x00000080,          /**< window is maximized */
		InputGrabbed        = 0x00000100,      /**< window has grabbed input f$ */
		InputFocus          = 0x00000200,        /**< window has input focus */
		MouseFocus          = 0x00000400,        /**< window has mouse focus */
        FullscreenDesktop   = (Fullscreen | 0x00001000),
		Foreign             = 0x00000800,           

    }
}
