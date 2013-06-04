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
        /// Get the current power supply details.
        /// </summary>
        /// <param name="secs">
        /// Seconds of battery life left. You can pass a NULL here if
        /// you don't care. Will return -1 if we can't determine a
        /// value, or we're not running on a battery.
        /// </param>
        /// <param name="pct">
        /// Percentage of battery life left, between 0 and 100. You can
        /// pass a NULL here if you don't care. Will return -1 if we
        /// can't determine a value, or we're not running on a battery.
        /// </param>
        /// <returns>
        /// The state of the battery (if any).
        /// </returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetPowerInfo", CallingConvention = SDL2_CALL)]
        public static extern SDL2PowerState GetPowerInfo(out int secs, out int pct);

    }
}
