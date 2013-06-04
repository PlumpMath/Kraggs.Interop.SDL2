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
        /// Get the number of video drivers compiled into SDL
        /// </summary>
        /// <returns>
        /// The number video drivers.
        /// </returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetNumVideoDrivers", CallingConvention = SDL2_CALL)]
        public static extern int GetNumVideoDrivers();

        /// <summary>
        /// Get the name of a built in video driver.
        /// </summary>
        /// <returns>
        /// The name of the video driver.
        /// </returns>
        /// <param name='index'>
        /// Index.
        /// </param>
        /// <remarks>
        /// The video drivers are presented in the order in which they are normally checked during initialization.
        /// </remarks>
        //[DllImport(SDL2_LIBRARY, EntryPoint="SDL_GetVideoDriver", CallingConvention=SDL2_CALL)]
        //public static extern string GetVideoDriver(int index);
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetVideoDriver", CallingConvention = SDL2_CALL)]
        private static extern IntPtr GetVideoDriverPtr(int index);

        /// <summary>
        /// Get the name of a built in video driver.
        /// </summary>
        /// <returns>
        /// The name of the video driver.
        /// </returns>
        /// <param name='index'>
        /// Index.
        /// </param>
        /// <remarks>
        /// The video drivers are presented in the order in which they are normally checked during initialization.
        /// </remarks>
        [DebuggerNonUserCode()]
        public static string GetVideoDriver(int index)
        {
            return Marshal.PtrToStringAnsi(GetVideoDriverPtr(index));
        }

        /// <summary>
        /// Initialize the video subsystem, optionally specifying a video driver.
        /// </summary>
        /// <param name="DriverName">Initialize a specific driver by name, or NULL for the default video driver.</param>
        /// <returns>0 on success, -1 on error</returns>
        /// <remarks>This function initializes the video subsystem; setting up a connection to the window manager, etc, and determines the available display modes and pixel formats, but does not initialize a window or graphics mode.</remarks>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_VideoInit", CallingConvention = SDL2_CALL)]
        public static extern int VideoInit(string DriverName);

        /// <summary>
        /// Shuts down the video subsystem.
        /// This function closes all windows, and restores the original video mode.
        /// </summary>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_VideoQuit", CallingConvention = SDL2_CALL)]
        public static extern void VideoQuit();

        //[DllImport(SDL2_LIBRARY, EntryPoint="SDL_GetCurrentVideoDriver", CallingConvention=SDL2_CALL)]
        //public static extern string GetCurrentVideoDriver();

        /// <summary>
        /// Returns the name of the currently initialized video driver.
        /// </summary>
        /// <returns>The name of the current video driver or NULL if no driver has been initialized</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetCurrentVideoDriver", CallingConvention = SDL2_CALL)]
        private static extern IntPtr GetCurrentVideoDriverPtr();

        /// <summary>
        /// Returns the name of the currently initialized video driver.
        /// </summary>
        /// <returns>The name of the current video driver or NULL if no driver has been initialized</returns>
        [DebuggerNonUserCode()]
        public static string GetCurrentVideoDriver()
        {
            return Marshal.PtrToStringAnsi(GetCurrentVideoDriverPtr());
        }

        /// <summary>
        /// Returns the number of available video displays.
        /// </summary>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetNumVideoDisplays", CallingConvention = SDL2_CALL)]
        public static extern int GetNumVideoDisplays();

        
        //[DllImport(SDL2_LIBRARY, EntryPoint="SDL_GetDisplayName", CallingConvention=SDL2_CALL)]
        //public static extern string GetDisplayName(int DisplayIndex);
        /// <summary>
        /// Get the name of a display in UTF-8 encoding
        /// </summary>
        /// <param name="DisplayIndex"></param>
        /// <returns>The name of a display, or NULL for an invalid display index.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetDisplayName", CallingConvention = SDL2_CALL)]       
        private static extern IntPtr GetDisplayNamePtr(int DisplayIndex);
        /// <summary>
        /// Get the name of a display in UTF-8 encoding
        /// </summary>
        /// <param name="DisplayIndex"></param>
        /// <returns>The name of a display, or NULL for an invalid display index.</returns>
        [DebuggerNonUserCode()]
        public static string GetDisplayName(int DisplayIndex)
        {
            return Marshal.PtrToStringAnsi(GetDisplayNamePtr(DisplayIndex));
        }

        /// <summary>
        /// Get the desktop area represented by a display, with the primary display located at 0,0
        /// </summary>
        /// <param name="DisplayIndex"></param>
        /// <param name="rect"></param>
        /// <returns>0 on success, or -1 if the index is out of range.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint="SDL_GetDisplayBounds", CallingConvention=SDL2_CALL)]
        public static extern string GetDisplayBounds(int DisplayIndex, out SDL2Rect rect);

        /// <summary>
        /// Returns the number of available display modes.
        /// </summary>
        /// <param name="DisplayIndex"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetNumDisplayModes", CallingConvention = SDL2_CALL)]
        public static extern int GetNumDisplayModes(int DisplayIndex);

        /// <summary>
        /// Fill in information about a specific display mode.
        /// </summary>
        /// <param name="DisplayIndex"></param>
        /// <param name="ModeIndex"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        /// <remarks>
        /// <list type="The display modes are sorted in this priority:">
        ///     <item>bits per pixel -> more colors to fewer colors</item>
        ///     <item>width -> largest to smallest</item>
        ///     <item>height -> largest to smallest</item>
        ///     <item>refresh rate -> highest to lowest</item>
        /// </list>
        /// </remarks>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetDisplayMode", CallingConvention = SDL2_CALL)]
        public static extern int GetDisplayMode(int DisplayIndex, int ModeIndex, ref SDL2DisplayMode mode);

        /// <summary>
        /// Fill in information about the desktop display mode.
        /// </summary>
        /// <param name="DisplayIndex"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetDesktopDisplayMode", CallingConvention = SDL2_CALL)]
        public static extern int GetDesktopDisplayMode(int DisplayIndex, ref SDL2DisplayMode mode);

        /// <summary>
        /// Fill in information about the current display mode.
        /// </summary>
        /// <param name="DisplayIndex"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetCurrentDisplayMode", CallingConvention = SDL2_CALL)]
        public static extern int GetCurrentDisplayMode(int DisplayIndex, ref SDL2DisplayMode mode);

        /// <summary>
        /// Get the closest match to the requested display mode.
        /// </summary>
        /// <param name="DisplayIndex">The index of display from which mode should be queried.</param>
        /// <param name="mode">The desired display mode</param>
        /// <param name="closest">A pointer to a display mode to be filled in with the closest match of the available display modes.</param>
        /// <returns>The passed in value \c closest, or NULL if no matching video mode was available.</returns>
        /// <remarks>
        /// The available display modes are scanned, and \c closest is filled in with the closest mode matching the requested mode and returned.  The mode format and refresh_rate default to the desktop mode if they are 0.  The modes are scanned with size being first priority, format being second priority, and finally checking the refresh_rate.  If all the available modes are too small, then NULL is returned.
        /// </remarks>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetClosestDisplayMode", CallingConvention = SDL2_CALL)]
        public static extern SDL2DisplayMode GetClosestDisplayMode(int DisplayIndex, ref SDL2DisplayMode mode, out SDL2DisplayMode closest);

        /// <summary>
        /// Get the display index associated with a window.
        /// </summary>
        /// <param name="window"></param>
        /// <returns>the display index of the display containing the center of the window, or -1 on error.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetWindowDisplayIndex", CallingConvention = SDL2_CALL)]
        public static extern int GetWindowDisplayIndex(SDL_Window window);

        /// <summary>
        /// Set the display mode used when a fullscreen window is visible.
        /// By default the window's dimensions and the desktop format and refresh rate are used.
        /// </summary>
        /// <param name="window">The window for which the display mode should be set.</param>
        /// <param name="mode">The mode to use, or NULL for the default mode.</param>
        /// <returns>0 on success, or -1 if setting the display mode failed.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetWindowDisplayMode", CallingConvention = SDL2_CALL)]
        public static extern int SetWindowDisplayMode(SDL_Window window, ref SDL2DisplayMode mode);

        /// <summary>
        /// Fill in information about the display mode used when a fullscreen window is visible.
        /// </summary>
        /// <param name="window"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetWindowDisplayMode", CallingConvention = SDL2_CALL)]
        public static extern int GetWindowDisplayMode(SDL_Window window, out SDL2DisplayMode mode);

        /// <summary>
        /// Get the pixel format associated with the window.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetWindowPixelFormat", CallingConvention = SDL2_CALL)]
        public static extern UInt32 GetWindowPixelFormat(SDL_Window window);

        /// <summary>
        /// Create a window with the specified position, dimensions, and flags.
        /// </summary>
        /// <param name="Title">The title of the window, in UTF-8 encoding.</param>
        /// <param name="x">The x position of the window, ::SDL_WINDOWPOS_CENTERED, or ::SDL_WINDOWPOS_UNDEFINED.</param>
        /// <param name="y">The y position of the window, ::SDL_WINDOWPOS_CENTERED, or ::SDL_WINDOWPOS_UNDEFINED.</param>
        /// <param name="w">The width of the window.</param>
        /// <param name="h">The height of the window.</param>
        /// <param name="flags">
        /// The flags for the window, a mask of any of the following:
        /// <list type="bullet">
        ///     <item>Fullscreen</item>
        ///     <item>Shown</item>
        ///     <item>Resizable</item>
        ///     <item>Minimized</item>
        ///     <item>OpenGL</item>
        ///     <item>BorderLess</item>
        ///     <item>Maximized</item>
        ///     <item>InputGrabbed</item>
        /// </list>
        /// </param>
        /// <returns>The id of the window created, or zero if window creation failed.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_CreateWindow", CallingConvention = SDL2_CALL)]
        public static extern SDL_Window CreateWindow(string Title, int x, int y, int w, int h, SDL2WindowFlags flags);

        /// <summary>
        /// Create an SDL window from an existing native window.
        /// </summary>
        /// <param name="data">A pointer to driver-dependent window creation data</param>
        /// <returns>The id of the window created, or zero if window creation failed.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_CreateWindowFrom", CallingConvention = SDL2_CALL)]
        public static extern SDL_Window CreateWindowFrom(IntPtr data);

        /// <summary>
        /// Get the numeric ID of a window, for logging purposes.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetWindowID", CallingConvention = SDL2_CALL)]
        public static extern UInt32 GetWindowID(SDL_Window window);

        /// <summary>
        /// Get a window from a stored ID, or NULL if it doesn't exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetWindowFromID", CallingConvention = SDL2_CALL)]
        public static extern SDL_Window GetWindowFromID(UInt32 id);

        /// <summary>
        /// Get the window flags.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetWindowFlags", CallingConvention = SDL2_CALL)]
        public static extern SDL2WindowFlags GetWindowFlags(SDL_Window window);

        /// <summary>
        /// Set the title of a window, in UTF-8 format.
        /// </summary>
        /// <param name="window"></param>
        /// <param name="Title"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetWindowTitle", CallingConvention = SDL2_CALL)]
        public static extern void SetWindowTitle(SDL_Window window, string Title);

        //[DllImport(SDL2_LIBRARY, EntryPoint="SDL_GetWindowTitle", CallingConvention=SDL2_CALL)]
        //public static extern string GetWindowTitle(SDL_Window window);

        /// <summary>
        /// Get the title of a window, in UTF-8 format.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetWindowTitle", CallingConvention = SDL2_CALL)]
        private static extern IntPtr GetWindowTitlePtr(SDL_Window window);

        /// <summary>
        /// Get the title of a window, in UTF-8 format.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        [DebuggerNonUserCode()]
        public static string GetWindowTitle(SDL_Window window)
        {
            // for some reason I get glibc invalid free or something at end of program if I use
            // return type string directly.
            // but if I ask for ptr and call Marshal.PtrToStringAnsi manually it works...
            // it seems 'extern string GetWin..' actually frees the string returned later on..
            var ptr = GetWindowTitlePtr(window);
            return Marshal.PtrToStringAnsi(ptr);
        }

        /// <summary>
        /// Set the icon for a window.
        /// </summary>
        /// <param name="window">The window for which the icon should be set.</param>
        /// <param name="icon">The icon for the window.</param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetWindowIcon", CallingConvention = SDL2_CALL)]
        public static extern void SetWindowIcon(SDL_Window window, ref SDL_Surface icon);

        /// <summary>
        /// Associate an arbitrary named pointer with a window.
        /// </summary>
        /// <param name="window">The window to associate with the pointer.</param>
        /// <param name="name">The name of the pointer.</param>
        /// <param name="UserData">The associated pointer.</param>
        /// <returns>The previous value associated with 'name'</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetWindowData", CallingConvention = SDL2_CALL)]
        public static extern IntPtr SetWindowData(SDL_Window window, string name, IntPtr UserData);

        /// <summary>
        /// Retrieve the data pointer associated with a window.
        /// </summary>
        /// <param name="window">The window to query</param>
        /// <param name="name">The name of the pointer.</param>
        /// <returns>The value associated with 'name'</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetWindowData", CallingConvention = SDL2_CALL)]
        public static extern IntPtr GetWindowData(SDL_Window window, string name);

        /// <summary>
        /// Set the position of a window.
        /// </summary>
        /// <param name="window">The window to reposition.</param>
        /// <param name="x">The x coordinate of the window, ::SDL_WINDOWPOS_CENTERED, or ::SDL_WINDOWPOS_UNDEFINED.</param>
        /// <param name="y">The y coordinate of the window, ::SDL_WINDOWPOS_CENTERED, or ::SDL_WINDOWPOS_UNDEFINED.</param>
        /// <remarks>The window coordinate origin is the upper left of the display.</remarks>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetWindowPosition", CallingConvention = SDL2_CALL)]
        public static extern void SetWindowPosition(SDL_Window window, int x, int y);

        /// <summary>
        /// Get the position of a window.
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="x">Pointer to variable for storing the x position, may be NULL</param>
        /// <param name="y">Pointer to variable for storing the y position, may be NULL</param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetWindowPosition", CallingConvention = SDL2_CALL)]
        public static extern void GetWindowPosition(SDL_Window window, out int x, out int y);

        /// <summary>
        /// Set the size of a window's client area.
        /// </summary>
        /// <param name="window">The window to resize.</param>
        /// <param name="w">The width of the window, must be >0</param>
        /// <param name="h">The height of the window, must be >0</param>
        /// <remarks>
        /// You can't change the size of a fullscreen window, it automatically matches the size of the display mode.
        /// </remarks>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetWindowSize", CallingConvention = SDL2_CALL)]
        public static extern void SetWindowSize(SDL_Window window, int w, int h);

        /// <summary>
        /// Get the size of a window's client area.
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="w">Pointer to variable for storing the width, may be NULL</param>
        /// <param name="h">Pointer to variable for storing the height, may be NULL</param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetWindowSize", CallingConvention = SDL2_CALL)]
        public static extern void GetWindowSize(SDL_Window window, out int w, out int h);

        /// <summary>
        /// Set the minimum size of a window's client area.
        /// </summary>
        /// <param name="window">The window to set a new minimum size.</param>
        /// <param name="min_w">The minimum width of the window, must be >0</param>
        /// <param name="min_h">The minimum width of the window, must be >0</param>
        /// <remarks>You can't change the minimum size of a fullscreen window, it automatically matches the size of the display mode.</remarks>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetWindowMinimumSize", CallingConvention = SDL2_CALL)]
        public static extern void SetWindowMinimumSize(SDL_Window window, int min_w, int min_h);

        /// <summary>
        /// Get the minimum size of a window's client area.
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="min_w">Pointer to variable for storing the minimum width, may be NULL</param>
        /// <param name="min_h">Pointer to variable for storing the minimum height, may be NULL</param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetWindowMinimumSize", CallingConvention = SDL2_CALL)]
        public static extern void GetWindowMinimumSize(SDL_Window window, out int min_w, out int min_h);

        /// <summary>
        /// Set the maximum size of a window's client area.
        /// </summary>
        /// <param name="window">The window to set a new maximum size.</param>
        /// <param name="max_w">The maximum width of the window, must be >0</param>
        /// <param name="max_h">The maximum height of the window, must be >0</param>
        /// <remarks>You can't change the maximum size of a fullscreen window, it automatically matches the size of the display mode.</remarks>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetWindowMaximumSize", CallingConvention = SDL2_CALL)]
        public static extern void SetWindowMaximumSize(SDL_Window window, int max_w, int max_h);

        /// <summary>
        /// Get the maximum size of a window's client area.
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="max_w">Pointer to variable for storing the maximum width, may be NULL</param>
        /// <param name="max_h">Pointer to variable for storing the maximum height, may be NULL</param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetWindowMaximumSize", CallingConvention = SDL2_CALL)]
        public static extern void GetWindowMaximumSize(SDL_Window window, out int max_w, out int max_h);

        /// <summary>
        /// Set the border state of a window.
        /// This will add or remove the window's SDL_WINDOW_BORDERLESS flag and add or remove the border from the actual window. This is a no-op if the window's border already matches the requested state.
        /// </summary>
        /// <param name="window">The window of which to change the border state.</param>
        /// <param name="bordered">SDL_FALSE to remove border, SDL_TRUE to add border.</param>
        /// <remarks>You can't change the border state of a fullscreen window.</remarks>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetWindowBordered", CallingConvention = SDL2_CALL)]
        public static extern void SetWindowBordered(SDL_Window window, int bordered);

        /// <summary>
        /// Show a window.
        /// </summary>
        /// <param name="window"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_ShowWindow", CallingConvention = SDL2_CALL)]
        public static extern void ShowWindow(SDL_Window window);

        /// <summary>
        /// Hide a window.
        /// </summary>
        /// <param name="window"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_HideWindow", CallingConvention = SDL2_CALL)]
        public static extern void HideWindow(SDL_Window window);

        /// <summary>
        /// Raise a window above other windows and set the input focus.
        /// </summary>
        /// <param name="window"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_RaiseWindow", CallingConvention = SDL2_CALL)]
        public static extern void RaiseWindow(SDL_Window window);

        /// <summary>
        /// Make a window as large as possible.
        /// </summary>
        /// <param name="window"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_MaximizeWindow", CallingConvention = SDL2_CALL)]
        public static extern void MaximizeWindow(SDL_Window window);

        /// <summary>
        /// Minimize a window to an iconic representation.
        /// </summary>
        /// <param name="window"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_MinimizeWindow", CallingConvention = SDL2_CALL)]
        public static extern void MinimizeWindow(SDL_Window window);

        /// <summary>
        /// Restore the size and position of a minimized or maximized window.
        /// </summary>
        /// <param name="window"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_RestoreWindow", CallingConvention = SDL2_CALL)]
        public static extern void RestoreWindow(SDL_Window window);

        /// <summary>
        /// Set a window's fullscreen state.
        /// </summary>
        /// <param name="window"></param>
        /// <param name="flags"></param>
        /// <returns>0 on success, or -1 if setting the display mode failed.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetWindowFullscreen", CallingConvention = SDL2_CALL)]
        public static extern int SetWindowFullscreen(SDL_Window window, SDL2WindowFlags flags);

        /// <summary>
        /// Get the SDL surface associated with the window.
        /// A new surface will be created with the optimal format for the window, if necessary. This surface will be freed when the window is destroyed.
        /// </summary>
        /// <param name="window"></param>
        /// <returns>The window's framebuffer surface, or NULL on error.</returns>
        /// <remarks>You may not combine this with 3D or the rendering API on this window.</remarks>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetWindowSurface", CallingConvention = SDL2_CALL)]
        public static extern SDL_Surface GetWindowSurface(SDL_Window window);

        /// <summary>
        /// Copy the window surface to the screen.
        /// </summary>
        /// <param name="window"></param>
        /// <returns>0 on success, or -1 on error.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_UpdateWindowSurface", CallingConvention = SDL2_CALL)]
        public static extern int UpdateWindowSurface(SDL_Window window);

        /// <summary>
        /// Copy a number of rectangles on the window surface to the screen.
        /// </summary>
        /// <param name="window"></param>
        /// <param name="rects"></param>
        /// <param name="numrects"></param>
        /// <returns>0 on success, or -1 on error.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint="SDL_UpdateWindowSurfaceRects", CallingConvention=SDL2_CALL)]
        public static extern int UpdateWindowSurfaceRects(ref SDL_Window window, SDL2Rect[] rects, int numrects);

        /// <summary>
        /// Set a window's input grab mode.
        /// </summary>
        /// <param name="window">The window for which the input grab mode should be set.</param>
        /// <param name="grabbed">This is SDL_TRUE to grab input, and SDL_FALSE to release input.</param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetWindowGrab", CallingConvention = SDL2_CALL)]
        public static extern void SetWindowGrab(SDL_Window window, int grabbed);

        /// <summary>
        /// Get a window's input grab mode.
        /// </summary>
        /// <param name="window"></param>
        /// <returns>This returns SDL_TRUE if input is grabbed, and SDL_FALSE otherwise.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetWindowGrab", CallingConvention = SDL2_CALL)]
        public static extern int GetWindowGrab(SDL_Window window);

        /// <summary>
        /// Set the brightness (gamma correction) for a window.
        /// </summary>
        /// <param name="window"></param>
        /// <param name="brightness"></param>
        /// <returns>0 on success, or -1 if setting the brightness isn't supported.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetWindowBrightness", CallingConvention = SDL2_CALL)]
        public static extern int SetWindowBrightness(SDL_Window window, float brightness);

        /// <summary>
        /// Get the brightness (gamma correction) for a window.
        /// </summary>
        /// <param name="window">The last brightness value passed to SDL_SetWindowBrightness()</param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetWindowBrightness", CallingConvention = SDL2_CALL)]
        public static extern float GetWindowBrightness(SDL_Window window);

        /// <summary>
        /// Set the gamma ramp for a window.
        /// </summary>
        /// <param name="window">The window for which the gamma ramp should be set.</param>
        /// <param name="red">The translation table for the red channel, or NULL.</param>
        /// <param name="green">The translation table for the green channel, or NULL.</param>
        /// <param name="blue">The translation table for the blue channel, or NULL.</param>
        /// <returns>0 on success, or -1 if gamma ramps are unsupported.</returns>
        /// <remarks>
        /// Set the gamma translation table for the red, green, and blue channels of the video hardware.  Each table is an array of 256 16-bit quantities, representing a mapping between the input and output for that channel. The input is the index into the array, and the output is the 16-bit gamma value at that index, scaled to the output color precision.
        /// </remarks>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetWindowGammaRamp", CallingConvention = SDL2_CALL)]
        public static extern int SetWindowGammaRamp(SDL_Window window, ref float red, ref float green, ref float blue);

        /// <summary>
        /// Get the gamma ramp for a window.
        /// </summary>
        /// <param name="window">The window from which the gamma ramp should be queried.</param>
        /// <param name="red">A pointer to a 256 element array of 16-bit quantities to hold the translation table for the red channel, or NULL.</param>
        /// <param name="green">A pointer to a 256 element array of 16-bit quantities to hold the translation table for the green channel, or NULL.</param>
        /// <param name="blue">A pointer to a 256 element array of 16-bit quantities to hold the translation table for the blue channel, or NULL.</param>
        /// <returns>0 on success, or -1 if gamma ramps are unsupported.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetWindowGammaRamp", CallingConvention = SDL2_CALL)]
        public static extern int GetWindowGammaRamp(SDL_Window window, ref UInt16 red, ref UInt16 green, ref UInt16 blue);

        /// <summary>
        /// Destroy a window.
        /// </summary>
        /// <param name="window"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_DestroyWindow", CallingConvention = SDL2_CALL)]
        public static extern void DestroyWindow(SDL_Window window);

        /// <summary>
        /// Returns whether the screensaver is currently enabled (default on).
        /// </summary>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_IsScreenSaverEnabled", CallingConvention = SDL2_CALL)]
        public static extern int IsScreenSaverEnabled();

        /// <summary>
        /// Allow the screen to be blanked by a screensaver
        /// </summary>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_EnableScreenSaver", CallingConvention = SDL2_CALL)]
        public static extern void EnableScreenSaver();

        /// <summary>
        /// Prevent the screen from being blanked by a screensaver
        /// </summary>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_DisableScreenSaver", CallingConvention = SDL2_CALL)]
        public static extern void DisableScreenSaver();

    }
}
