using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkLockApiTest
{
    /// <summary>
    /// 常用转化类库
    /// </summary>
    public class DevConvert
    {
        #region 相关转化
        /// <summary>
        /// 十六进制字符串转换为十进制数字
        /// </summary>
        /// <param name="hexStr">16进制字符，例如AB</param>
        /// <returns></returns>
        public static long HexStr2Dec(string hexStr)
        {
            char[] hexCharList = hexStr.ToCharArray();
            long result = 0;
            for (int i = 0; i < hexCharList.Length; i++)
            {
                result += HexChar2Dec(hexCharList[hexCharList.Length - 1 - i]) * Power(16, i);
            }
            return result;
        }
        public static string HexStr2BinaryStr(string hexStr)
        {
            long iDec = HexStr2Dec(hexStr);
            return Dec2Other(iDec, 2);
        }
        /// <summary>
        /// 二进制字符串转化为十进制数字
        /// </summary>
        /// <param name="binaryStr"></param>
        /// <returns></returns>
        public static long BinaryStr2Dec(string binaryStr)
        {
            return Convert.ToInt32(binaryStr, 2);
        }
        /// <summary>
        /// 十进制数字转化为其它类型（2、8、16进制字符串）
        /// </summary>
        /// <param name="dec"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string Dec2Other(long dec, int i)
        {
            string s = string.Empty;
            return Convert.ToString(dec, i);
        }
        /// <summary>
        /// 其它类型（2、8、16进制字符串）转化为十进制数字
        /// </summary>
        /// <param name="other"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static long Other2Dec(string other, int i)
        {
            return Convert.ToInt32(other, i);
        }
        /// <summary>
        /// 获取二进制第几位
        /// </summary>
        /// <param name="binaryStr"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static int GetBinary4Id(string binaryStr, int idx)
        {
            //01011111
            int len = binaryStr.Length;
            return Convert.ToInt16(binaryStr.Substring(len - idx - 1, 1));
        }
        /// <summary>
        /// 十六进制字符转换为十进制数字
        /// </summary>
        public static long HexChar2Dec(char hexChar)
        {
            switch (hexChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return Convert.ToInt64(hexChar);
                case 'A':
                    return 10;
                case 'B':
                    return 11;
                case 'C':
                    return 12;
                case 'D':
                    return 13;
                case 'E':
                    return 14;
                case 'F':
                    return 15;
                default:
                    throw new Exception("该字符不是十六进制字符");
            }
        }
        /// <summary>
        /// 乘方x^y
        /// </summary>
        public static long Power(int x, int y)
        {
            long result = 1;
            for (int i = 0; i < y; i++)
            {
                result *= x;
            }
            return result;
        }
        public static bool IsValidEmAddress(int em)
        {
            //5 除以 2 = 2 余 1,因此 5/2=2,5%2=1. 
            int iret = em % 10;
            return iret == 0 ? true : false;
        }
        public static short Byte2Dec(byte[] bytes)
        {
            string hex = string.Empty;
            foreach (byte b in bytes)
            {
                hex += b.ToString("X2");
            }
            return Convert.ToInt16(hex, 16);
        }
        #endregion

        #region 其他转化
        public static byte[] ReadBytes(byte[] respose, int index, int length)
        {
            byte[] revs = new byte[length];
            for (int i = 0; i < length; i++)
            {
                revs[i] = respose[index + i];
            }
            return revs;
        }
        public static string GetZeros(int icount)
        {
            byte[] request = new byte[icount];
            for (int i = 0; i < request.Length; i++)
            {
                request[i] = 0x00;
            }
            return Encoding.Default.GetString(request, 0, request.Length);
        }
        public static int ConvertInteger(byte[] bytes)
        {
            string hex = ToHexString2Format(bytes, "");
            return Convert.ToInt32(hex, 16);
        }
        public static ushort ConvertUShort(byte[] bytes)
        {
            string hex = ToHexString2Format(bytes, "");
            return Convert.ToUInt16(hex, 16);
        }
        public static byte[] ConvertBytes(int i)
        {
            string hex = i.ToString("X4");
            return HexString2Bytes(hex);
        }
        public static byte[] ConvertBytes2(ushort i)
        {
            string hex = i.ToString("X4");
            return HexString2Bytes(hex);
        }
        #endregion

        #region 获取整数的某一位，设置整数的某一位
        /// <summary>
        /// 取整数的某一位
        /// </summary>
        /// <param name="_Resource">要取某一位的整数</param>
        /// <param name="_Mask">要取的位置索引，自右至左为0-7</param>
        /// <returns>返回某一位的值（0或者1）</returns>
        public static int GetIntegerSomeBit(int _Resource, int _Mask)
        {
            return _Resource >> _Mask & 1;
        }


        /// <summary>
        /// 将整数的某位置为0或1
        /// </summary>
        /// <param name="_Mask">整数的某位</param>
        /// <param name="a">整数</param>
        /// <param name="flag">是否置1，TURE表示置1，FALSE表示置0</param>
        /// <returns>返回修改过的值</returns>
        public static int SetIntegerSomeBit(int _Mask, int a, bool flag)
        {
            if (flag)
            {
                a |= (0x1 << _Mask);
            }
            else
            {
                a &= ~(0x1 << _Mask);
            }
            return a;
        }
        #endregion

        #region 进制转化优化程序（数组）
        /// <summary>
        /// 字节数组转化为16进制字符串
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="format">格式字符</param>
        /// <returns>16进制字符串</returns>
        public static string ToHexString2Format(byte[] bytes, string format)
        {
            string ret = string.Empty;
            foreach (byte mybyte in bytes)
            {
                ret += mybyte.ToString("X2") + format;
            }
            ret = ret.Substring(0, ret.Length);
            return ret;
        }
        public static string ToHexString2Format2(ushort[] ushorts, string format)
        {
            string ret = string.Empty;
            foreach (ushort myushort in ushorts)
            {
                ret += myushort.ToString("X4") + format;
            }
            ret = ret.Substring(0, ret.Length);
            return ret;
        }
        /// <summary>
        /// 16进制字符串转化为字节数组：AA010B009F对应字节：0xAA,0x01,0x0B,0x00,0x9F
        /// </summary>
        /// <param name="hex_value">16进制字符串</param>
        /// <returns>字节数组</returns>
        public static byte[] HexString2Bytes(string hex_value)
        {
            //1234
            int ilen = hex_value.Length / 2;
            byte[] myBytes = new byte[ilen];
            for (int i = 0; i < ilen; i++)
            {
                myBytes[i] = (byte)Convert.ToInt32(hex_value.Substring(i * 2, 2), 16);
            }
            return myBytes;
        }
        public static ushort[] HexString2UShort(string hex_value)
        {
            //1234
            byte[] bytes = HexString2Bytes(hex_value);
            ushort[] ushorts = new ushort[bytes.Length / 2];
            //aa 01 99 08 89 76
            for (int i = 0; i < bytes.Length; i += 2)
            {
                string hex = ToHexString2Format(new byte[] { bytes[i], bytes[i + 1] }, "");
                ushorts[i / 2] = Convert.ToUInt16(hex, 16);
            }
            return ushorts;
        }
        /// <summary>
        /// 字节数组转化为字符串：例如:0x31 0x32 0x33 0x34对应字符串1234
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>字符串</returns>
        public static string Bytes2String(byte[] bytes)
        {
            return Encoding.Default.GetString(bytes, 0, bytes.Length);
        }
        public static string Bytes2String(byte[] bytes, string code_name)
        {
            //GB18030
            return Encoding.GetEncoding(code_name).GetString(bytes, 0, bytes.Length);
        }
        /// <summary>
        /// 字符串转化为字节数组：例如：1234对应0x31 0x32 0x33 0x34
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>字节数组</returns>
        public static byte[] String2Bytes(string str)
        {
            return Encoding.Default.GetBytes(str);
        }
        public static byte[] String2Bytes(string str, string code_name)
        {
            return Encoding.GetEncoding(code_name).GetBytes(str);
        }
        #endregion

        public static byte[] ConvertUShort(ushort[] uList)
        {
            string hex = string.Empty;
            foreach (ushort u in uList)
            {
                hex += u.ToString("X4");
            }
            return HexString2Bytes(hex);
        }

        public static string ConvertHalfInt(int i)
        {
            string my = i.ToString("X2");
            string h = my.Substring(0, 1);
            string l = my.Substring(1, 1);
            string sret = string.Format("{0}.{1}", new object[] {
                Convert.ToInt32(h, 16), Convert.ToInt32(l, 16)
            });
            return sret;
        }
    }
}
