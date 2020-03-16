using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    /// <summary>
    /// 采集特征并 1:1 比对 CMD_ONE_VS_ONE
    /// </summary>
    public class MsgObject_Acquisition_Comparison_OneVsOne:MessageObject
    {
        private ushort temp;
        public ushort _FingerID { get => temp; set => temp = value; }
        public MsgObject_Acquisition_Comparison_OneVsOne()
        {
            base.CmdCode = eCmdCode.CMD_ONE_VS_ONE;            
            base.SetData = 0x00;
        } 
        public override void CmdPacked()
        {
            base.UshortLen = this.temp;
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
            this.temp = base.UshortLen;
        }
    }
}
