using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public enum eLed { LED1=0x01,LED2=0x02}
    public enum eSwitch { Close=0x00,Open=0x01}
    public class MsgObject_SysCmd_ControlLED:MessageObject
    {
        eLed temp;
        eSwitch temp1;
        public eLed Led { set => temp = value; }
        public eSwitch Switch { set => temp1 = value; }
        public MsgObject_SysCmd_ControlLED()
        {
            base.CmdType = eCmdType.Control_Led;
        }
        public override void CmdPacked()
        {
            base.Data = new byte[2] { (byte)temp, (byte)temp1 };
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
        }

    }
}
