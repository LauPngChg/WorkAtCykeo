using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public enum eHaltModel { NotDoHalt = 0x00,DoHalt = 0x01}
    public class MsgObject_MifaAppCmd_SNR:MessageObject
    {
        eCardCount temp;
        eCheckKey temp1;
        eHaltModel temp2;
        eCardCount temp3;
        byte[] temp4;
        public eCardCount SetSelectCardModel { set => temp = value; }
        public eCheckKey SetCheckKeyModel { set => temp1 = value; }
        public eHaltModel SetIsDoHalt { set { temp2 = value; } }
        public eCardCount GetCardCount { get =>temp3; } 
        public byte[] GetCardSerial { get => temp4; }

        public MsgObject_MifaAppCmd_SNR()
        {
            base.CmdType = eCmdType.GET_SNR;
        }
        public override void CmdPacked()
        {
            base.Data = new byte[2] { (byte)((byte)temp * 16 + (byte)temp1), (byte)temp2 };
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
            if (base.Child != null && base.Child.Data != null && base.Child.Status == eReturnStatus.OK)
            {
                temp3 = (eCardCount)base.Child.Data[0];
                temp4 = DataConvert.ReadBytes(base.Child.Data, 1, 4);
                Array.Reverse(temp4);
            }
        }
    }
}
