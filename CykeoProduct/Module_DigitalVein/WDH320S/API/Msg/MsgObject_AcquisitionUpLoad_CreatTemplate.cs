using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    /// <summary>
    ///  采集静脉特征并上传 CMD_CREAT_TEMPLATE
    /// </summary>
    public class MsgObject_AcquisitionUpLoad_CreatTemplate:MessageObject
    {
        private byte[] extraData;
        /// <summary>
        /// 手指静脉生成静脉特征数据
        /// </summary>
        public byte[] ExtraData { get => extraData;  }

        public MsgObject_AcquisitionUpLoad_CreatTemplate()
        {
            base.CmdCode = eCmdCode.CMD_UPLOAD_CURRENTTEMP;
            base.SetData = 0x00;
            base.UshortLen = 0x00;
        }
        public override void CmdPacked()
        {
            base.CmdPacked();
        }
        public override void CmdUnpacked()
        {
            base.ReturnValue = base.UshortLen == 0 ? -1 : 0;
            base.ReturnMsg = base.GetResult.ToString();
            if (base.Child != null)
                extraData = base.Child.Data_Child;
        }
    }
}
