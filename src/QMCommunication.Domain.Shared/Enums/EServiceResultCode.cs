using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QMCommunication.Enums
{
    /// <summary>
    /// 服务层响应码枚举
    /// </summary>
    public enum EServiceResultCode
    {

        [Description("失败")]
        Failed = 0,
        [Description("成功")]
        Succeed = 1,
        [Description("无数据")]
        NoData = 2
    }
}
