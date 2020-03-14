using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    public class MsgObject_SingleRegisterFinger:MessageObject
    {
        private byte groupID;
        private ushort fingerID;        
        public byte SetGroupID
        {
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("只能取0-100之间的整数");
            }
        }
        public ushort SetFingerID { set => fingerID = value; }
        /// <summary>
        ///  单次注册手指 CMD_REGISTER
        /// </summary>
        public MsgObject_SingleRegisterFinger()
        {
            base.CmdCode = eCmdCode.CMD_REGISTER;            
        }
        public override void CmdPacked()
        {
            base.SetData = groupID;
            base.UshortLen = fingerID;
        }
        public override void CmdUnpacked()
        {
            base.ReturnValue = base.GetResult == eAckCode.ERR_SUCCESS ? 0 : -1;
            base.ReturnMsg = base.GetResult.ToString();
        }
    }
}
