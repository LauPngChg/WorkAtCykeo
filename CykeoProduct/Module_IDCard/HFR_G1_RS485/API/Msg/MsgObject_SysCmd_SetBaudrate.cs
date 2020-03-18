using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public enum eBaudrate
    { 
        bps9600 = 0x00,
        bps19200 = 0x01,
        bps38400 = 0x02,
        bps57600 = 0x03,
        bps115200 = 0x04,
    }
    public class MsgObject_SysCmd_SetBaudrate:MessageObject
    {
        eBaudrate temp;
        public eBaudrate NewBaudrate { set => temp = value; }
        public MsgObject_SysCmd_SetBaudrate()
        {
            base.CmdType = eCmdType.SetBaudrate;
        }
        public override void CmdPacked()
        {
            base.Data = new byte[1] { (byte)temp };
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
            if (base.Child != null && base.Child.Data != null && base.Child.Status == eReturnStatus.OK)
                base.ReturnMsg += "    And new Baudrate is:" + (eBaudrate)base.Child.Data[0];
        }
    }
}
