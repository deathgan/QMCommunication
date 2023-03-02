using QMCommunication.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMCommunication.QMGeneral
{
    public class QMGeneralResult
    {
        public string Msg { get; set; }

        public string Token { get; set; }

        public EQMCode Code { get; set; }

        public object Data { get; set; }
    }
}
