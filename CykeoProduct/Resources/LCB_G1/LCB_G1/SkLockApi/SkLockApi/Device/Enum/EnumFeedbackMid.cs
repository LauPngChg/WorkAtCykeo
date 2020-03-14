using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkLockApi.Device.Enum
{
    /// <summary>
    /// 控制板反馈消息列表
    /// </summary>
    public enum EnumFeedbackMid
    {
        /// <summary>
        /// 设置控制板地址反馈
        /// </summary>
        SetControlAddr = 0xC1,
        /// <summary>
        /// 设置电磁锁状态反馈
        /// </summary>
        SetLockStatus = 0xC2,
        /// <summary>
        /// 获取电磁锁状态反馈
        /// </summary>
        GetLockStatus = 0xC3,
        /// <summary>
        /// 设置 LED 灯状态反馈
        /// </summary>
        SetLedStatus = 0xC4,
        /// <summary>
        /// 获取 LED 灯状态反馈
        /// </summary>
        GetControlEdition = 0xC5,
        /// <summary>
        /// 地址错误匹配反馈
        /// </summary>
        AddrError = 0xF1,
        /// <summary>
        /// 帧校验错误匹配反馈
        /// </summary>
        FrameCheckError = 0xF2
    }
}
