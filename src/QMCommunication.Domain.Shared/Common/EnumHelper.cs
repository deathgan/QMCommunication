using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace QMCommunication.Common
{

    public class EnumHelper
    {
        /// <summary>
        /// 根据传入的枚举值来读取Description信息
        /// </summary>
        /// <param name="obj">枚举值</param>
        /// <returns></returns>
        public static string GetDescription(Enum obj)
        {
            string objName = obj.ToString();

            Type t = obj.GetType();

            FieldInfo fi = t.GetField(objName);

            DescriptionAttribute[] arrDesc = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return arrDesc[0].Description;
        }
    }
}
