namespace Module_IDCard.HFR_G1_RS485.API
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
