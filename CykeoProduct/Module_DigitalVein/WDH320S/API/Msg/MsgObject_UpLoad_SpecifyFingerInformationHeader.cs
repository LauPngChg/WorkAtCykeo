using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    public class MsgObject_UpLoad_SpecifyFingerInformationHeader:MessageObject
    {
        private ushort temp;
        private byte temp1;
        private byte temp2;
        private byte[] temp3;
        private byte[] temp4;

        public ushort SpecifyFingerID { get => temp; set => temp = value; }
        public byte GetGroupID { get => temp1;  }
        public byte GetTempleCount { get => temp2;  }
        public byte[] GetDIYData { get => temp3; }
        public byte[] GetSpecifyFingerInformationHeader { get => temp4; }

        public MsgObject_UpLoad_SpecifyFingerInformationHeader()
        {
            base.CmdCode = eCmdCode.CMD_UPLOAD_INFOR;
            base.SetData = 0x00;
        }
        public override void CmdPacked()
        {
            base.UshortLen = this.temp;
            base.CmdPacked();
        }
        public override void CmdUnpacked()
        {
            this.ReturnValue = this.GetResult == eAckCode.ERR_SUCCESS ? 0 : -1;
            this.ReturnMsg = this.GetResult.ToString();
            if (base.Child == null)
                return;
            this.temp4 = base.Child.Data_Child;
            this.temp = DataConvert.Bytes_To_Ushort(new byte[2] { temp4[1], temp4[0] });
            this.temp1 = temp4[2];
            this.temp2 = temp4[3];
            this.temp3 = DataConvert.ReadBytes(temp4, 4, 14);
        }
    }
}
