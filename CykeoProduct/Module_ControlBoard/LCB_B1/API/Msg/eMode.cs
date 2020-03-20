using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ControlBoard.LCB_B1.API.Msg
{
    public enum eMode
    {
        /// <summary>
        /// 手控模式：可以单独控制每个LED的亮与灭
        /// </summary>
        ManualMode=0xE9,
        /// <summary>
        /// 柜控模式：不能单独控制LED亮与灭。比如锁1开则灯1亮，锁1关则灯1灭；锁6开则灯6亮，锁6关则灯6灭；
        /// </summary>
        AutoMode = 0xEA,
        /// <summary>
        /// 测试模式：进入测试模式之前必须先切换到手控模式否则挂掉。测试模式是弹开所有锁、所有灯亮。测试模式单次有效，结束自动退出返回手动模式。
        /// </summary>
        TestMode = 0XA9
    }
}
