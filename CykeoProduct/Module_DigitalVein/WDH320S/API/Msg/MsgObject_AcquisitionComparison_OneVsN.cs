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
        private eAckCode result;
        private int findID ; 
        public eAckCode GetResult { get => result; }
        public int GetFindID { get => findID;  }

        public MsgObject_AcquisitionComparison_OneVsN()
        {
            base.CmdCode = eCmdCode.CMD_ONE_VS_N;
        } 
        public override void CmdPacked()
        {
            base.Data = 0x00;
            base.Data_Child = null;
        }
        public override void CmdUnpacked()
        {
            findID = base.Len == 0 ? -1 : base.Len;
            base.ReturnValue = 0;           
            base.ReturnMsg = (result = (eAckCode)base.Data).ToString();
        }
    }
}
