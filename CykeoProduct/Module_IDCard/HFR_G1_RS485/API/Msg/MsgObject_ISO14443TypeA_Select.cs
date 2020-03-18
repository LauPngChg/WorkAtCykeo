using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public class MsgObject_ISO14443TypeA_Select:MessageObject
    {
        byte[] temp;
        public byte[] SelectUID { set { if (value.Length != 4) throw new ArgumentException("Only length 4 is valid "); temp = value; } get => temp; }
        public MsgObject_ISO14443TypeA_Select()
        {
            base.CmdType = eCmdType.Select;
        }
        public override void CmdPacked()
        {
            Array.Reverse(temp);
            if (temp.Length == 4)
                base.Data = temp;
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
            if (base.Child != null && base.Child.Data != null && base.Child.Status == eReturnStatus.OK)
            {
                temp = base.Child.Data;
                Array.Reverse(temp);
            }
        }
    }
}
