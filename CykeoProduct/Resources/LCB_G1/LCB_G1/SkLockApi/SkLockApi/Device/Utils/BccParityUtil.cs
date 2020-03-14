using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkLockApi.Device.Utils
{
    public class BccParityUtil
    {
        /// <summary>
        /// BCC校验
        /// </summary>
        /// <param name="data">需要校验的数据</param>
        /// <returns></returns>
        public static byte BccCheckUtil(byte[] data)
        {
            byte CheckCode = 0;
            int len = data.Length;
            for (int i = 0; i < len; i++)
            {
                CheckCode ^= data[i];
            }
            return CheckCode;
        }
    }
}
