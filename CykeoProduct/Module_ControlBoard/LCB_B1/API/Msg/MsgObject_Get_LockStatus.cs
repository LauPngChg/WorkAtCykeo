using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ControlBoard.LCB_B1.API.Msg
{
    public class MsgObject_Get_LockStatus:MessageObject
    {
        public override void CmdPacked()
        {
            base.Data = new List<byte[]>() { new byte[1] { 0xF1 } };
        }
    }
}
