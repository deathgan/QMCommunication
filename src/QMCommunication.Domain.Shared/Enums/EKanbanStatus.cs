using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QMCommunication.Enums
{
    public enum EKanbanStatus : int
    {
        [Description("新建")]
        New = 1,
        [Description("处理中")]
        Processing = 2,
        [Description("拣货中")]
        Sorting = 3,
        [Description("已拣货")]
        Sorted = 4,
        [Description("部分发运")]
        PartialShipment = 6,
        [Description("已发运")]
        Shipmented = 7,
        [Description("部分接收")]
        PartialReceive = 8,
        [Description("已接收")]
        Received = 9,


    }
}
