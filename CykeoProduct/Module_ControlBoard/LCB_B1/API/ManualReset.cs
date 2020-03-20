namespace Module_ControlBoard.LCB_B1.API
{
    using System.Threading;
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
