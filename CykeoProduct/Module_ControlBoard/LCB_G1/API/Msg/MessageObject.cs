using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ControlBoard.LCB_G1.API.Msg
{
    [Serializable]
    public class MessageObject
    {
        protected const byte HEAD = 0xAA;
        private ushort len;
        private byte address;
        private byte cmdType;
        private byte[] data;
        private byte crc;
        protected const byte END = 0xBB;
        private byte[] toBCC;
        private byte[] frameMsg;

        private int returnValue;
        private string returnMsg;
        private const int BUFFER_SIZE = 1024;

        //public ushort Len { get => len; set => len = value; }
        public byte Address { get => address; set => address = value; }
        public byte CmdType { get => cmdType; set => cmdType = value; }
        public byte[] Data { get => data; set => data = value; }
        //public byte CRC { get => crc; set => crc = value; }
        public byte[] FrameMsg { get => frameMsg; set => frameMsg = value; }
        public int ReturnValue { get => returnValue; set => returnValue = value; }
        public string ReturnMsg { get => returnMsg; set => returnMsg = value; }
        public byte[] ToBCC { get => toBCC; set => toBCC = value; }

        public MessageObject()
        {
            data = null;
            returnValue = -1;
            returnMsg = "None return message.";
        }
        public MessageObject(byte[] receivedData)
        {
            try
            {
                if (receivedData == null)
                    throw new Exception("Null data !");
                this.frameMsg = receivedData;
                this.toBCC = new byte[receivedData.Length - 3];
                Array.Copy(receivedData, 1, toBCC, 0, toBCC.Length);
                int flag = 1;
                this.len = DataConvert.Bytes_To_Ushort(new byte[2] { receivedData[flag], receivedData[flag+1] });
                flag += 2;
                this.address = receivedData[flag++];
                this.cmdType = receivedData[flag++];
                this.data =(len - 2 !=0)? new byte[len - 2]:null;
                if(data !=null)
                    Array.Copy(receivedData, flag, data, 0, data.Length);
                this.crc = receivedData[flag+ (data != null?data.Length:0)];
            }
            catch 
            { }        
        }

        public virtual void CmdPacked()
        {
        }
        public virtual void CmdUnpacked()
        {
        }
        public void CmdUnpacked(byte[] cmdData)
        {
            this.data = cmdData;
            this.CmdUnpacked();
        }
        public byte[] CmdToBytes()
        {
            if (data == null)
                return null;
            this.len = (ushort)(this.data.Length + 2);
            this.toBCC = new byte[this.len+2];
            int flag = 0;
            Array.Copy(DataConvert.Ushort_To_Bytes(this.len), 0, toBCC, flag, 2);
            flag += 2;
            toBCC[flag++] = address;
            toBCC[flag++] = (byte)cmdType;
            Array.Copy(data, 0, toBCC, flag, data.Length);
            this.crc = DataConvert.BccCheck(toBCC);
            this.frameMsg =new byte[(this.len + 5)];
            flag = 0;
            this.frameMsg[flag++] = HEAD;
            Array.Copy(toBCC, 0, frameMsg, flag, toBCC.Length);
            flag += toBCC.Length;
            this.frameMsg[flag++] = this.crc;
            this.frameMsg[flag] = END;
            return this.frameMsg;
        }
        public bool CheckData()
        {
            if (this.toBCC != null)
            {
                byte tempBcc = DataConvert.BccCheck(DataConvert.ReadBytes(this.toBCC, 0, this.toBCC.Length ));
                if (tempBcc == this.crc) 
                    return true;  
            }
            return false;
        }
        public byte ToKey()
        {
            if ((CmdType & 0xF0) == 0xC0)
                return (byte)(cmdType - 0x20);
            else
            return cmdType;
        }
    }
}
