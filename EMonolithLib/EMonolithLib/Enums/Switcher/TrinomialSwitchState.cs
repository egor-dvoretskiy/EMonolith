using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMonolithLib.Enums.Switcher
{
    /// <summary>
    /// Contains three positions to use. ON, OFF, NEUTRAL.
    /// </summary>
    public enum TrinomialSwitchState : byte
    {
        OFF = 0,
        ON = 1,
        NEUTRAL = 2
    }
}
