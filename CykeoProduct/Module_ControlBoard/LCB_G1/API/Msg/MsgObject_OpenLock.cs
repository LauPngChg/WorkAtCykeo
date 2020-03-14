using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ControlBoard.LCB_G1.API.Msg
{
    public class MsgObject_OpenLock:MessageObject
    {
        private eLockID setOpenLockID;
        private eLockID returnOpenLockID;
        public eLockID ReturnOpenLockID { get => returnOpenLockID; }
        public eLockID LockID { set => setOpenLockID = value; }

        public MsgObject_OpenLock()
        {
            base.CmdType = 0xA2;

        }
        public override void CmdPacked()
        {
            base.Data = new byte[1] { (byte)setOpenLockID };
        }
        public override void CmdUnpacked()
        {
            returnOpenLockID = (eLockID)base.Data[0];
            ReturnValue = 0;
            ReturnMsg = returnOpenLockID + "open success.";



        }
    }
}
