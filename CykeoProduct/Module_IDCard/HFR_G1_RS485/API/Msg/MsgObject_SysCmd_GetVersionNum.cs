using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public class MsgObject_SysCmd_GetVersionNum:MessageObject
    {
        byte[] temp;
        public byte[] GetVersionNum { get =>temp; }
        public MsgObject_SysCmd_GetVersionNum()
        {
            base.CmdType = eCmdType.Get_VersionNum;
        }
        public override void CmdPacked()
        {
            base.CmdPacked();
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
            if(base.Child!=null&&base.Child.Data!=null && base.Child.Status == eReturnStatus.OK)
            {
                temp = base.Child.Data;
                Array.Reverse(temp);
            }
        }
    }
}
