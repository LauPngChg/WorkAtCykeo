using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public class MsgObject_SysCmd_SetAddress:MessageObject
    {
        byte temp;
        public byte NewAddress { set => temp = value; get => temp; }
        public MsgObject_SysCmd_SetAddress()
        {
            this.CmdType = eCmdType.SetAddress;

        }
        public override void CmdPacked()
        {
            base.Data = new byte[1] { temp };
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
            if (base.Child != null && base.Child.Data!=null && base.Child.Status == eReturnStatus.OK)
            {
                base.ReturnMsg += "    And new address is: " + base.Child.Data[0];
                temp = base.Child.Data[0];
            }
        }
    }
}
