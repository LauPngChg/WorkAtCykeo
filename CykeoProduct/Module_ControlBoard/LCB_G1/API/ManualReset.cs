using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Module_ControlBoard.LCB_G1.API
{
    public class ManualReset
    {
        public ManualResetEvent ResetEvent;
        public Msg.MessageObject msgMethod;
        public ManualReset(bool status)
        {
            ResetEvent = new ManualResetEvent(status);
        }
    }
}
