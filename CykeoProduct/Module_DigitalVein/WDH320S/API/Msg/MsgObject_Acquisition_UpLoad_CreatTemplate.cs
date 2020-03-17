using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    /// <summary>
    ///  采集静脉特征并上传 CMD_CREAT_TEMPLATE
    /// </summary>
    public class MsgObject_Acquisition_UpLoad_CreatTemplate:MessageObject
    {
        private byte[] temp;
        /// <summary>
        /// 手指静脉生成静脉特征数据
        /// </summary>
        public byte[] GetAcquisitionUpLoadOneFingerTemple { get => temp;  }

        public MsgObject_Acquisition_UpLoad_CreatTemplate()
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
            this.ReturnValue = this.GetResult == eAckCode.ERR_SUCCESS ? 0 : -1;
            this.ReturnMsg = this.GetResult.ToString();
            if (base.Child != null)
                this.temp = base.Child.Data_Child;
        }
    }
}
