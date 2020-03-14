using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ControlBoard.LCB_G1.API.Msg
{
    public  class MsgObject_GetVersion:MessageObject
    {
        private string getVersion;

        public string GetVersion { get => getVersion; set => getVersion = value; }

        public MsgObject_GetVersion()
        {
            base.CmdType = 0xA5;

        }
        public override void CmdPacked()
        {
            base.Data = new byte[1] { 0x00 };
        }
        public override void CmdUnpacked()
        {
            if (base.Data.Length == 2)
            {
                ReturnValue = 0;
                ReturnMsg = "Get Version Success";
                getVersion = "V." + this.Data[0] + "." + Data[1];
            }
        }
    }
}
