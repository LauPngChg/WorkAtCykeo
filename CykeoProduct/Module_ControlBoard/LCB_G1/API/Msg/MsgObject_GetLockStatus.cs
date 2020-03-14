using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ControlBoard.LCB_G1.API.Msg
{
    public class MsgObject_GetLockStatus:MessageObject
    {
        private eLockID getLockID;
        private eSwitchStatus getLockStatus;
        private eLockID setUpAccessStatusLockID;
        public eLockID GetLockID { get => getLockID; }
        public eSwitchStatus GetLockStatus { get => getLockStatus; }
        public eLockID SetUpAccessStatusLockID {  set => setUpAccessStatusLockID = value; }
        public MsgObject_GetLockStatus()
        {
        }
        public override void CmdPacked()
        {
            base.CmdType = 0xA3;
            base.Data = new byte[1] { (byte)setUpAccessStatusLockID };
        }
        public override void CmdUnpacked()
        {
            if ((base.Data != null) && (this.Data.Length == 2))
            {
                this.ReturnValue = 0;
                getLockID = (eLockID)Data[0];
                getLockStatus = (eSwitchStatus)Data[1];
                base.ReturnMsg = getLockID + " " + getLockStatus;
        }
    }
    }
}
