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
        /// Dynamically load an OpenGL library.
        /// </summary>
        /// <remarks>
        /// This should be done after initializing the video driver, but before creating any OpenGL windows.  If no OpenGL library is loaded, the default library will be loaded upon creation of the first OpenGL window.
        /// 
        /// NOTE: If you do this, you need to retrieve all of the GL functions used in your program from the dynamic library using SDL_GL_GetProcAddress().
        /// </remarks>
        /// <param name="path">The platform dependent OpenGL library name, or NULL to open the default OpenGL library.</param>
        /// <returns>0 on success, or -1 if the library couldn't be loaded.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GL_LoadLibrary", CallingConvention = SDL2_CALL)]
        public static extern int GLLoadLibrary(string path);

        /// <summary>
        /// Get the address of an OpenGL function.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GL_GetProcAddress", CallingConvention = SDL2_CALL)]
        public static extern IntPtr GLGetProcAddress(string path);

        /// <summary>
        /// Unload the OpenGL library previously loaded by SDL_GL_LoadLibrary().
        /// </summary>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GL_UnloadLibrary", CallingConvention = SDL2_CALL)]
        public static extern void GLUnloadLibrary();

        /// <summary>
        /// Return true if an OpenGL extension is supported for the current context.
        /// </summary>
        /// <param name="Extension"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GL_ExtensionSupported", CallingConvention = SDL2_CALL)]
        public static extern int GLExtensionSupported(string Extension);

        /// <summary>
        /// Set an OpenGL window attribute before window creation.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GL_SetAttribute", CallingConvention = SDL2_CALL)]
        public static extern int GLSetAttribute(SDL2OpenGLAttributes attribute, int value);

        /// <summary>
        /// Get the actual value for an attribute from the current context.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GL_GetAttribute", CallingConvention = SDL2_CALL)]
        public static extern int GLGetAttribute(SDL2OpenGLAttributes attribute, out int value);

        /// <summary>
        /// Create an OpenGL context for use with an OpenGL window, and make it current.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GL_CreateContext", CallingConvention = SDL2_CALL)]
        public static extern SDL_GLContext GLCreateContext(SDL_Window window);

        /// <summary>
        /// Set up an OpenGL context for rendering into an OpenGL window.
        /// The context must have been created with a compatible window.
        /// </summary>
        /// <param name="window"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GL_MakeCurrent", CallingConvention = SDL2_CALL)]
        public static extern int GLMakeCurrent(SDL_Window window, SDL_GLContext context);

        /// <summary>
        /// Set the swap interval for the current OpenGL context.
        /// </summary>
        /// <param name="interval">0 for immediate updates, 1 for updates synchronized with the vertical retrace. If the system supports it, you may specify -1 to allow late swaps to happen immediately instead of waiting for the next retrace.</param>
        /// <returns>0 on success, or -1 if setting the swap interval is not supported.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GL_SetSwapInterval", CallingConvention = SDL2_CALL)]
        public static extern int GLSetSwapInterval(int interval);

        /// <summary>
        /// Get the swap interval for the current OpenGL context.
        /// </summary>
        /// <returns>0 if there is no vertical retrace synchronization, 1 if the buffer swap is synchronized with the vertical retrace, and -1 if late swaps happen immediately instead of waiting for the next retrace. If the system can't determine the swap interval, or there isn't a valid current context, this will return 0 as a safe default.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GL_GetSwapInterval", CallingConvention = SDL2_CALL)]
        public static extern int GLGetSwapInterval();

        /// <summary>
        /// Swap the OpenGL buffers for a window, if double-buffering is supported.
        /// </summary>
        /// <param name="window"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GL_SwapWindow", CallingConvention = SDL2_CALL)]
        public static extern void GLSwapWindow(SDL_Window window);

        /// <summary>
        /// Delete an OpenGL context.
        /// </summary>
        /// <param name="context"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GL_DeleteContext", CallingConvention = SDL2_CALL)]
        public static extern void GLDeleteContext(SDL_GLContext context);

        /// <summary>
        /// A wrapper for GLSetAttribute with correct enums for profile flag settings.
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DebuggerNonUserCode()]
        public static int GLSetAttributeProfile(SDL2OpenGLProfile flags)
        {
            return GLSetAttribute(SDL2OpenGLAttributes.ContextProfileMask, (int)flags);
        }
        /// <summary>
        /// A wrapper for GLGetAttribute with correct enums for profile flag settings.
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DebuggerNonUserCode()]
        public static int GLGetAttributeProfile(out SDL2OpenGLProfile flags)
        {
            int tmp = -1;
            int ret = GLGetAttribute(SDL2OpenGLAttributes.ContextProfileMask, out tmp);
            flags = (SDL2OpenGLProfile)tmp;
            return ret;
        }
        /// <summary>
        /// A wrapper for GLSetAttribute with correct enums for Context Flags.
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DebuggerNonUserCode()]
        public static int GLSetAttributeContext(SDL2OpenGLContextFlags flags)
        {
            return GLSetAttribute(SDL2OpenGLAttributes.ContextFlags, (int)flags);
        }
        /// <summary>
        /// A Wrapper for GLGetAttribute with correct enums for Context Flags.
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DebuggerNonUserCode()]
        public static int GLGetAttributeContext(out SDL2OpenGLContextFlags flags)
        {
            int tmp = -1;
            int ret = GLGetAttribute(SDL2OpenGLAttributes.ContextFlags, out tmp);
            flags = (SDL2OpenGLContextFlags)tmp;
            return ret;
        }

    }
}
