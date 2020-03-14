using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ControlBoard.LCB_G1.API.Msg
{
    public class MsgObject_SwitchLED:MessageObject
    {
        private eLedID lEDID;
        private eSwitchStatus switchStatus;
        public eLedID LED { set => lEDID = value; }
        public eSwitchStatus SwitchStatus {  set => switchStatus = value; }

        public MsgObject_SwitchLED()
        {
            base.CmdType = 0xA4;
        }
        public override void CmdPacked()
        {
            base.Data = new byte[2] { (byte)lEDID, (byte)switchStatus};
        }
        public override void CmdUnpacked()
        {
                ReturnValue = 0;
                ReturnMsg = lEDID + " " + switchStatus;
        }
    }
}
