using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Module_DigitalVein.WDH320S.API.Msg
{
    /// <summary>
    ///  采集特征并 1:G 比对  CMD_ONE_VS_ G
    /// </summary>
    public class MsgObject_Acquisition_Comparison_OneVsG : MessageObject
    {
        private byte temp;
        private ushort temp1;
        public ushort GetFingerID { get => temp1; }
        public byte SetGroupID {
            set {
                if (value < 0 || value > 100) 
                    throw new ArgumentOutOfRangeException("只能取0-100之间的整数" );
                temp = value;
            }
        }
        public MsgObject_Acquisition_Comparison_OneVsG()
        {
            base.CmdCode = eCmdCode.CMD_ONE_VS_G;
            base.UshortLen = 0; 
        }
        public override void CmdPacked()
        {
            base.SetData = temp;
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
            temp1 = base.UshortLen ;
        }
    }
}
