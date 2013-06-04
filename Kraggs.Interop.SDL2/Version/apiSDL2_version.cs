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
        /// Get the version of SDL that is linked against your program.
        /// This function may be called safely at any time, even before SDL_Init().
        /// </summary>
        /// <param name='version'>
        /// SDL2 Version Struct.
        /// </param>
        /// <remarks>
        /// If you are linking to SDL dynamically, then it is possible that the
        /// current version will be different than the version you compiled against.
        /// This function returns the current version, while SDL_VERSION() is a
        /// macro that tells you what version you compiled with.
        /// </remarks>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetVersion", CallingConvention = SDL2_CALL)]
        public static extern void GetVersion(out SDL2Version version);

        /// <summary>
        /// Get the code revision of SDL that is linked against your program.
        /// </summary>
        /// <returns>
        /// Returns an arbitrary string (a hash value) uniquely identifying the
        /// exact revision of the SDL library in use, and is only useful in comparing
        /// against other revisions. It is NOT an incrementing number.
        /// </returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetRevision", CallingConvention = SDL2_CALL)]
        private static extern IntPtr GetRevisionPtr();

        /// <summary>
        /// Get the code revision of SDL that is linked against your program.
        /// </summary>
        /// <returns>
        /// Returns an arbitrary string (a hash value) uniquely identifying the
        /// exact revision of the SDL library in use, and is only useful in comparing
        /// against other revisions. It is NOT an incrementing number.
        /// </returns>
        [DebuggerNonUserCode()]
        public static string GetRevision()
        {
            return Marshal.PtrToStringAnsi(GetRevisionPtr());
        }

        /// <summary>
        /// Get the revision number of SDL that is linked against your program.
        /// </summary>
        /// <returns>
        /// Returns a number uniquely identifying the exact revision of the SDL library in use. It is an incrementing number based on commits to hg.libsdl.org.
        /// </returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetRevisionNumber", CallingConvention = SDL2_CALL)]
        public static extern int GetRevisionNumber();
    }
}
