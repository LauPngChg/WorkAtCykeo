using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    /// <summary>
    /// 上传所有手指的 ID 信息:上传模版库中所有手指的 FID，GID。获取成功则有附加数据帧
    /// </summary>
    public class MsgObject_UpLoad_AllFingerIDInformation:MessageObject
    {
        private ushort tempCount;
        private FingerID_GroupID[] temp;
        public ushort GetTempleCount { get => tempCount;  }
        public FingerID_GroupID[] GetFingerID_GroupID { get => temp;  }

        public MsgObject_UpLoad_AllFingerIDInformation()
        {
            base.CmdCode = eCmdCode.CMD_UPLOAD_ALL_ID;
            base.SetData = 0x00;
            base.UshortLen = 0x00;
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
            byte[] temp = base.Child.Data_Child;
            tempCount = DataConvert.Bytes_To_Ushort(new byte[2] { temp[1], temp[0] });
            this.temp = new FingerID_GroupID[tempCount];
            for (int i = 0; i < tempCount; i+=3)
            {
                this.temp[i].FingerID = DataConvert.Bytes_To_Ushort(new byte[2] { temp[i*3+3], temp[i * 3 + 2] });
                this.temp[i].GroupID = temp[i * 3 + 4];
            }
        }
    }
    public class FingerID_GroupID
    {
        private ushort temp1;
        private byte temp2;
        public ushort FingerID { get; internal set; }
        public byte GroupID { get; internal set; }
    }
}
