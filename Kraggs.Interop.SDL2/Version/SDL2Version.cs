using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Kraggs.Interop.SDL2
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL2Version
    {
        public byte Major;
        public byte Minor;
        public byte Patch;
    }
}

