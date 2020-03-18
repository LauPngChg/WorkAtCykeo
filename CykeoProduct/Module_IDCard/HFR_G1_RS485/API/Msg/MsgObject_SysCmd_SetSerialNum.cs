using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public class MsgObject_SysCmd_SetSerialNum : MessageObject
    {
        byte[] temp;
        public byte[] SetSerialNum { set {  if (value.Length > 8) throw new ArgumentOutOfRangeException("The maximum length is 8"); temp = value; } }
        public MsgObject_SysCmd_SetSerialNum()
        {
            base.CmdType = eCmdType.SetSerlNum;
        }
        public override void CmdPacked()
        {
            base.Data = new byte[8];
            Array.Reverse(temp);
            if (temp.Length <= 8)
                for (int i = 0; i < temp.Length; i++)
                    base.Data[i] = temp[i];
            else
                for (int i = 0; i <8; i++)
                    base.Data[i] = temp[i];
            base.CmdPacked();
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
            if(base.Child!=null&&base.Child.Data!=null && base.Child.Status == eReturnStatus.OK)
            base.ReturnMsg += (eReturnStatusType)base.Child.Data[0];
        }
    }
}
