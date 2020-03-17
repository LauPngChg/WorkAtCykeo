using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    public class MsgObject_Get_FirmwareVersion:MessageObject
    {
        private string temp;
        private string temp1;
        public string GetFirmwareVersion { get => temp;  }
        public string GetFirmwareTime { get => temp1;  }
        public MsgObject_Get_FirmwareVersion()
        {
            base.CmdCode = eCmdCode.CMD_UPLOAD_VERSION;
            base.UshortLen = 0x00;
            base.SetData = 0x00;
        }
        public override void CmdPacked()
        {
            base.CmdPacked();
        }
        public override void CmdUnpacked()
        {
            this.ReturnValue = this.GetResult == eAckCode.ERR_SUCCESS ? 0 : -1;
            this.ReturnMsg = this.GetResult.ToString();
            if (base.Child == null)
            {
                temp = temp1 = string.Empty;
                return;
            }

            temp = DataConvert.Bytes_To_String(DataConvert.ReadBytes(base.Child.Data_Child, 0, 20));
            temp1 = DataConvert.Bytes_To_String(DataConvert.ReadBytes(base.Child.Data_Child, 20, 10));//
        }
    }
}
