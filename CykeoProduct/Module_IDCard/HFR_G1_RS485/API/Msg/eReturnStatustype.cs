using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public enum eReturnStatusType
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        Type_Success = 0x80,   
        /// <summary>
        /// 操作失败
        /// </summary>
        Type_Fail = 0x81, 
        /// <summary>
        /// 参数或指令格式错误
        /// </summary>
        Type_FormatError = 0x85, 
        /// <summary>
        /// 指令不存在
        /// </summary>
        Type_CMD_NotExist = 0x8F,  
    }
}
