using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    public class MsgObject_Get_DeviceSerialNum:MessageObject
    {
        string temp;
        public string GetSerialNum { get => temp; }
        public MsgObject_Get_DeviceSerialNum()
        {
            base.CmdCode = eCmdCode.CMD_UPLOAD_SEQUENCE;
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
                return;
            temp = DataConvert.Bytes_To_String(base.Child.Data_Child);
        }
    }
}
