using System;
using System.Collections.Generic;
using System.Text;

namespace QMCommunication.QMPalabelCasecode.Dtos
{

    [Serializable]
    public class PalabelCasecodeSearchAndBatchCreateDto
    {
        public string reqDateBegin { get; set; }
        public string reqDateEnd { get; set; }
        //可多个，逗号分隔
        public string plant { get; set; }
        //可多个，逗号分隔
        public string supCode { get; set; }

        /// <summary>
        /// 执行间隔时间 分钟
        /// </summary>
        public double intervalMinutes { get; set; }

    }
}
