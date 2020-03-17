using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    public class MsgObject_Get_CountOfRegistrationFinger:MessageObject
    {
        private ushort temp;
        public ushort GetRegistrationFingerNum { get => temp;  }
        public MsgObject_Get_CountOfRegistrationFinger()
        {
            base.CmdCode = eCmdCode.CMD_UPLOAD_COUNT;
            base.UshortLen = 0x00;
            base.SetData = 0x00;
        }
        public override void CmdPacked()
        {
            base.CmdPacked();
        }
        public override void CmdUnpacked()
        {
            this.ReturnValue = this.GetResult == eAckCode.ERR_SUCCESS ? 0 : -1;
            this.ReturnMsg = this.GetResult.ToString();
            temp = base.UshortLen;
        }
    }
}
