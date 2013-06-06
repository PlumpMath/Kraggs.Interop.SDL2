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
    /// <summary>
    /// The SDL keyboard scancode representation.
    /// 
    /// Values of this type are used to represent keyboard keys, among other places
    /// in the \link SDL_Keysym::scancode key.keysym.scancode \endlink field of the
    /// SDL_Event structure.
    /// 
    /// The values in this enumeration are based on the USB usage page standard:
    /// http://www.usb.org/developers/devclass_docs/Hut1_12v2.pdf
    /// </summary>
    public enum SDL2ScanCode
    {
        Unknown                 = 0,

        #region Usage page 0x07     (USB keyboard page).
        // These values are from usage page 0x07 (USB keyboard page).        

        A                       = 4,
        B                       = 5,
        C                       = 6,
        D                       = 7,
        E                       = 8,
        F                       = 9,
        G                       = 10,
        H                       = 11,
        I                       = 12,
        J                       = 13,
        K                       = 14,
        L                       = 15,
        M                       = 16,
        N                       = 17,
        O                       = 18,
        P                       = 19,
        Q                       = 20,
        R                       = 21,
        S                       = 22,
        T                       = 23,
        U                       = 24,
        V                       = 25,
        W                       = 26,
        X                       = 27,
        Y                       = 28,
        Z                       = 29,

        Number0                 = 30,
        Number1                 = 31,
        Number2                 = 32,
        Number3                 = 33,
        Number4                 = 34,
        Number5                 = 35,
        Number6                 = 36,
        Number7                 = 37,
        Number8                 = 38,
        Number9                 = 39,
        
        Return                  = 40,
        Escape                  = 41,
        BackSpace               = 42,
        Tab                     = 43,
        Space                   = 44,

        Minus                   = 45,
        Equals                  = 46,
        LeftBracket             = 47,
        RightBracket            = 48,
        /// <summary>
        /// Located at the lower left of the return key on ISO keyboards and at the right end of the QWERTY row on ANSI keyboards.
        /// Produces REVERSE SOLIDUS (backslash) and VERTICAL LINE in a US layout, REVERSE SOLIDUS and VERTICAL LINE in a UK Mac layout, NUMBER SIGN and TILDE in a UK  Windows layout, DOLLAR SIGN and POUND SIGN in a Swiss German layout, NUMBER SIGN and APOSTROPHE in a German layout, GRAVE ACCENT and POUND SIGN in a French Mac layout, and ASTERISK and MICRO SIGN in a French Windows layout.
        /// </summary>
        BackSlash               = 49,
        /// <summary>
        /// ISO USB keyboards actually use this code instead of 49 for the same key, but all OSes I've seen treat the two codes identically. 
        /// So, as an implementor, unless your keyboard generates both of those codes and your OS treats them differently, you should generate SDL_SCANCODE_BACKSLASH instead of this code. 
        /// As a user, you should not rely on this code because SDL will never generate it with most (all?) keyboards.
        /// </summary>
        NonUsHash               = 50,

        SemiColon               = 51,
        Apostrophe              = 52,
        /// <summary>
        /// Located in the top left corner (on both ANSI and ISO keyboards). 
        /// Produces GRAVE ACCENT and TILDE in a US Windows layout and in US and UK Mac layouts on ANSI keyboards, GRAVE ACCENT and NOT SIGN in a UK Windows layout, SECTION SIGN and PLUS-MINUS SIGN in US and UK Mac layouts on ISO keyboards, SECTION SIGN and DEGREE SIGN in a Swiss German layout (Mac: only on ISO keyboards), CIRCUMFLEX ACCENT and DEGREE SIGN in a German layout (Mac: only on ISO keyboards), SUPERSCRIPT TWO and TILDE in a French Windows layout, COMMERCIAL AT and NUMBER SIGN in a French Mac layout on ISO keyboards, and LESS-THAN SIGN and GREATER-THAN SIGN in a Swiss German, German, or French Mac layout on ANSI keyboards.
        /// </summary>
        Grave                   = 53,

        Comma                   = 54,
        Period                  = 55,
        Slash                   = 56,

        CapsLock                = 57,

        F1                      = 58,
        F2                      = 59,
        F3                      = 60,
        F4                      = 61,
        F5                      = 62,
        F6                      = 63,
        F7                      = 64,
        F8                      = 65,
        F9                      = 66,
        F10                     = 67,
        F11                     = 68,
        F12                     = 69,

        PrintScreen             = 70,
        ScrollLock              = 71,
        Pause                   = 72,
        /// <summary>
        /// insert on PC, help on some Mac keyboards (but does send code 73, not 117)
        /// </summary>
        Insert                  = 73,

        Home                    = 74,
        PageUp                  = 75,
        Delete                  = 76,
        End                     = 77,
        PageDown                = 78,
        Right                   = 79,
        Left                    = 80,
        Down                    = 81,
        Up                      = 82,

        /// <summary>
        /// num lock on PC, clear on Mac keyboards
        /// </summary>
        NumLockClear            = 83,

        KeypadDivide            = 84,
        KeypadMultiply          = 85,
        KeypadMinus             = 86,
        KeypadPlus              = 87,
        KeypadEnter             = 88,
        Keypad1                 = 89,
        Keypad2                 = 90,
        Keypad3                 = 91,
        Keypad4                 = 92,
        Keypad5                 = 93,
        Keypad6                 = 94,
        Keypad7                 = 95,
        Keypad8                 = 96,
        Keypad9                 = 97,
        Keypad0                 = 98,
        KeypadPeriod            = 99,

        /// <summary>
        /// This is the additional key that ISO keyboards have over ANSI ones, located between left shift and Y.
        /// Produces GRAVE ACCENT and TILDE in a US or UK Mac layout, REVERSE SOLIDUS (backslash) and VERTICAL LINE in a US or UK Windows layout, and LESS-THAN SIGN and GREATER-THAN SIGN in a Swiss German, German, or French layout.
        /// </summary>
        NonUsBackslash          = 100,

        /// <summary>
        /// windows contextual menu, compose
        /// </summary>
        Application             = 101,

        /// <summary>
        /// The USB document says this is a status flag, not a physical key - but some Mac keyboards do have a power key.
        /// </summary>
        Power,

        KeypadEquals            = 103,

        F13                     = 104,
        F14                     = 105,
        F15                     = 106,
        F16                     = 107,
        F17                     = 108,
        F18                     = 109,
        F19                     = 110,
        F20                     = 111,
        F21                     = 112,
        F22                     = 113,
        F23                     = 114,
        F24                     = 115,

        Execute                 = 116,
        Help                    = 117,
        Menu                    = 118,
        Select                  = 119,
        Stop                    = 120,
        /// <summary>
        /// Redo
        /// </summary>
        Again                   = 121,
        Undo                    = 122,
        Cut                     = 123,
        Copy                    = 124,
        Paste                   = 125,
        Find                    = 126,
        Mute                    = 127,
        VolumeUp                = 128,
        VolumeDown              = 129,

        /* not sure whether there's a reason to enable these */
        /*     SDL_SCANCODE_LOCKINGCAPSLOCK = 130,  */
        /*     SDL_SCANCODE_LOCKINGNUMLOCK = 131, */
        /*     SDL_SCANCODE_LOCKINGSCROLLLOCK = 132, */

        KeypadComma             = 133,
        KeypadEqualsAS400       = 134,

        International1          = 135,
        International2          = 136,
        International3          = 137,
        International4          = 138,
        International5          = 139,
        International6          = 140,
        International7          = 141,
        International8          = 142,
        International9          = 143,

        /// <summary>
        /// Hangul/English toggle
        /// </summary>
        Language1                   = 144,
        /// <summary>
        /// Hanja conversion
        /// </summary>
        Language2                   = 145,
        /// <summary>
        /// Katakana
        /// </summary>
        Language3                   = 146,
        /// <summary>
        /// Hiragana
        /// </summary>
        Language4                   = 147,
        /// <summary>
        /// Zenkaku/Hankaku
        /// </summary>
        Language5                   = 148,
        /// <summary>
        /// reserved
        /// </summary>
        Language6                   = 149,
        /// <summary>
        /// reserved
        /// </summary>
        Language7                   = 150,
        /// <summary>
        /// reserved
        /// </summary>
        Language8                   = 151,
        /// <summary>
        /// reserved
        /// </summary>
        Language9                   = 152,
        
        /// <summary>
        /// Erase-Eaze
        /// </summary>
        Alterase                    = 153,

        SysReq                      = 154,
        Cancel                      = 155,
        Clear                       = 156,
        Prior                       = 157,
        Return2                     = 158,
        Separator                   = 159,
        Out                         = 160,
        Oper                        = 161,
        ClearAgain                  = 162,
        CrSel                       = 163,
        Exsel                       = 164,

        Keypad00                    = 176,
        Keypad000                   = 177,
        ThousandSeparator           = 178,
        DecimalSeparator            = 179,
        CurrencyUnit                = 180,
        CurrencySubUnit             = 181,
        KeypadLeftParentes          = 182,
        KeypadRightParentes         = 183,
        KeypadLeftBrace             = 184,
        KeypadRightBrace            = 185,
        KeypadTab                   = 186,
        KeypadBackspace             = 187,
        KeypadA                     = 188,
        KeypadB                     = 189,
        KeypadC                     = 190,
        KeypadD                     = 191,
        KeypadE                     = 192,
        KeypadF                     = 193,
        KeypadXor                   = 194,
        KeypadPower                 = 195,
        KeypadPercent               = 196,
        KeypadLess                  = 197,
        KeypadGreater               = 198,
        KeypadAmpersand             = 199,
        KeypadDoubleAmpersand       = 200,
        KeypadVerticalBar           = 201,
        KeypadDoubleVerticalBar     = 202,
        KeypadColon                 = 203,
        KeypadHash                  = 204,
        KeypadSpace                 = 205,
        KeypadAt                    = 206,
        KeypadExclamation           = 207,
        KeypadMemStore              = 208,
        KeypadMemRecall             = 209,
        KeypadMemClear              = 210,
        KeypadMemAdd                = 211,
        KeypadMemSubtract           = 212,
        KeypadMemMultiply           = 213,
        KeypadMemDivide             = 214,
        KeypadPlusMinus             = 215,
        KeypadClear                 = 216,
        KeypadClearEntry            = 217,
        KeypadBinary                = 218,
        KeypadOctal                 = 219,
        KeypadDecimal               = 220,
        KeypadHexadecimal           = 221,

        LeftControl                 = 224,
        LeftShift                   = 225,
        /// <summary>
        /// alt, option
        /// </summary>
        LeftAlt                     = 226,
        /// <summary>
        /// windows, command (apple), meta
        /// </summary>
        LeftGui                     = 227,

        RightControl                = 228,
        RightShift                  = 229,
        /// <summary>
        /// alt gr, option
        /// </summary>
        RightAlt                    = 230,
        /// <summary>
        /// windows, command (apple), meta
        /// </summary>
        RightGui                    = 231,

        /// <summary>
        /// I'm not sure if this is really not covered by any of the above, but since there's a special KMOD_MODE for it I'm adding it here
        /// </summary>
        Mode                        = 257,

        #endregion

        #region Usage page 0x0C (USB consumer page).
        // These values are mapped from usage page 0x0C (USB consumer page).

        AudioNext                   = 258,
        AudioPrevious               = 259,
        AudioStop                   = 260,
        AudioPlay                   = 261,
        AudioMute                   = 262,
        MediaSelect                 = 263,
        WWW                         = 264,
        Mail                        = 265,
        Calculator                  = 266,
        Computer                    = 267,
        //TODO: Whats AC?
        AcSearch                    = 268,
        AcHome                      = 269,
        AcBack                      = 270,
        AcForward                   = 271,
        AcStop                      = 272,
        AcRefresh                   = 273,
        AcBookmarks                 = 274,

        #endregion

        #region  Walther keys (for mac keyboard?)
        //These are values that Christian Walther added (for mac keyboard?).

        BrightnessDown              = 275,
        BrightnessUp                = 276,
        DisplaySwitch               = 277,
        KeypadDillumToggle          = 278,
        KeypadDillumDown            = 279,
        KeypadDillumUp              = 280,

        Eject                       = 281,
        Sleep                       = 282,
        App1                        = 283,
        App2                        = 284,

        #endregion

        /// <summary>
        /// not a key, just marks the number of scancodes for array bounds
        /// </summary>
        NumScanCodes                = 512
    }
}
