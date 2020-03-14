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
        private byte[] byteLen;
        private ushort ushortLen;
        private byte[] extraByteMsg;
        private ushort  extraUshortMsg;
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
        public byte[] ByteLen { get => byteLen; set => byteLen = value; }
        protected ushort UshortLen { get => ushortLen; set => ushortLen = value; }
        public byte[] ExtraByteMsg { get => extraByteMsg; set => extraByteMsg = value; }
        protected ushort ExtraUshortMsg { get => extraUshortMsg; set => extraUshortMsg = value; }
        public byte Data { get => data; set => data = value; }
        public eAckCode Result { get => result; set => result = value; }
        public byte Check { get => check; set => check = value; }
        public byte[] CrcData { get => crcData; set => crcData = value; }
        public byte[] FrameData { get => frameMsg; set => frameMsg = value; }
        public int ReturnValue { get => returnValue; set => returnValue = value; }
        public string ReturnMsg { get => returnMsg; set => returnMsg = value; }
        public MessageObject_Child Child { get => child; set => child = value; }
       

        public MessageObject()
        {
            this.byteLen = null;
            this.extraByteMsg = null;
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
                case eCmdCode.CMD_UOLOAD_INFOR_TEMPLATES:
                case eCmdCode.CMD_DOWNLOAD_INFOR_TEMPLATES:
                case eCmdCode.CMD_UPLOAD_VERSION:
                case eCmdCode.CMD_UPLOAD_SEQUENCE:
                    this.byteLen = new byte[2] { receivedData[flag+1], receivedData[flag] };
                    this.ushortLen = DataConvert.Bytes_To_Ushort(this.byteLen);
                    this.extraByteMsg = null;
                    this.child = new MessageObject_Child() ;
                    break;
                default:
                    this.extraByteMsg = new byte[2] { receivedData[flag + 1], receivedData[flag] };
                    this.extraUshortMsg = DataConvert.Bytes_To_Ushort(this.extraByteMsg);
                    this.byteLen = null;
                    this.child = null;
                    break;
            }
            flag += 2;
            this.result = (eAckCode)receivedData[flag ++];
            this.check = receivedData[flag ++];
            if (receivedData[flag++] != End)
                return;
            if(this.child==null)
                return;
            if (receivedData[flag++] != HEAD_CHILD)
            {
                this.child = null;
                return;
            }
            if (this.cmdCode !=(this.child.CmdCode_Child =(eCmdCode)receivedData[flag++]) )
            {
                this.child = null;
                return;
            }
            if (this.devId != (this.child.DevId_Child = receivedData[flag++]))
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
        public virtual void CmdUnpacked() { }
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
                if (this.byteLen != null)
                    tempList.AddRange(this.byteLen);
                if (this.extraByteMsg != null)
                    tempList.AddRange(this.extraByteMsg);
                tempList.Add(this.data);
                this.crcData = new byte[6];
                for (int i = 0; i < 6; i++)
                    this.crcData[i] = tempList[1];
                tempList.Add(this.check = DataConvert.Check_Xor(this.crcData));
                tempList.Add(End);
                if (this.byteLen != null)
                {
                    tempList.Add(HEAD_CHILD);
                    tempList.Add((byte)this.cmdCode)
                }

                this.len = this.data_Child==null?(ushort)0:(ushort)this.data_Child.Length;
                this.frameMsg = new byte[8 + (this.len == 0 ? 0 : this.len + 5)];


                this.frameMsg[flag++] = (byte)(0xff & this.len);
                this.frameMsg[flag++] = (byte)((0xFF00&this.len)>>8);
                this.frameMsg[flag++] = this.data;
                this.frameMsg[flag++] = this.check = DataConvert.Check_Xor(DataConvert.ReadBytes(this.frameMsg, 0, 6));
                this.frameMsg[flag++] = End;
                if (this.len == 0)
                    return frameMsg;
                this.frameMsg[flag++] = HEAD_Child;
                this.frameMsg[flag++]= (byte)this.cmdCode;
                this.frameMsg[flag++] = devId;
                Array.Copy(this.data_Child, 0, this.frameMsg, flag, this.len);
                flag += this.len;
                this.frameMsg[flag++] = End;
                return frameMsg;
            }
            catch { }
            return null;
        }
        public bool CheckData()
        {
            return
                (this.len == 0) ?
                (DataConvert.Check_Xor(this.crcData) == this.check) :
                ((DataConvert.Check_Xor(this.crcData) == this.check) && (DataConvert.Check_Xor(this.crcData_Child) == this.check_Child));
        }
        public byte ToKey()
        {
            return (byte)this.cmdCode;
        }
    }
}
