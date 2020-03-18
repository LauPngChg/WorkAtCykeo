using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public class MsgObject_SysCmd_ReadUserInfo:MessageObject
    {
        byte[] temp;
        byte temp1;
        byte temp2;
        public byte[] GetUserInfo { get => temp; }
        public byte ReadAreaCode { set { if (value > 4) throw new ArgumentOutOfRangeException("No more than 3");temp1 = value; } }
        public byte ReadLength { set { if (value > 120) throw new ArgumentOutOfRangeException("No more than 120");temp2 = value; } }
        public MsgObject_SysCmd_ReadUserInfo()
        {
            base.CmdType = eCmdType.Read_UserInfo;
        }
        public override void CmdPacked()
        {
            base.Data = new byte[2] { temp1, temp2 };
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
            if (base.Child != null&&base.Child.Data!=null && base.Child.Status == eReturnStatus.OK)
            {
                temp = base.Child.Data;
                Array.Reverse(temp);
            }
        }
    }
}
