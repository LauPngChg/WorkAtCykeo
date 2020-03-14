using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    /// <summary>
    /// 采集特征并 1:1 比对 CMD_ONE_VS_ONE
    /// </summary>
    public class MsgObject_AcquisitionComparison_OneVsOne:MessageObject
    {
        private ushort fingerID;
        public ushort SetFinerID {  set => fingerID = value; }
        public MsgObject_AcquisitionComparison_OneVsOne()
        {
            base.CmdCode = eCmdCode.CMD_ONE_VS_ONE;            
            base.SetData = 0x00;
        } 
        public override void CmdPacked()
        {
            base.UshortLen = fingerID;
        }
        public override void CmdUnpacked()
        {
            base.ReturnValue = (fingerID = base.UshortLen) == 0 ? -1 : 0;
            base.ReturnMsg = base.GetResult.ToString();
        }
    }
}
