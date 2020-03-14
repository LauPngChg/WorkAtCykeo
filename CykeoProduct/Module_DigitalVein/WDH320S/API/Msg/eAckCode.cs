using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    public enum eAckCode
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        ERR_SUCCESS = 0x00,
        /// <summary>
        /// 操作失败
        /// </summary>
        ERR_FALT = 0x01,
        /// <summary>
        /// 操作超时
        /// </summary>
        ERR_TIMEOUT = 0x02,
        /// <summary>
        /// 信息头存储空间满
        /// </summary>
        ERR_INFOR_FULL = 0x03,
        /// <summary>
        /// 模板存储空间满
        /// </summary>
        ERR_TEMPLATE_FULL = 0x04,
        /// <summary>
        /// 模板已存在
        /// </summary>
        ERR_TEMPLATE_OCC = 0x05,
        /// <summary>
        /// FID已存在
        /// </summary>
        ERR_FINGERID_OCC = 0x06,
        /// <summary>
        /// 不存在该FID
        /// </summary>
        ERR_FINGERID_NULL = 0x07,
        /// <summary>
        /// 不存在该组号
        /// </summary>
        ERR_GROUPID_NULL = 0x08,
        /// <summary>
        /// Flash操作失败
        /// </summary>
        ERR_FALSH = 0x09,
        /// <summary>
        /// 采集生成特征与前一次差异过大
        /// </summary>
        ERR_REG_DIFF = 0x0A,
        /// <summary>
        /// 注册超时
        /// </summary>
        ERR_REG_TIMEOUT = 0x0B,
        /// <summary>
        /// 连续注册失败次数过多
        /// </summary>
        ERR_REG_UNUSUAL = 0x0C,
        /// <summary>
        /// 与前一次采集手指下发信息不同
        /// </summary>
        ERR_REG_INFO = 0x0D,
        /// <summary>
        /// 未检测到手指
        /// </summary>
        ERR_NO_FINGER = 0x0E,
        /// <summary>
        /// 注册模板缓存区满
        /// </summary>
        ERR_REG_BUFFFULL = 0x0F,
        /// <summary>
        /// 生成的模板不合格
        /// </summary>
        ERR_TEMPLATE = 0x10,
        /// <summary>
        /// 拍照超时
        /// </summary>
        ERR_CAP = 0x11
    }
}
