using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Module_DigitalVein.WDH320S.API.Msg
{
    /// <summary>
    ///  采集特征并 1:G 比对  CMD_ONE_VS_ G
    /// </summary>
    public class MsgObject_AcquisitionComparison_OneVsG : MessageObject
    {
        private byte groupID;
        private int fingerID;
        public int GetFingerID { get => fingerID; }
        public byte SetGroupID {
            set {
                if (value < 0 || value > 100) 
                    throw new ArgumentOutOfRangeException("只能取0-100之间的整数" );            }
        }
        public MsgObject_AcquisitionComparison_OneVsG()
        {
            base.CmdCode = eCmdCode.CMD_ONE_VS_G;
            base.UshortLen = 0; 
        }
        public override void CmdPacked()
        {
            base.SetData = groupID;
        }
        public override void CmdUnpacked()
        {
            base.ReturnValue = (fingerID = base.UshortLen) == 0 ? -1 : 0;
            base.ReturnMsg = base.GetResult.ToString();
        }
    }
}
