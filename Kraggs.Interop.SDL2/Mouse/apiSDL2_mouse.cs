using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

// mapp to system intptr
using SDL_Window = System.IntPtr;
using SDL_GLContext = System.IntPtr;
using SDL_Surface = System.IntPtr;
using SDL_Cursor = System.IntPtr;

namespace Kraggs.Interop.SDL2
{
    partial class apiSDL2
    {
        /// <summary>
        /// Get the window which currently has mouse focus.
        /// </summary>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetMouseFocus", CallingConvention = SDL2_CALL)]
        public static extern SDL_Window GetMouseFocus();

        /// <summary>
        /// Retrieve the current state of the mouse.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>The current button state is returned as a button bitmask, which can be tested using the SDL_BUTTON(X) macros, and x and y are set to the mouse cursor position relative to the focus window for the currently selected mouse.  You can pass NULL for either x or y.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetMouseState", CallingConvention = SDL2_CALL)]
        public static extern SDL2Button GetMouseState(out int x, out int y);

        /// <summary>
        /// Retrieve the relative state of the mouse.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>The current button state is returned as a button bitmask, which can be tested using the SDL_BUTTON(X) macros, and x and y are set to the mouse deltas since the last call to SDL_GetRelativeMouseState().</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetRelativeMouseState", CallingConvention = SDL2_CALL)]
        public static extern uint GetRelativeMouseState(out int x, out int y);

        /// <summary>
        /// Moves the mouse to the given position within the window.
        /// </summary>
        /// <param name="window">The window to move the mouse into, or NULL for the current mouse focus</param>
        /// <param name="x">The x coordinate within the window</param>
        /// <param name="y">The y coordinate within the window</param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_WarpMouseInWindow", CallingConvention = SDL2_CALL)]
        public static extern void WarpMouseInWindow(SDL_Window window, int x, int y);

        /// <summary>
        /// Set relative mouse mode.
        /// </summary>
        /// <param name="enabled">Whether or not to enable relative mode</param>
        /// <returns>0 on success, or -1 if relative mode is not supported.</returns>
        /// <remarks>
        /// While the mouse is in relative mode, the cursor is hidden, and the driver will try to report continuous motion in the current window.
        /// Only relative motion events will be delivered, the mouse position will not change.
        /// 
        /// NOTE: This function will flush any pending mouse motion.
        /// </remarks>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetRelativeMouseMode", CallingConvention = SDL2_CALL)]
        public static extern int SetRelativeMouseMode([MarshalAs(UnmanagedType.Bool)] bool enabled);

        /// <summary>
        /// Query whether relative mouse mode is enabled.
        /// </summary>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetRelativeMouseMode", CallingConvention = SDL2_CALL)]
        [return: MarshalAs(UnmanagedType.Bool)] 
        public static extern bool GetRelativeMouseMode();

        /// <summary>
        /// Create a cursor, using the specified bitmap data and mask (in MSB format).
        /// The cursor width must be a multiple of 8 bits.
        /// The cursor is created in black and white according to the following:
        /// data       mask         resulting pixel on screen
        /// 0           1           White
        /// 1           1           Black
        /// 0           0           Transparent
        /// 1           0           Inverted color if possible, black if not.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mask"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="hot_x"></param>
        /// <param name="hot_y"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_CreateCursor", CallingConvention = SDL2_CALL)]
        public static extern SDL_Cursor CreateCursor(IntPtr data, IntPtr mask, int w, int h, int hot_x, int hot_y);

        /// <summary>
        /// Create a color cursor.
        /// </summary>
        /// <param name="surface"></param>
        /// <param name="hot_x"></param>
        /// <param name="hot_y"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_CreateColorCursor", CallingConvention = SDL2_CALL)]
        public static extern SDL_Cursor CreateColorCursor(SDL_Surface surface, int hot_x, int hot_y);

        /// <summary>
        /// Create a system cursor.
        /// </summary>
        /// <param name="cursor"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_CreateSystemCursor", CallingConvention = SDL2_CALL)]
        public static extern SDL_Cursor CreateSystemCursor(SDL2SystemCursorEnum cursor);


        /// <summary>
        /// Set the active cursor.
        /// </summary>
        /// <param name="cursor"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetCursor", CallingConvention = SDL2_CALL)]
        public static extern void SetCursor(SDL_Cursor cursor);

        /// <summary>
        /// Return the active cursor.
        /// </summary>
        /// <param name="cursor"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetCursor", CallingConvention = SDL2_CALL)]
        public static extern SDL_Cursor GetCursor();

        /// <summary>
        /// Return the default cursor.
        /// </summary>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetDefaultCursor", CallingConvention = SDL2_CALL)]
        public static extern SDL_Cursor GetDefaultCursor();

        /// <summary>
        /// Frees a cursor created with SDL_CreateCursor().
        /// </summary>
        /// <param name="cursor"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_FreeCursor", CallingConvention = SDL2_CALL)]
        public static extern void FreeCursor(SDL_Cursor cursor);

        /// <summary>
        /// Toggle whether or not the cursor is shown.
        /// </summary>
        /// <param name="toggle">1 to show the cursor, 0 to hide it, -1 to query the current state.</param>
        /// <returns>1 if the cursor is shown, or 0 if the cursor is hidden.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_ShowCursor", CallingConvention = SDL2_CALL)]
        public static extern int ShowCursor(int toggle);


    }
}
