using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API
{
    public delegate void delegateMessageReceived(Msg.MessageObject_Child messageMethod);
    public delegate void delegateDisconnected();
}
