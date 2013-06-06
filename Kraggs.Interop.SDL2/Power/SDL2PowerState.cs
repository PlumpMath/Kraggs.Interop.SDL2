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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kraggs.Interop.SDL2
{
    public enum SDL2PowerState
    {
        //POWERSTATE_UNKNOWN,      /**< cannot determine power status */
        /// <summary>
        /// cannot determine power status
        /// </summary>
        Unknown,
        //POWERSTATE_ON_BATTERY,   /**< Not plugged in, running on the battery */
        /// <summary>
        /// Not plugged in, running on the battery
        /// </summary>
        OnBattery,
        /// <summary>
        /// Plugged in, no battery available
        /// </summary>
        NoBattery,
        //POWERSTATE_NO_BATTERY,   /**< Plugged in, no battery available */
        /// <summary>
        /// Plugged in, charging battery
        /// </summary>
        Charging,
        //POWERSTATE_CHARGING,     /**< Plugged in, charging battery */
        /// <summary>
        /// Plugged in, battery charged
        /// </summary>
        Charged
        //POWERSTATE_CHARGED       /**< Plugged in, battery charged */
    }
}
