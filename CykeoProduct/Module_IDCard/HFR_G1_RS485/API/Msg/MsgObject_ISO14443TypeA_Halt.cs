using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public class MsgObject_ISO14443TypeA_Halt:MessageObject
    {
        public MsgObject_ISO14443TypeA_Halt()
        {
            base.CmdType = eCmdType.Halt;
        }
        public override void CmdPacked()
        {
            base.CmdPacked();
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
        }
    }
}
