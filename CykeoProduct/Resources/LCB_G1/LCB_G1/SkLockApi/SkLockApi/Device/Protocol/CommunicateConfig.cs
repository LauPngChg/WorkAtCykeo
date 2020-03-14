using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkLockApi.Device.Protocol
{
    /// <summary>
    /// 通讯配置
    /// </summary>
    public class CommunicateConfig
    {
        /// <summary>
        /// 串口号
        /// </summary>
        public string ControlIp { get; set; }

        /// <summary>
        /// 串口波特率
        /// </summary>
        public int ControlBaudrate { get; set; }
    }
}
