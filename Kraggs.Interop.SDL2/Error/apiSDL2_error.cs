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
        /// Sets the SDL error.
        /// </summary>
        /// <param name="fmt"></param>
        /// <returns>unconditionally returns -1.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetError", CallingConvention = SDL2_CALL)]
        public static extern int SetError(string fmt);

        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetError", CallingConvention = SDL2_CALL)]
        private static extern IntPtr GetErrorPtr();
        /// <summary>
        /// Returns the error as string.
        /// </summary>
        /// <returns></returns>
        [DebuggerNonUserCode()]
        public static string GetError()
        {
            return Marshal.PtrToStringAnsi(GetErrorPtr());
        }

        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_ClearError", CallingConvention = SDL2_CALL)]
        public static extern void ClearError();

        //[DllImport(SDL2_LIBRARY, EntryPoint = "SDL_Error", CallingConvention = SDL2_CALL)]
        //internal static extern void Error(SDL2ErrorCode code);

    }
}
