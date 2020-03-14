using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API
{
    public class DataConvert
    {
        /// <summary>
        /// 指静脉异或校验函数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte Check_Xor( byte[] data)
        {
            byte temp =0;
            for (int i = 0; i < data.Length; i++)
                temp ^= data[i];
            return temp;
        }
        /// <summary>
        /// 转换2：   ushort   ->   数组    如10 = {00 ，0A}
        /// </summary>
        public static byte[] Ushort_To_Bytes(ushort i)
        {
            return new byte[]
            {
                (byte)((0xff00 & i)>>8),
                (byte) (0xff & i),
            };
        }

        /// <summary>
        ///    转换3：   数组16   -   Ushort     如：{00，0A}  = 10（仅用于2个元素的数组转换，其他出错）
        /// </summary>
        public static ushort Bytes_To_Ushort(byte[] hexByes)
        {
            ushort _temp = 0;
            Array.Reverse(hexByes);
            for (int i = 0; i < hexByes.Length; i++)
            {
                _temp += (ushort)((0xff & hexByes[i]) << (8 * i));
            }
            return _temp;
        }
        /// <summary>
        ///    转换4：   Copy  Some Bytes  
        /// </summary>
        public static byte[] ReadBytes(byte[] respose, int index, int length)
        {
            byte[] revs = new byte[length];
            for (int i = 0; i < length; i++)
            {
                revs[i] = respose[index + i];
            }
            return revs;
        }
    }
}
