using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ControlBoard.LCB_G1.API
{
    public delegate void delegateMessageReceived(Msg.MessageObject messageMethod);
    public delegate void delegateDisconnected();

    public delegate void delegateSwitchLock(Msg.MsgObject_GetLockStatus lockStatus);
    public delegate void delegateErrorMsg(Msg.MsgObject_ErrorMsg error);

}
