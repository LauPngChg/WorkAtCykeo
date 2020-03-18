using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public class MsgObject_MifaAppCmd_Write:MessageObject
    {
        eCardCount temp;
        eCheckKey temp1;
        byte temp2;
        byte temp3;
        byte[] temp4;
        byte[] temp5;
        byte[] temp6;
        public eCardCount SetSelectCardModel { set => temp = value; }
        public eCheckKey SetCheckKeyModel { set => temp1 = value; }
        public byte SetWriteAreaCount { set { if (value > 4 || value <= 0) throw new ArgumentOutOfRangeException("You can only use 1, 2, 3, 4 "); temp2 = value; } }
        public byte SetWriteStartAddress { set { if (value > 0x3F) throw new ArgumentOutOfRangeException("No more than 0x3F"); temp3 = value; } }
        public byte[] SetKey { set { if (temp4.Length != 6) throw new ArgumentOutOfRangeException("The length can only be 6"); temp4 = value; } }
        public byte[] GetCardSerial { get => temp5; }
        public byte[] SetWriteData { set => temp6 = value; }


        public MsgObject_MifaAppCmd_Write()
        {
            base.CmdType = eCmdType.Write;
            temp = eCardCount.ACard;
            temp1 = eCheckKey.KeyB;
            temp2 = 0x01;
            temp3 = 0x10;
            temp4 = new byte[6] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        }
        public override void CmdPacked()
        {
            base.Data = new byte[9 + temp6.Length];
            base.Data[0] = (byte)((byte)temp * 16 + (byte)temp1);
            base.Data[1] = temp2;
            base.Data[2] = temp3;
            Array.Reverse(temp4); Array.Reverse(temp6);
            Array.Copy(temp4, 0, base.Data, 3, 6);
            Array.Copy(temp6, 0, base.Data, 9, temp6.Length);
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
            if (base.Child != null && base.Child.Data != null && base.Child.Status == eReturnStatus.OK)
            {
                temp5 = base.Child.Data;
                Array.Reverse(temp5);
            }
        }
    }
}
