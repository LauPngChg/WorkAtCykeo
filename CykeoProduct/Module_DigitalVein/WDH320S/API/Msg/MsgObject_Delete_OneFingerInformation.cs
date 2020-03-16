using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    /// <summary>
    ///  删除单个手指 : 删除指定的单个手指 FID 的信息头和所有模板。
    /// </summary>
    public class MsgObject_Delete_OneFingerInformation : MessageObject
    {
        private ushort temp;

        public ushort SetFingID { set => temp = value; }

        public MsgObject_Delete_OneFingerInformation()
        {
            base.CmdCode = eCmdCode.CMD_DELETE_ONE;
            base.SetData = 0x00;
        }


        public override void CmdPacked()
        {
            temp = base.SetData;
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
        }
    }
}
