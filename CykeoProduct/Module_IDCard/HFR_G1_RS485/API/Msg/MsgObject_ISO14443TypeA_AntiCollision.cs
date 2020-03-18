using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public enum eCardCount
    { 
        ACard=0x00,ManyCard = 0x01
    }
    public class MsgObject_ISO14443TypeA_AntiCollision:MessageObject
    {
        eCardCount temp;
        byte[] temp1;
        public eCardCount MultipleCard { get => temp; }
        public byte[] UID_Card { get => temp1; }

        public MsgObject_ISO14443TypeA_AntiCollision()
        {
            base.CmdType = eCmdType.AntiCollision;
        }
        public override void CmdPacked()
        {
            base.CmdPacked();
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
            if (base.Child != null && base.Child.Data != null&&base.Child.Status== eReturnStatus.OK)
            {
                temp = (eCardCount)base.Child.Data[0];
                temp1 = DataConvert.ReadBytes(base.Child.Data, 1, 4);
                Array.Reverse(temp1);
            }
        }
    }
}
