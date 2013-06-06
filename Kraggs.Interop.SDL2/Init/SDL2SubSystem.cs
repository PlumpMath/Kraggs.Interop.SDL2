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

namespace Kraggs.Interop.SDL2
{
    public enum SDL2SubSystem
    {
		Timer               = 0x00000001,
		Audio               = 0x00000010,
		Video               = 0x00000020,
		Joystick            = 0x00000200,
		Haptic              = 0x00001000,
		GameController      = 0x00002000,
		NoParachute         = 0x00100000,
		//INIT_EVERYTHING = (INIT_TIMER | INIT_AUDIO | INIT_VIDEO | INIT_JOYSTICK | INIT_HAPTIC | INIT_GAMECONTROLLER | INIT_NOPARACHUTE),
        Everything = Timer | Audio | Video | Joystick | Haptic | GameController,

    }
}
