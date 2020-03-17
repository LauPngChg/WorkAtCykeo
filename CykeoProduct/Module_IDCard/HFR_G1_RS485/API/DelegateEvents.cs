using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_IDCard.HFR_G1_RS485.API
{
    public delegate void delegateMessageReceived(Msg.MessageObject messageMethod);
    public delegate void delegateDisconnected();
}
