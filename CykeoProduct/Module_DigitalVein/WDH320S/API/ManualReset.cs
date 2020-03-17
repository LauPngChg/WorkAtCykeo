namespace Module_DigitalVein.WDH320S.API
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
