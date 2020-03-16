using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    public class MsgObject_DownLoad_SpecifyFingerInformationHeaderAndTemple : MessageObject
    {
        private ushort temp;
        private byte temp1;
        private byte[] temp2;
        private List<byte[]> temp3;
        private ushort temp4;
        public ushort SetFingerID {  set => temp = value; }
        public byte SetGroupID {  set => temp1 = value; }
        public byte[] SetDIYData {  set => temp2 = value; }
        public List<byte[]> SetTemple { set => temp3 = value; }
        public ushort GetLen { get => temp4; }

        public MsgObject_DownLoad_SpecifyFingerInformationHeaderAndTemple()
        {
            base.CmdCode = eCmdCode.CMD_DOWNLOAD_INFOR_TEMPLATES;
            base.SetData = 0x00;
            base.Child = new MessageObject_Child(this);
            this.temp2 = null;
            this.temp3 = new List<byte[]>();
        }
        public override void CmdPacked()
        {
            byte[] temp = new byte[18 + this.temp3.Count * 512];
            int flag = 0;
            //base.Child.Data_Child = new byte[18 + this.temp5.Count * 512];
            Array.Copy(DataConvert.Ushort_To_RBytes(this.temp), 0, temp, flag, 2);
            flag += 2;
            temp[flag++] = this.temp1;
            temp[flag++] = (byte)this.temp3.Count;
            if(this.temp2 != null)
                Array.Copy(this.temp2, 0, temp, flag, 14);
            flag = 18;
            for (int i = 0; i < this.temp3.Count; i++)
            {
                Array.Copy(this.temp3[i], 0, temp, flag + i * 512, 512);
            }
            this.Child.Data_Child = temp;
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
            this.temp4 = base.UshortLen;
        }
    }
}
