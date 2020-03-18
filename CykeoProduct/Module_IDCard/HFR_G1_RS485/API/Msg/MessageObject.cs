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
        protected byte Len { get => len; set => len = value; }
        protected eCmdType CmdType { get => cmdType; set => cmdType = value; }
        protected byte[] Data { get => data; set => data = value; }
        protected byte Bcc { get => bcc; set => bcc = value; }
        protected byte[] ToBCC { get => toBCC;  set => toBCC = value; }
        public int ReturnValue { get => returnValue;  set => returnValue = value; }
        public string ReturnMsg { get => returnMsg;  set => returnMsg = value; }
        public MessageObject_Child Child { get => child;  set => child = value; }
        public MessageObject()
        {
            this.address = 0x00;
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
                this.child = new MessageObject_Child(receivedData);
            }
            catch
            { }
        }
        public virtual void CmdPacked()
        {
        }
        public virtual void CmdUnpacked()
        {
            if (this.child != null)
            {
                if (this.child.Status == eReturnStatus.FAIL)
                {
                    this.ReturnValue = this.child.Data[0];
                    this.ReturnMsg = this.child.Status.ToString() + "    " + (eReturnStatusType)this.child.Data[0];
                }
                else
                {
                    this.ReturnValue = 0;
                    this.ReturnMsg = this.child.Status.ToString();
                }
            }
            else
                this.ReturnValue = -1;
        }
        public void CmdUnpacked(byte[] cmdData)
        {
            this.data = cmdData;
            this.CmdUnpacked();
        }
        public byte[] CmdToBytes()
        {
            this.len = (byte)(this.data == null ? 1 : this.data.Length+1);
            this.frameMsg = new byte[this.len + 5];
            int flag = 0;
            this.frameMsg[flag++] = 0xAA;
            this.frameMsg[flag++] = this.address;
            this.frameMsg[flag++] = this.len;
            this.frameMsg[flag++] =(byte) this.cmdType;
            if (this.data != null)
            {
                Array.Copy(this.data, 0, this.frameMsg, flag, this.data.Length);
                flag += this.data.Length;
            }
            this.frameMsg[flag++] = DataConvert.BccCheck(DataConvert.ReadBytes(this.frameMsg, 1, flag));
            this.frameMsg[flag++] = 0xBB;
            return this.frameMsg;
        }
        public bool CheckData()
        {
            return this.toBCC != null? DataConvert.BccCheck(DataConvert.ReadBytes(this.toBCC, 0, this.toBCC.Length)) == this.bcc : false;
        }
        public string ToKey()
        {
                return this.cmdType.ToString();
        }
    }
}
