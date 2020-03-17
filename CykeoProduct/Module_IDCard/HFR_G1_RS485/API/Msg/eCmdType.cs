using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API.Msg
{
    public enum eCmdType
    {
        /// <summary>
        /// •	ISO14443 -A  Commands   寻卡请求  Find card request
        /// </summary>
        REQA = 0x03,
        /// <summary>
        /// •	ISO14443 -A  Commands  防冲突  anti-collision
        /// </summary>
        AntiCollision = 0x04,
        /// <summary>
        /// •	ISO14443 -A Commands   选定卡   The selected card
        /// </summary>
        Select = 0x05,
        /// <summary>
        /// •	ISO14443 -A Commands   使卡进入  HAIT状态
        /// </summary>
        Halt = 0x06,

        /// <summary>
        /// Mifare Application Commands:    集成寻卡，防冲突，选卡，验证密码，读卡等操作，一个命令完成读卡操作。
        /// </summary>
        Read = 0x20,
        /// <summary>
        /// Mifare Application Commands:    集成寻卡，防冲突，选卡，验证密码，写卡等操作，一个命令完成写卡操作。
        /// </summary>
        Write = 0x21,
        /// <summary>
        /// Mifare Application Commands:    集成寻卡，防冲突，选卡，验证密码等操作，一个命令完成块值初始化操作。
        /// </summary>
        InitVal = 0x22,
        /// <summary>
        /// Mifare Application Commands:    集成了寻卡，防冲突，选卡，验证密码，块值减操作，一个命令完成块减值操作。
        /// </summary>
        Decrement = 0x23,
        /// <summary>
        /// Mifare Application Commands:    集成了寻卡，防冲突，选卡，验证密码，块值加等操作，一个命令完成块值加操作。
        /// </summary>
        Increment = 0x24,
        /// <summary>
        /// Mifare Application Commands:    集成了寻卡，防冲突，选卡等操作，一个命令完成读取卡片序列号的操作
        /// </summary>
        GET_SNR = 0x25,
        /// <summary>
        /// Mifare Application Commands:    ISO14443 TypeA 通用命令，可以根据ISO14443 TypeA 向卡发任何数据
        /// </summary>
        ISO14443_TypeA_Transfer_Command = 0x28,

        /// <summary>
        /// 系统命令:   设置读写器地址
        /// </summary>
        SetAddress = 0x80,
        /// <summary>
        /// 系统命令:   设置通讯波特率
        /// </summary>
        SetBaudrate = 0x81,
        /// <summary>
        /// 系统命令:   设置读写器的序列号
        /// </summary>
        SetSerlNum = 0x82,
        /// <summary>
        /// 系统命令:   读取读写器的序列号
        /// </summary>
        GetSerlNum = 0x83,
        /// <summary>
        /// 系统命令:   设置用户数据信息
        /// </summary>
        Write_UserInfo = 0x84,
        /// <summary>
        /// 系统命令:   读取用户数据信息
        /// </summary>
        Read_UserInfo = 0x85,
        /// <summary>
        /// 系统命令:   用来读取模块的版本信息
        /// </summary>
        Get_VersionNum = 0x86,
        /// <summary>
        /// 系统命令:   控制led的工作方式
        /// </summary>
        Control_Led = 0x88,
        /// <summary>
        /// 系统命令:   控制buzzer的工作方式
        /// </summary>
        Control_Buzzer = 0x89,

    }
}
