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
