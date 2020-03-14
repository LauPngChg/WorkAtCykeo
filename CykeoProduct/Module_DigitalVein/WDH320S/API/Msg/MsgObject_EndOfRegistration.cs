using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_DigitalVein.WDH320S.API.Msg
{
    public class MsgObject_EndOfRegistration:MessageObject
    {
        /// <summary>
        ///  注册结束 CMD_REG_END
        ///  为把注册生成的信息头和模板的进行处理。有三种方式：
        ///         1. 取消注册操作，每次采集时都可以使用此命令来结束注册手指流程。
        ///         2. 注册结果写入特征库，若已经存在相同 FID 的用户将会被覆盖；
        ///         3. 注册结果回传上位机。
        /// </summary>
        public MsgObject_EndOfRegistration()
        {
            base.CmdCode = eCmdCode.CMD_REG_END;
        }
        public override void CmdPacked()
        {
            base.CmdPacked();
        }
        public override void CmdUnpacked()
        {
            base.CmdUnpacked();
        }
    }
}
