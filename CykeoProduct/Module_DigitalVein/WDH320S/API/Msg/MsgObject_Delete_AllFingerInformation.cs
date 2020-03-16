using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    /// <summary>
    ///  删除所有手指    删除指定的所有手指 FID 的信息头和所有模板。
    /// </summary>
    public class MsgObject_Delete_AllFingerInformation:MessageObject
    {
        public MsgObject_Delete_AllFingerInformation()
        {
            base.CmdCode = eCmdCode.CMD_DELETE_ALL;
            base.SetData = 0x00;
            base.UshortLen = 0x00;
        }
        public override void CmdPacked()
        {
            base.CmdPacked();
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
        }
    }
}
