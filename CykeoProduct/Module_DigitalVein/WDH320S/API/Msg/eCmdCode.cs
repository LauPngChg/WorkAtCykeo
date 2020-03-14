using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    /// <summary>
    /// 命令编码分配
    /// </summary>
    public enum eCmdCode
    {
        /// <summary>
        /// 采集特征并1：N比对
        /// </summary>
        CMD_ONE_VS_N = 0x00,
        /// <summary>
        /// 采集特征并1：G比对
        /// </summary>
        CMD_ONE_VS_G = 0x01,
        /// <summary>
        /// 采集特征并1：1比对
        /// </summary>
        CMD_ONE_VS_ONE= 0x02,
        /// <summary>
        /// 注册手指静脉
        /// </summary>
        CMD_REGISTER = 0x03,
        /// <summary>
        /// 结束注册
        /// </summary>
        CMD_REG_END = 0x04,
        /// <summary>
        /// 删除单个手指
        /// </summary>
        CMD_DELETE_ONE = 0x05,
        /// <summary>
        /// 删除所有信息
        /// </summary>
        CMD_DELETE_ALL = 0x06,
        /// <summary>
        /// 上传所有手指ID
        /// </summary>
        CMD_UPLOAD_ALL_ID = 0x07,
        /// <summary>
        /// 上传指定手指信息
        /// </summary>
        CMD_UPLOAD_INFOR = 0x08,
        /// <summary>
        /// 上传指定手指模板
        /// </summary>
        CMD_UPLOAD_TEMPLATE = 0x09,
        /// <summary>
        /// 上传指定手指以及对应模板
        /// </summary>
        CMD_UOLOAD_INFOR_TEMPLATES = 0x0A,
        /// <summary>
        /// 上传最近采集模板
        /// </summary>
        CMD_UPLOAD_CURRENTTEMP = 0x0B,
        /// <summary>
        /// 下载手指信息头和所有模板
        /// </summary>
        CMD_DOWNLOAD_INFOR_TEMPLATES = 0x0C,
        /// <summary>
        /// 获取固件版本号
        /// </summary>
        CMD_UPLOAD_VERSION = 0x0D,
        /// <summary>
        /// 获取手指注册数量
        /// </summary>
        CMD_UPLOAD_COUNT = 0x0E,
        /// <summary>
        /// 检查手指状态
        /// </summary>
        CMD_CHK_FINGER = 0x0F,
            /// <summary>
            /// 获取序列号
            /// </summary>
        CMD_UPLOAD_SEQUENCE = 0x10,
            /// <summary>
            /// 设置波特率
            /// </summary>
        CMD_SET_BAUD= 0x11,
            /// <summary>
            /// 设置设备编号
            /// </summary>
        CMD_SET_DEVID= 0x12

    }
}
