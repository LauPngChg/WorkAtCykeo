using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    public class MsgObject_Registration_SingleAcquisition:MessageObject
    {
        private byte temp;
        private ushort temp1;        
        public byte SetGroupID
        {
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("只能取0-100之间的整数");
                temp = value;
            }
        }
        public ushort SetFingerID { set => temp1 = value; }
        /// <summary>
        ///  单次注册手指 CMD_REGISTER
        /// </summary>
        public MsgObject_Registration_SingleAcquisition()
        {
            base.CmdCode = eCmdCode.CMD_REGISTER;            
        }
        public override void CmdPacked()
        {
            base.SetData = temp;
            base.UshortLen = temp1;
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
        }
    }
}
