using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public class MsgObject_MifaAppCmd_ISO14443_TypeA_Transfer_Command:MessageObject
    {
        bool temp;
        byte[] temp1;
        byte[] temp2;
        public bool IsCrcCheck { set => temp = value; }
        public byte[] SendData { set => temp1 = value; }
        public byte[]GetReturnData { get => temp2 ; }
        public MsgObject_MifaAppCmd_ISO14443_TypeA_Transfer_Command()
        {
            base.CmdType = eCmdType.ISO14443_TypeA_Transfer_Command;
        }
        public override void CmdPacked()
        {
            base.Data = new byte[temp1 == null ? 2 : temp1.Length + 2];
            base.Data[0] = (byte)(temp ? 1 : 0);
            base.Data[1] = (byte)(temp1==null ? 0 : temp1.Length);
            if (temp1 != null)
            {
                Array.Reverse(temp1);
                Array.Copy(temp1, 0, base.Data, 2, base.Data.Length);
            }
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
            if (base.Child != null && base.Child.Data != null && base.Child.Status == eReturnStatus.OK)
            {
                temp2 = base.Child.Data;
                Array.Reverse(temp2);
            }
        }
    }
}
