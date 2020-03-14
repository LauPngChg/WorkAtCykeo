using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ControlBoard.LCB_G1.API.Msg
{
    public class MsgObject_SetBoardAddress:MessageObject
    {
        private byte setNewAddress;
        private byte returnNewAddress;
        public byte SetNewAddress { set => setNewAddress = value; }
        public byte ReturnNewAddress { get => returnNewAddress;  }

        public MsgObject_SetBoardAddress( )
        {
            base.CmdType = 0xA1;
            
        }
        public override void CmdPacked()
        {
            base.Data = new byte[1] { setNewAddress };
        }
        public override void CmdUnpacked()
        {
            returnNewAddress = base.Data[0];
            base.ReturnValue = 0;
            base.ReturnMsg = "New address :"+ returnNewAddress.ToString("X2") + " set success";
        }
    }
}
