using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    public class MsgObject_UpLoad_SpecifyFingerInformationHeaderAndTemple:MessageObject
    {
        private ushort temp;
        private byte[] temp1;
        private List<byte[]> temp2;
        private ushort temp3;
        private byte temp4;
        private byte temp5;
        private byte[] temp6;
        public ushort SetFingerID { set => temp = value; }
        public byte[] GetSpecifyFingerInformationHeader { get => temp1;}
        public List<byte[]> GetSpecifyFingerInformationTemple { get => temp2; }
        public ushort GetFingerID { get => temp3;  }
        public byte GetGroupID { get => temp4;  }
        public byte GetTempleCount { get => temp5;  }
        public byte[] GetDIYData { get => temp6;  }

        public MsgObject_UpLoad_SpecifyFingerInformationHeaderAndTemple()
        {
            base.CmdCode = eCmdCode.CMD_UPLOAD_INFOR_TEMPLATES;
            base.SetData = 0x00;
            this.temp1 = null;
            this.temp2 = null;
            this.temp6 = null;
        }
        public override void CmdPacked()
        {
            base.UshortLen = temp;
        }
        public override void CmdUnpacked()
        {
            this.ReturnValue = this.GetResult == eAckCode.ERR_SUCCESS ? 0 : -1;
            this.ReturnMsg = this.GetResult.ToString();
            if (base.Child == null)
                return;
            this.temp1 = DataConvert.ReadBytes(base.Child.Data_Child, 0, 18);
            this.temp2 = new List<byte[]>();
            this.temp3 = DataConvert.Bytes_To_Ushort(new byte[2] { this.temp1[1], this.temp1[0] });
            this.temp4 = this.temp1[2];
            this.temp5 = this.temp1[3];
            this.temp6 = DataConvert.ReadBytes(this.temp1, 4, 14);
            for (int i = 0; i < this.temp5; i++)
            {
                this.temp2.Add(DataConvert.ReadBytes(base.Child.Data_Child, 18 + i * 512, 512));
            }
        }
    }
}
