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
