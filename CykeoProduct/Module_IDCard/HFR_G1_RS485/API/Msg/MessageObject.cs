using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    [Serializable]
    public class MessageObject
    {
        protected const byte HEAD = 0xAA;
        private byte address;
        private byte len;
        private eCmdType cmdType;
        private byte[] data;
        private byte bcc;
        protected const byte END = 0xBB;
        private byte[] toBCC;
        private byte[] frameMsg;
        private int returnValue;
        private string returnMsg;
        private const int BUFFER_SIZE = 1024;
        private MessageObject_Child child;

        public byte Address { get => address; set => address = value; }
        public byte Len { get => len; set => len = value; }
        public eCmdType CmdType { get => cmdType; set => cmdType = value; }
        public byte[] Data { get => data; set => data = value; }
        public byte Bcc { get => bcc; set => bcc = value; }
        public byte[] ToBCC { get => toBCC; internal set => toBCC = value; }
        public int ReturnValue { get => returnValue; internal set => returnValue = value; }
        public string ReturnMsg { get => returnMsg; internal set => returnMsg = value; }
        public MessageObject_Child Child { get => child; internal set => child = value; }

        public MessageObject()
        {
            child = null;
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
                this.child = new MessageObject_Child();
                this.child.ToBCC = new byte[receivedData.Length - 3];
                Array.Copy(receivedData, 1, this.child.ToBCC, 0, this.child.ToBCC.Length);
                int flag = 1;
                this.child.Address = receivedData[flag++];
                this.child.Len = receivedData[flag ++] ;
                this.child.Status = (eReturnStatus)receivedData[flag ++] ;
                this.child.Data = DataConvert.ReadBytes(receivedData, flag, this.child.Len - 1);
                flag += this.child.Len - 1;
                this.child.Bcc = receivedData[flag++];
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
            this.frameMsg = new byte[data.Length + 6];
            int flag = 0;
            this.frameMsg[flag++] = 0xAA;
            this.frameMsg[flag++] = this.address;
            this.frameMsg[flag++] = (byte)(this.data.Length + 1);
            this.frameMsg[flag++] =(byte) this.cmdType;
            Array.Copy(this.data, 0, this.frameMsg, flag, this.data.Length);
            flag += this.data.Length;
            this.frameMsg[flag++] = DataConvert.BccCheck(DataConvert.ReadBytes(this.frameMsg, 1, flag));
            this.frameMsg[flag++] = 0xBB;
            return this.frameMsg;
        }

        public bool CheckData()
        {
            if (this.toBCC != null)
            {
                if (DataConvert.BccCheck(DataConvert.ReadBytes(this.toBCC, 0, this.toBCC.Length)) == this.bcc)
                    return true;
            }
            return false;
        }
        public string ToKey()
        {
                return this.cmdType.ToString();
        }
    }
}
