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
        /// Gets the name of the platform.
        /// </summary>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetPlatform", CallingConvention = SDL2_CALL)]
        private static extern IntPtr GetPlatformPtr();

        /// <summary>
        /// Gets the name of the platform.
        /// </summary>
        /// <returns></returns>
        [DebuggerNonUserCode()]
        public static string GetPlatform()
        {
            return Marshal.PtrToStringAnsi(GetPlatformPtr());
        }

    }
}
