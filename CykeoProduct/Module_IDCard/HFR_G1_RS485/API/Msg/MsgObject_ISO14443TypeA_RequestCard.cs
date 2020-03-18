using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public enum eREQA_Model  {OneCardOnce = 0x26,AllCardOnce = 0x52}
    public class MsgObject_ISO14443TypeA_RequestCard:MessageObject
    {
        eREQA_Model temp;
        byte[] temp1;
        public eREQA_Model RequestMode { set => temp = value; }
        public byte[] GetCardType { get => temp1; }
        public MsgObject_ISO14443TypeA_RequestCard()
        {
            base.CmdType = eCmdType.REQA;
        }
        public override void CmdPacked()
        {
            base.Data = new byte[1] { (byte)temp };
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
            if (base.Child != null && base.Child.Data != null && base.Child.Status == eReturnStatus.OK)
            {
                temp1 = base.Child.Data;
                Array.Reverse(temp1);
            }
        }
    }
}
