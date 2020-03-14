using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ControlBoard.LCB_G1.API.Msg
{
    public class MsgObject_ErrorMsg:MessageObject
    {
        private string msg;
        public string Msg { get => msg; }
        public MsgObject_ErrorMsg()
        {
        }
        public override void CmdPacked()
        {
            base.CmdPacked();
        }
        public override void CmdUnpacked()
        {
            switch (base.CmdType)
            {
                case 0xF1:
                    msg = "Error of control board address !";
                    ReturnValue = -1;
                    ReturnMsg = "Error of control board address !";
                    break;
                case 0xF2:
                    msg = "Error of BCC check!";
                    ReturnValue = -1;
                    ReturnMsg = "Error of BCC check!";
                    break;
                default:
                    break;
            }

        }
    }
}
