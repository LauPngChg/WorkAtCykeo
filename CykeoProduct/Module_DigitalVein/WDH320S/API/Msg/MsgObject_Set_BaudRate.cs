using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    public enum eBaudRate
    {
        bps9600 = 0x01, bps19200 =0x02, bps57600=0x06, bps115200=0x0C
    }
    public class MsgObject_Set_BaudRate:MessageObject
    {
        eBaudRate temp;
        public eBaudRate SetBaudRate { set => temp = value; }
        public MsgObject_Set_BaudRate()
        {
            base.CmdCode = eCmdCode.CMD_SET_BAUD;
            base.UshortLen = 0x00;
        }
        public override void CmdPacked()
        {
            base.SetData = (byte)temp;
        }
        public override void CmdUnpacked()
        {
            this.ReturnValue = this.GetResult == eAckCode.ERR_SUCCESS ? 0 : -1;
            this.ReturnMsg = this.GetResult.ToString();
        }
    }
}
