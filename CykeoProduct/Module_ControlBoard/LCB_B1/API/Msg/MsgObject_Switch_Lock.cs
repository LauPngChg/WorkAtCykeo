using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ControlBoard.LCB_B1.API.Msg
{
    public class MsgObject_Switch_Lock:MessageObject
    {
        eLock temp;
        public eLock OpenLock { set => temp = value; }
        public override void CmdPacked()
        {
            base.Data = new List<byte[]>() { new byte[1] { (byte)((byte)this.temp > 8 ? (177 + (byte)this.temp - 9) : (161 + (byte)this.temp - 1)) } };
        }
    }
}
