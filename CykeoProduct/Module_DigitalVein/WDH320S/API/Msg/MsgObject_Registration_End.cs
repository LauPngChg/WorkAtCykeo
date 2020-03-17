using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{    
        /// <summary>
         ///  注册结束 CMD_REG_END
         ///  为把注册生成的信息头和模板的进行处理。有三种方式：
         ///         1. 取消注册操作，每次采集时都可以使用此命令来结束注册手指流程。
         ///         2. 注册结果写入特征库，若已经存在相同 FID 的用户将会被覆盖；
         ///         3. 注册结果回传上位机。
         /// </summary>
    public class MsgObject_Registration_End:MessageObject
    {
        public enum eRegisterEndType
        {
            /// <summary>
            ///  取消本轮注册
            /// </summary>
            EndThisButContinue = 0x00,
            /// <summary>
            ///  注册的静脉特征写入设备数据库
            /// </summary>
            EndButWriteToDevice = 0x01,
            /// <summary>
            ///  注册结果回传上位机。       成功才会返回数据包，将注册的信息头和模板全部回传。单个静脉特征数据长度固定为 512 字节。
            /// </summary>
            EndButSendDataToApp = 0x02
        }
        private eRegisterEndType temp;
        private int temp1;
        private byte temp2;
        private byte temp3;
        private byte[] temp4;
        private byte[] temp6;
        private List<byte[]> temp5;

        public eRegisterEndType SetEndType { set => temp = value; }
        public int GetFingerID { get  {
                if (temp != eRegisterEndType.EndButSendDataToApp)
                    throw new ArgumentOutOfRangeException("This operation cannot obtain Registration Message.");
                return temp1;
            } }
        public byte GetGroupID { get  {
                if (temp != eRegisterEndType.EndButSendDataToApp)
                    throw new ArgumentOutOfRangeException("This operation cannot obtain Registration Message.");
                return temp2;
            } }
        public byte GetTempleNum { get {
                if (temp != eRegisterEndType.EndButSendDataToApp)
                    throw new ArgumentOutOfRangeException("This operation cannot obtain Registration Message.");
                return  temp3;
;
            }  }
        public List<byte[]> GetTempoleMsg { get  {
                if (temp != eRegisterEndType.EndButSendDataToApp)
                    throw new ArgumentOutOfRangeException("This operation cannot obtain Registration Message.");
                return temp5;
            }  }
        public byte[] GetDIYData
        {
            get
            {
                if (temp != eRegisterEndType.EndButSendDataToApp)
                    throw new ArgumentOutOfRangeException("This operation cannot obtain Registration Message.");
                return temp4;
            }
        }
        public byte[] GetTempoleHeader
        {
            get
            {
                if (temp != eRegisterEndType.EndButSendDataToApp)
                    throw new ArgumentOutOfRangeException("This operation cannot obtain Registration Message.");
                return temp6;
            }
        }
        public MsgObject_Registration_End()
        {
            this.temp = eRegisterEndType.EndThisButContinue;
            base.CmdCode = eCmdCode.CMD_REG_END;
            base.UshortLen = 0;
        }
        public override void CmdPacked()
        {
            base.SetData = (byte)this.temp;
        }
        public override void CmdUnpacked()
        {
            this.ReturnValue = this.GetResult == eAckCode.ERR_SUCCESS ? 0 : -1;
            this.ReturnMsg = this.GetResult.ToString();
            if (base.Child == null)
                return;
            temp5 = new List<byte[]>();
            byte[] temp = base.Child.Data_Child;
            temp1 = DataConvert.Bytes_To_Ushort(new byte[2] { temp[1], temp[0] });
            temp2 = temp[2];
            temp3 = temp[3];
            temp4 = DataConvert.ReadBytes(temp, 4, 14);
            temp6 = DataConvert.ReadBytes(temp, 0, 18);
            int flag = 18;
            for (int i = 0; i < temp3; i++)
            {
                temp5.Add(DataConvert.ReadBytes(temp, flag, 512));
                flag += 512;
            }
        }
    }
}
