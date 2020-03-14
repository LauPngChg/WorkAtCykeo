using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    public class MessageObject_Child
    {
        private eCmdCode cmdCode_Child;
        private byte devId_Child;
        private byte[] data_Child;
        private byte check_Child;
        private byte[] crcData;
        private byte[] frameMsg;

        public eCmdCode CmdCode_Child { get => cmdCode_Child; set => cmdCode_Child = value; }
        public byte DevId_Child { get => devId_Child; set => devId_Child = value; }
        public byte[] Data_Child { get => data_Child; set => data_Child = value; }
        public byte Check_Child { get => check_Child; set => check_Child = value; }
        public byte[] CrcData { get => crcData; set => crcData = value; }
        public byte[] FrameMsg { get => frameMsg; set => frameMsg = value; }

        public MessageObject_Child(MessageObject msg)
        {
            this.cmdCode_Child = msg.CmdCode;
            this.devId_Child = msg.DevId;
        }
        public byte[] pack()
        {
            byte[] temp = new byte[this.data_Child.Length + 5];
            int flag = 0;
            temp[flag] = 0x3E;
            temp[flag++] = (byte)this.cmdCode_Child;
            temp[flag++] = this.devId_Child;
            if (this.data_Child == null)
                return null;
            Array.Copy(this.data_Child, 0, temp, flag, this.data_Child.Length);
            flag += this.data_Child.Length;
            this.crcData = DataConvert.ReadBytes(temp, 0, flag);
            temp[flag++] = this.check_Child = DataConvert.Check_Xor(this.crcData);
            temp[flag++] = 0x0D;
            return temp;
        }
    }
}
