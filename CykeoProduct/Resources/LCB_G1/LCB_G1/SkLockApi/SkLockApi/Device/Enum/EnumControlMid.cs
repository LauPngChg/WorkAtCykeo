using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkLockApi.Device.Enum
{
    /// <summary>
    /// 控制板配置管理消息列表
    /// </summary>
    public enum EnumControlMid
    { 
        /// <summary>
        /// 设置控制板地址
        /// </summary>
        SetControlAddr = 0xA1,
        /// <summary>
        /// 设置电磁锁状态
        /// </summary>
        SetLockStatus = 0xA2,
        /// <summary>
        /// 查询电磁锁状态
        /// </summary>
        GetLockStatus = 0xA3,
        /// <summary>
        /// 设置 LED 灯状态
        /// </summary>
        SetLedStatus = 0xA4,
        /// <summary>
        /// 查询设备版本
        /// </summary>
        GetControlEdition = 0xA5
    }
}
