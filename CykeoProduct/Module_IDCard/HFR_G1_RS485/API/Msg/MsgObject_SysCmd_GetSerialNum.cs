using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public class MsgObject_SysCmd_GetSerialNum:MessageObject
    {
        byte[] temp1;
        byte temp2;
        public byte[] GetSerialNum { get =>temp1; }
        public byte GetAddress { get =>temp2; }
        public MsgObject_SysCmd_GetSerialNum()
        {
            base.CmdType = eCmdType.GetSerlNum;
        }
        public override void CmdPacked()
        {
            base.CmdPacked();
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
            if (base.Child != null&& base.Child.Data!=null && base.Child.Status == eReturnStatus.OK)
            {
                temp2 = base.Child.Data[0];
                temp1 = DataConvert.ReadBytes(base.Child.Data, 1, 8);
                Array.Reverse(temp1);
            }
        }
    }
}
