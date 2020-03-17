using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    public class MsgObject_Set_DeviceID:MessageObject
    {
        byte temp;
        public byte SetDeviceID { set => temp = value; }
        public MsgObject_Set_DeviceID()
        {
            base.CmdCode = eCmdCode.CMD_SET_DEVID;
            base.UshortLen = 0x00;
        }
        public override void CmdPacked()
        {
            base.SetData = this.temp;
        }
        public override void CmdUnpacked()
        {
            this.ReturnValue = (this.GetResult == eAckCode.ERR_SUCCESS&&base.DevId == this.temp) ? 0 : -1;
            this.ReturnMsg = this.GetResult.ToString();            
        }
    }
}
