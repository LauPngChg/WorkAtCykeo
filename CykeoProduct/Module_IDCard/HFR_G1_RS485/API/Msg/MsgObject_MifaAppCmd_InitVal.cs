using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public class MsgObject_MifaAppCmd_InitVal:MessageObject
    {
        eCardCount temp;
        eCheckKey temp1;
        byte temp2;
        byte[] temp3;
        byte[] temp4;
        byte[] temp5;
        public eCardCount SetSelectCardModel { set => temp = value; }
        public eCheckKey SetCheckKeyModel { set => temp1 = value; }
        /// <summary>
        ///  Block0 –开放给用户使用 	  Block1 –数据存储      Block2 –数据备份
        /// </summary>
        public byte SetInitAreaNum { set { if (value > 15 ) throw new ArgumentOutOfRangeException("No more than 0x0F "); temp2 = value; } }
        public byte[] SetKey { set { if (value.Length != 6) throw new ArgumentOutOfRangeException("The length can only be 6"); temp3 = value; } }
        public byte[] SetInitData { set { if (value.Length != 4) throw new ArgumentOutOfRangeException("The length can only be 4"); temp4 = value; } }
        public byte[] GetCardSerial { get => temp5; }
        public MsgObject_MifaAppCmd_InitVal()
        {
            base.CmdType = eCmdType.InitVal;
            temp = eCardCount.ACard;
            temp1 = eCheckKey.KeyB;
            temp2 = 0x04;
            temp3 = new byte[6] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            temp4 = new byte[4] { 0x00, 0x00, 0x00, 0x00 };
        }
        public override void CmdPacked()
        {
            base.Data = new byte[12];
            base.Data[0] = (byte)((byte)temp * 16 + (byte)temp1);
            base.Data[1] = temp2;
            Array.Reverse(temp3); Array.Reverse(temp4);
            Array.Copy(temp3, 0, base.Data, 2, 6);
            Array.Copy(temp4, 0, base.Data, 8, 4);
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
