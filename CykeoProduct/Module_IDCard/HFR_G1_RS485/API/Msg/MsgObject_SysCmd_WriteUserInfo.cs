using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public class MsgObject_SysCmd_WriteUserInfo:MessageObject
    {
        byte[] temp;
        byte temp1;
        public byte[] WriteUserInfo { set { if (value.Length > 120) throw new ArgumentOutOfRangeException("The maximum write length of each block is 120"); temp = value; } }
        public byte AreaCode { set { if (value > 4) throw new ArgumentOutOfRangeException("No more than 3");temp1 = value; } }
        public MsgObject_SysCmd_WriteUserInfo()
        {
            base.CmdType = eCmdType.Write_UserInfo;
        }
        public override void CmdPacked()
        {
            if (temp != null)
            {
                base.Data = new byte[temp.Length + 2];
                base.Data[0] = temp1;
                base.Data[1] = (byte)temp.Length;
                Array.Copy(this.temp, 0, base.Data, 1, temp.Length);
            }
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
        }
    }
}
