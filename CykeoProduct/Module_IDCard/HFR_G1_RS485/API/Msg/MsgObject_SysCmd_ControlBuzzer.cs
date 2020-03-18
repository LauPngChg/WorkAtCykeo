using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public class MsgObject_SysCmd_ControlBuzzer : MessageObject
    {
        eSwitch temp;
        public eSwitch Switch { set => temp = value; }
        public MsgObject_SysCmd_ControlBuzzer()
        {
            base.CmdType = eCmdType.Control_Buzzer;
        }
    public override void CmdPacked()
    {
            base.Data = new byte[1] { (byte)temp };
    }
    public override void CmdUnpacked()
    {
        base.CmdUnpacked();
    }
}
}
