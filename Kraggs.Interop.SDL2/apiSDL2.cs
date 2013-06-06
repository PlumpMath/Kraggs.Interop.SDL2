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
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace Kraggs.Interop.SDL2
{
    public static partial class apiSDL2
    {
        internal const string SDL2_LIBRARY = "SDL2.dll";
        internal const CallingConvention SDL2_CALL = CallingConvention.Cdecl;



    }
}
