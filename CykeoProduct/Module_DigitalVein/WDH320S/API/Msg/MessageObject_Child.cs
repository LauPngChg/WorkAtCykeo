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
        public MessageObject_Child()
        { }
        public byte[] pack()
        {
            byte[] temp = new byte[this.data_Child.Length + 5];
        }
    }
}
