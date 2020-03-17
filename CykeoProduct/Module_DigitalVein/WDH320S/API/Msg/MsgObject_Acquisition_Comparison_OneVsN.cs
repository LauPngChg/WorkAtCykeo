using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    /// <summary>
    ///  采集特征并 1:N 比对    CMD_ONE_VS_N
    /// </summary>
    public class MsgObject_Acquisition_Comparison_OneVsN:MessageObject
    {
        private int temp ; 
        public int GetFingerID { get => temp;  }

        public MsgObject_Acquisition_Comparison_OneVsN()
        {
            base.CmdCode = eCmdCode.CMD_ONE_VS_N;
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
            this.temp = base.UshortLen;
        }
    }
}
