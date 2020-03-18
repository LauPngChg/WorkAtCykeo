using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public class MessageObject_Child
    {
        private string key;
        private byte address;
        private byte len;
        private eReturnStatus status;
        private byte[] data;
        private byte bcc;
        private byte[] toBCC;
        private byte[] frameMsg;

        public string Key { get => key; set => key = value; }
        public byte Address { get => address; set => address = value; }
        public byte Len { get => len; set => len = value; }
        public eReturnStatus Status { get => status; set => status = value; }
        public byte[] Data { get => data; set => data = value; }
        public byte Bcc { get => bcc; set => bcc = value; }
        public byte[] ToBCC { get => toBCC; internal set => toBCC = value; }
        public byte[] FrameMsg { get => frameMsg; internal set => frameMsg = value; }

        public MessageObject_Child(byte[] cmd)
        {
            int flag = 1;
            this.address = cmd[flag++];
            this.len = cmd[flag++];
            this.status = (eReturnStatus)cmd[flag++];
            this.data = (this.len - 1 == 0) ? null : DataConvert.ReadBytes(cmd, flag, this.len - 1);
            flag += (this.len - 1);
            this.bcc = cmd[flag++];
            this.toBCC = DataConvert.ReadBytes(cmd, 1, cmd.Length - 3);
            this.frameMsg = cmd;
        }
        public bool Check()
        {
            return this.bcc == DataConvert.BccCheck(this.toBCC);
        }
    }
}
