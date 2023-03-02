using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QMCommunication.Enums
{
    public enum EKanbanType : int
    {
        [Description("INB收货看板")]
        INB = 1,
        [Description("OUT出库看板")]
        OUT = 2,
    }
}
