using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{

    public class MessageObject
    {
        protected const byte HEAD =0x40;
        protected const byte HEAD_CHILD =0x3E;
        private eCmdCode cmdCode;
        private byte devId;
        private ushort ushortLen;
        private byte data;
        private eAckCode result;
        private byte check;
        private byte[] crcData;
        protected const byte End = 0x0D;
        private byte[] frameMsg;
        private int returnValue;
        private string returnMsg;
        private MessageObject_Child child;

        public eCmdCode CmdCode { get => cmdCode; set => cmdCode = value; }
        public byte DevId { get => devId; set => devId = value; }
        protected ushort UshortLen { get => ushortLen; set => ushortLen = value; }
        protected byte SetData { get => data; set => data = value; }
        public eAckCode GetResult { get => result; set => result = value; }
        protected byte Check { get => check; set => check = value; }
        protected byte[] CrcData { get => crcData; set => crcData = value; }
        protected byte[] FrameData { get => frameMsg; set => frameMsg = value; }
        public int ReturnValue { get => returnValue; set => returnValue = value; }
        public string ReturnMsg { get => returnMsg; set => returnMsg = value; }
        public MessageObject_Child Child { get => child; set => child = value; }
       

        public MessageObject()
        {
            this.devId = 0xFF;
            this.returnValue = -1;
            this.returnMsg = "None return message.";
            this.child = null;
        }
        public MessageObject(byte[] receivedData)
        {
            if (receivedData == null)
                throw new Exception("Null data !");
            this.crcData = DataConvert.ReadBytes(receivedData, 0, 6);
            this.frameMsg = receivedData;
            int flag = 1;
            this.cmdCode = (eCmdCode)receivedData[flag++];
            this.devId = receivedData[flag++];
            switch (this.cmdCode)
            {
                case eCmdCode.CMD_UPLOAD_CURRENTTEMP:
                case eCmdCode.CMD_REG_END:
                case eCmdCode.CMD_UPLOAD_ALL_ID:
                case eCmdCode.CMD_UPLOAD_INFOR:
                case eCmdCode.CMD_UPLOAD_TEMPLATE:
                case eCmdCode.CMD_UPLOAD_INFOR_TEMPLATES:
                case eCmdCode.CMD_UPLOAD_VERSION:
                case eCmdCode.CMD_UPLOAD_SEQUENCE:
                    this.child = new MessageObject_Child(this) ;
                    break;
                default:
                    this.child = null;
                    break;
            }
            this.ushortLen = DataConvert.Bytes_To_Ushort(new byte[2] { receivedData[flag + 1], receivedData[flag] });
            flag += 2;
            this.result = (eAckCode)receivedData[flag ++];
            this.check = receivedData[flag ++];
            if (receivedData[flag++] != End)
                return;
            if(this.child==null)
                return;
            if (this.ushortLen==0 ||
                (receivedData[flag++] != HEAD_CHILD) || 
                this.cmdCode != (this.child.CmdCode_Child = (eCmdCode)receivedData[flag++]) || 
                this.devId != (this.child.DevId_Child = receivedData[flag++]))
            {
                this.child = null;
                return;
            }
            this.child.Data_Child = new byte[this.ushortLen];
            Array.Copy(receivedData, flag, this.child.Data_Child, 0, this.ushortLen);
            flag += this.ushortLen;
            this.child.Check_Child = receivedData[flag++];
            this.child.CrcData = DataConvert.ReadBytes(receivedData, 8, this.ushortLen + 3);
            this.crcData = DataConvert.ReadBytes(receivedData, 0, 6);
        }
        public virtual void CmdPacked() { }
        public virtual void CmdUnpacked() {
            this.ReturnValue = this.GetResult == eAckCode.ERR_SUCCESS ? 0 : -1;
            this.ReturnMsg = this.GetResult.ToString();
        }
        public void CmdUnpacked(byte[] cmdData)
        {
            this.CmdUnpacked();
        }
        public byte[] CmdToBytes()
        {
            try
            {
                List<byte> tempList = new List<byte>();
                tempList.Add(HEAD);
                tempList.Add((byte)this.cmdCode);
                tempList.Add(this.devId);
                tempList.AddRange(DataConvert.Ushort_To_RBytes(this.ushortLen)) ;
                tempList.Add(this.data);
                this.crcData = new byte[6];
                for (int i = 0; i < 6; i++)
                    this.crcData[i] = tempList[1];
                tempList.Add(this.check = DataConvert.Check_Xor(this.crcData));
                tempList.Add(End);
                if (this.child != null)
                    tempList.AddRange(this.child.pack());
                this.frameMsg = new byte[tempList.Count];
                for (int i = 0; i < tempList.Count; i++)
                    this.frameMsg[i] = tempList[i];
                return frameMsg;
            }
            catch { }
            return null;
        }
        public bool CheckData()
        {
            return
                (this.child == null) ?
                (DataConvert.Check_Xor(this.crcData) == this.check) :
                ((DataConvert.Check_Xor(this.crcData) == this.check) && (DataConvert.Check_Xor(this.child.CrcData) == this.child.Check_Child));
        }
        public byte ToKey()
        {
            return (byte)this.cmdCode;
        }
    }
}
