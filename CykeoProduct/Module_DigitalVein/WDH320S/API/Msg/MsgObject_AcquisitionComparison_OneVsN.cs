using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    /// <summary>
    ///  采集特征并 1:N 比对    CMD_ONE_VS_N
    /// </summary>
    public class MsgObject_AcquisitionComparison_OneVsN:MessageObject
    {
        private int fingerID ; 
        public int GetFingerID { get => fingerID;  }

        public MsgObject_AcquisitionComparison_OneVsN()
        {
            base.CmdCode = eCmdCode.CMD_ONE_VS_N;
            base.UshortLen = 0;
            base.SetData = 0x00;
        } 
        public override void CmdPacked()
        {
            base.CmdPacked();
        }
        public override void CmdUnpacked()
        {
            base.ReturnValue = (fingerID = base.UshortLen) == 0 ? -1 : 0;
            base.ReturnMsg = base.GetResult.ToString();
        }
    }
}
