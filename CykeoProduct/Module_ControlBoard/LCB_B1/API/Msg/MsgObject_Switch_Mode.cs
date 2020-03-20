using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ControlBoard.LCB_B1.API.Msg
{
    public class MsgObject_Switch_Mode:MessageObject
    {
        eMode temp;
        public eMode SwitchMode { set => temp = value; }
        public override void CmdPacked()
        {
            base.Data = new List<byte[]>();
            if (temp == eMode.TestMode)
                Data.Add(new byte[] { (byte)eMode.ManualMode });
            Data.Add(new byte[] { (byte)temp });
        }
    }
}
