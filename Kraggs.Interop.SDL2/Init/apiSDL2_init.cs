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
    partial class apiSDL2
    {
        /// <summary>
        /// This function initializes  the subsystems specified by \c flags Unless the ::SDL_INIT_NOPARACHUTE flag is set, it will install cleanup signal handlers for some commonly ignored fatal signals (like SIGSEGV).
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_Init", CallingConvention = SDL2_CALL)]
        public static extern int Init(SDL2SubSystem flags);

        /// <summary>
        /// This function initializes specific SDL subsystems
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_InitSubSystem", CallingConvention = SDL2_CALL)]
        public static extern int InitSubSystem(SDL2SubSystem flags);

        /// <summary>
        /// This function cleans up specific SDL subsystems
        /// </summary>
        /// <param name="flags"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_QuitSubSystem", CallingConvention = SDL2_CALL)]
        public static extern void QuitSubSystem(SDL2SubSystem flags);

        /// <summary>
        /// This function returns a mask of the specified subsystems which have previously been initialized.
        /// </summary>
        /// <param name="flags"></param>
        /// <remarks>If \c flags is 0, it returns a mask of all initialized subsystems.</remarks>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_WasInit", CallingConvention = SDL2_CALL)]
        public static extern SDL2SubSystem WasInit(SDL2SubSystem flags);

        /// <summary>
        /// This function cleans up all initialized subsystems. You should call it upon all exit conditions.
        /// </summary>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_Quit", CallingConvention = SDL2_CALL)]
        public static extern void Quit();

    }
}
