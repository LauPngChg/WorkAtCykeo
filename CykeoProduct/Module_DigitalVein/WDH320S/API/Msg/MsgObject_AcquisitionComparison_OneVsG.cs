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
        private eAckCode result;
        private byte groupID;
        private int findID;
        public eAckCode GetResult { get => result; }
        public int GetFindID { get => findID; }
        public byte SetGroupID {
            set {
                if (value < 0 || value > 100) 
                    throw new ArgumentOutOfRangeException("只能取0-100之间的整数" );
            }
        }

        public MsgObject_AcquisitionComparison_OneVsG()
        {
            base.CmdCode = eCmdCode.CMD_ONE_VS_G;
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
