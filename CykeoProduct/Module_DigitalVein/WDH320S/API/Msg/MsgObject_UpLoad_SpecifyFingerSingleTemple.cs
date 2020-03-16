using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    /// <summary>
    /// 上传指定手指的单个模板  上传模版库中指定 FID 手指的单个模板。
    /// </summary>
    public class MsgObject_UpLoad_SpecifyFingerSingleTemple:MessageObject
    {
        private ushort temp;
        private byte temp1;
        private byte[] temp2;
        public ushort SetFingerID { set => temp = value; }
        public byte SetFingerIDNum { set  {
                if (value < 0 || value > 10)
                    throw new ArgumentOutOfRangeException("You cannot enter Numbers greater than 10.");
                temp1 = value;
            } }
        public byte[] GetSpecifyFingerSingleTemple { get => temp2; }
        public MsgObject_UpLoad_SpecifyFingerSingleTemple()
        {
            base.CmdCode = eCmdCode.CMD_UPLOAD_TEMPLATE;           
        }
        public override void CmdPacked()
        {
            base.UshortLen = temp;
            base.SetData = temp1;
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
            if(base.Child!=null)
                temp2 = base.Child.Data_Child;
        }
    }
}
