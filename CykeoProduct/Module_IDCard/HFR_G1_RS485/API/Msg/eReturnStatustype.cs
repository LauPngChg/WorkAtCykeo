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
        /// 操作超时
        /// </summary>
        Type_TimeOut = 0x82,
        /// <summary>
        /// 卡不存在
        /// </summary>
        Type_CardNotExist = 0x83,
        /// <summary>
        /// 接收数据出错
        /// </summary>
        Type_ErrorData = 0x84,
        /// <summary>
        /// 参数或指令格式错误
        /// </summary>
        Type_FormatError = 0x85,
        /// <summary>
        /// 未知错误
        /// </summary>
        Type_UnknownError = 0x87,
        /// <summary>
        /// 指令不存在
        /// </summary>
        Type_CMD_NotExist = 0x8F,  
    }
}
