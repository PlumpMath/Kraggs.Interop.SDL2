using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

// mapp to system intptr
using SDL_Window = System.IntPtr;
using SDL_GLContext = System.IntPtr;
using SDL_Surface = System.IntPtr;

namespace Kraggs.Interop.SDL2
{
    /// <summary>
    /// OpenGL configuration attributes
    /// </summary>
    public enum SDL2OpenGLAttributes
    {
        RedSize,
        GreenSize,
        BlueSize,
        AlphaSize,
        BufferSize,
        DoubleBuffer,
        DepthSize,
        StencilSize,
        AccumRedSize,
        AccumGreenSize,
        AccumBlueSize,
        AccumAlphaSize,
        Stereo,
        MultisampleBuffers,
        MultisampleSamples,
        AcceleratedVisual,
        RetainedBacking,
        ContextMajorVersion,
        ContextMinorVersion,
        ContextEGL,
        ContextFlags,
        ContextProfileMask,
        ShareWithCurrentContext,
    }
}
