using QMCommunication.Common;
using QMCommunication.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMCommunication.Base
{
    public class ServiceResult<T>
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public EServiceResultCode Code { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }


        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// 请求状态
        /// </summary>
        public bool State => Code == EServiceResultCode.Succeed;




        /// <summary>
        /// 操作成功
        /// </summary>
        /// <param name="data"></param>
        public void OperationSuccess(T data)
        {
            this.Data = data;
            this.Code = EServiceResultCode.Succeed;
            this.Message = EnumHelper.
                GetDescription((EServiceResultCode)Enum.
                Parse(typeof(EServiceResultCode),
                EServiceResultCode.Succeed.ToString()));
        }

        /// <summary>
        /// 操作失败
        /// </summary>
        /// <param name="data"></param>
        public void OperationFail(string message)
        {
            this.Code = EServiceResultCode.Failed;
            this.Message = message;
        }

        /// <summary>
        /// 无数据
        /// </summary>
        /// <param name="data"></param>
        public void OperationNoData()
        {

            this.Code = EServiceResultCode.NoData;
            this.Message = EnumHelper.
                GetDescription((EServiceResultCode)Enum.
                Parse(typeof(EServiceResultCode),
                EServiceResultCode.NoData.ToString()));
        }



    }

}
