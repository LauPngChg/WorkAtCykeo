using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    public class MsgObject_Check_FingerStatus : MessageObject
    {
        bool temp;
        public bool IsPutOK { get => temp; }
        public MsgObject_Check_FingerStatus()
        {
            base.CmdCode = eCmdCode.CMD_CHK_FINGER;
            base.UshortLen = 0x00;
            base.SetData = 0x000;
        }
        public override void CmdPacked()
        {
            base.CmdPacked();
        }
        public override void CmdUnpacked()
        {
            this.ReturnValue = ( temp = this.GetResult == eAckCode.ERR_SUCCESS ) ? 0 : -1;
            this.ReturnMsg = this.GetResult.ToString();
        }
    }    
}
