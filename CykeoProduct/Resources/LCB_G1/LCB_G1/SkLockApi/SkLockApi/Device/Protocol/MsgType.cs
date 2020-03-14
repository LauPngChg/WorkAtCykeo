using SkLockApi.Device.Enum;
using SkLockApi.Device.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkLockApi.Device.Protocol
{
    [Serializable]
    public class MsgType
    {
        private byte header;
        private int len;
        private byte addr;
        private byte cmd;
        private byte[] data;
        private byte bcc;
        private byte end;

        public byte Header 
        { 
            get { return header; }
            set { header = value; }
        }
        public int Len 
        {
            get { return len; }
            set { len = value; }
        }
        public byte Addr 
        {
            get { return addr; }
            set { addr = value; }
        }
        public byte Cmd 
        {
            get { return cmd; }
            set { cmd = value; }
        }
        public byte[] Data 
        {
            get { return data; }
            set { data = value; }
        }
        public byte Bcc 
        {
            get { return bcc; }
            set { bcc = value; }
        }
        public byte End
        {
            get { return end; }
            set { end = value; }
        }

        public MsgType()
        {
            //header = 0xAA;
            //end = 0xBB;
        }
        /// <summary>
        /// 重构构造函数
        /// </summary>
        /// <param name="mid">命令类型</param>
        /// <param name="request">命令帧内容，包括Len,Addr,Cmd,Data组成</param>
        public MsgType(EnumControlMid mid, byte[] request)
        {
            header = 0xAA;
            len = request.Length - 2;
            addr = request[2];
            cmd = request[3];
            data = new byte[len - 2];
            Array.Copy(request, 4, data, 0, len - 2);
            //Console.WriteLine(DevConvert.ToHexString2Format(request,""));
        }
        /// <summary>
        /// 把数据帧转化成MsgType类型
        /// </summary>
        /// <param name="uRecBuffer">数据帧</param>
        /// <returns></returns>
        public MsgType ToConvert(byte[] uRecBuffer)
        {
            MsgType _temp = new MsgType();
            _temp.Header = uRecBuffer[0];
            _temp.len = DevConvert.ConvertInteger(new byte[] { uRecBuffer[1], uRecBuffer[2] });
            _temp.Addr = uRecBuffer[3];
            _temp.cmd = uRecBuffer[4];
            _temp.data = new byte[_temp.len - 2];
            Array.Copy(uRecBuffer, 5, _temp.data, 0, _temp.len - 2);
            _temp.bcc = uRecBuffer[uRecBuffer.Length - 2];
            _temp.end = uRecBuffer[uRecBuffer.Length - 1];

            return _temp;
        }
        /// <summary>
        /// 把MsgType数据转化为byte[]类型数据
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            int size = 7;
            if (data != null)
                size = 7 + data.Length;
            byte[] sendBytes = new byte[size];
            sendBytes[0] = header;
            byte[] len_bytes = DevConvert.ConvertBytes(len);
            sendBytes[1] = len_bytes[0];
            sendBytes[2] = len_bytes[1];
            sendBytes[3] = addr;
            sendBytes[4] = cmd;
            if (data != null)
                Array.Copy(data, 0, sendBytes, 5, data.Length);
            //Console.WriteLine(DevConvert.ToHexString2Format(data, ""));
            //BCC校验
            byte[] bytes = new byte[size - 3];
            Array.Copy(sendBytes, 1, bytes, 0, size - 3);
            byte _bcc = BccParityUtil.BccCheckUtil(bytes);
            sendBytes[size - 2] = _bcc;
            sendBytes[size - 1] = 0xBB;

            return sendBytes;
        }
        /// <summary>
        /// 把byte[]类型帧数据转为String类型
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            byte[] bytes = ToBytes();
            return DevConvert.ToHexString2Format(bytes, "");
        }
        public byte ToCheckSum()
        {
            byte[] bytes = ToBytes();
            byte[] my_bytes = DevConvert.ReadBytes(bytes, 1, bytes.Length - 3);
            byte _bcc = BccParityUtil.BccCheckUtil(my_bytes);
            return _bcc;
        }
    }
}
