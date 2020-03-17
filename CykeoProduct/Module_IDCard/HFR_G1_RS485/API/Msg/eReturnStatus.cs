using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public enum eReturnStatus
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        OK = 0x00,
        /// <summary>
        /// 操作失败
        /// </summary>
        FAIL = 0x01, 
    }
}
