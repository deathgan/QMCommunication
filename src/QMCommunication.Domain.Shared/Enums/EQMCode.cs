using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QMCommunication.Enums
{
    public enum EQMCode : int
    {
        [Description("正常返回")]
        OK = 1,
        [Description("OUT出库看板")]
        Error = 999999,
    }
}
