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
using SDL_Keycode = System.Int32;

namespace Kraggs.Interop.SDL2
{
    partial class apiSDL2
    {
        /// <summary>
        /// Get the window which currently has keyboard focus.
        /// </summary>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetKeyboardFocus", CallingConvention = SDL2_CALL)]
        public static extern SDL_Window GetKeyboardFocus();

        /// <summary>
        /// Get a snapshot of the current state of the keyboard.
        /// </summary>
        /// <example>
        /// <code>
        /// const Uint8 *state = SDL_GetKeyboardState(NULL);
        /// if ( state[SDL_SCANCODE_RETURN] )   {
        ///     printf("<RETURN> is pressed.\n");
        /// }
        /// </code>
        /// </example>
        /// <param name="NumKeys">numkeys if non-NULL, receives the length of the returned array.</param>
        /// <returns>An array of key states. Indexes into this array are obtained by using ::SDL_Scancode values.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetKeyboardState", CallingConvention = SDL2_CALL)]
        public static extern IntPtr GetKeyboardState(out int NumKeys);

        /// <summary>
        /// Get the current key modifier state for the keyboard.
        /// </summary>
        /// <returns></returns>
        //TODO: SDL2KeyMod short or int???
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetModState", CallingConvention = SDL2_CALL)]
        public static extern SDL2KeyMod GetModState();

        /// <summary>
        /// Set the current key modifier state for the keyboard.
        /// NOTE: This does not change the keyboard state, only the key modifier flags.
        /// </summary>
        /// <param name="mod"></param>
        //TODO: SDL2KeyMod short or int???
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetModState", CallingConvention = SDL2_CALL)]
        public static extern void SetModState(SDL2KeyMod mod);

        /// <summary>
        /// Get the key code corresponding to the given scancode according to the current keyboard layout.
        /// </summary>
        /// <param name="scancode"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetKeyFromScancode", CallingConvention = SDL2_CALL)]
        public static extern SDL2KeyCode GetKeyFromScancode(SDL2ScanCode scancode);

        /// <summary>
        /// Get the scancode corresponding to the given key code according to the current keyboard layout.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetScancodeFromKey", CallingConvention = SDL2_CALL)]
        public static extern SDL2ScanCode GetScancodeFromKey(SDL2KeyCode key);

        /// <summary>
        /// Get a human-readable name for a scancode.
        /// </summary>
        /// <param name="scancode"></param>
        /// <returns>A pointer to the name for the scancode. If the scancode doesn't have a name, this function returns an empty string ("")</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetScancodeName", CallingConvention = SDL2_CALL)]
        private static extern IntPtr GetScancodeNamePtr(SDL2ScanCode scancode);

        [DebuggerNonUserCode()]
        public static string GetScancodeName(SDL2ScanCode scancode)
        {
            var ptr = GetScancodeNamePtr(scancode);
            if (ptr != IntPtr.Zero)
                return Marshal.PtrToStringAuto(ptr);

            return string.Empty;
        }

        /// <summary>
        /// Get a scancode from a human-readable name
        /// </summary>
        /// <param name="scancodename"></param>
        /// <returns>scancode, or SDL_SCANCODE_UNKNOWN if the name wasn't recognized</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetScancodeFromName", CallingConvention = SDL2_CALL)]
        public static extern SDL2ScanCode GetScancodeFromName(string scancodename);

        /// <summary>
        /// Get a human-readable name for a key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>A pointer to a UTF-8 string that stays valid at least until the next call to this function. If you need it around any longer, you must copy it.  If the key doesn't have a name, this function returns an empty string ("").</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetKeyName", CallingConvention = SDL2_CALL)]
        public static extern IntPtr GetKeyNamePtr(SDL2KeyCode key);

        /// <summary>
        /// Get a human-readable name for a key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>A UTF-8 string with name. If the key doesn't have a name, this function returns an empty string ("").</returns>
        [DebuggerNonUserCode()]
        public static string GetKeyName(SDL2KeyCode key)
        {
            var ptr = GetKeyNamePtr(key);
            if (ptr != IntPtr.Zero)
                return Marshal.PtrToStringAuto(ptr);

            return string.Empty;
        }

        /// <summary>
        /// Get a key code from a human-readable name
        /// </summary>
        /// <param name="keyname"></param>
        /// <returns>key code, or SDLK_UNKNOWN if the name wasn't recognized</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetKeyFromName", CallingConvention = SDL2_CALL)]
        public static extern SDL2KeyCode GetKeyFromName(string keyname);

        /// <summary>
        /// Start accepting Unicode text input events.
        /// This function will show the on-screen keyboard if supported.
        /// </summary>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_StartTextInput", CallingConvention = SDL2_CALL)]
        public static extern void StartTextInput();

        /// <summary>
        /// Return whether or not Unicode text input events are enabled.
        /// </summary>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_IsTextInputActive", CallingConvention = SDL2_CALL)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsTextInputActive();

        /// <summary>
        /// Stop receiving any text input events.
        /// This function will hide the on-screen keyboard if supported.
        /// </summary>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_StopTextInput", CallingConvention = SDL2_CALL)]
        public static extern void StopTextInput();

        /// <summary>
        /// Set the rectangle used to type Unicode text inputs.
        /// This is used as a hint for IME and on-screen keyboard placement.
        /// </summary>
        /// <param name="rect"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetTextInputRect", CallingConvention = SDL2_CALL)]
        public static extern void SetTextInputRect(ref SDL2Rect rect);

        /// <summary>
        /// Returns whether the platform has some screen keyboard support.
        /// NOTE: Not all screen keyboard functions are supported on all platforms.
        /// </summary>
        /// <returns>SDL_TRUE if some keyboard support is available else SDL_FALSE.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_HasScreenKeyboardSupport", CallingConvention = SDL2_CALL)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HasScreenKeyboardSupport();

        /// <summary>
        /// Returns whether the screen keyboard is shown for given window.
        /// </summary>
        /// <param name="window">The window for which screen keyboard should be queried.</param>
        /// <returns>SDL_TRUE if screen keyboard is shown else SDL_FALSE.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_IsScreenKeyboardShown", CallingConvention = SDL2_CALL)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsScreenKeyboardShown(SDL_Window window);

    }
}
