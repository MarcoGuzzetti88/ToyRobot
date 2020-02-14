using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public enum Command
    {
        [Command("NA")]
        Unknown = 0,

        [Command("PLACE", 1)]
        Place = 1,

        [Command("MOVE")]
        Move,

        [Command("LEFT")]
        Left,

        [Command("RIGHT")]
        Right,

        [Command("REPORT")]
        Report
    }
}