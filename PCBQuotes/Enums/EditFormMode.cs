using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCBQuotes.Enums
{
    [System.Flags]
    public enum EditFormMode
    {
        Add = 1,
        Edit = 2,
        Delete = 4
    }
}
