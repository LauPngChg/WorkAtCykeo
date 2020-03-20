namespace Module_ControlBoard.LCB_B1.API
{
    public delegate void delegateMessageReceived(Msg.MessageObject messageMethod);
    public delegate void delegateDisconnected();

    public delegate void delegateSwitchLock(Msg.NotifyLockStatus lockStatus);

}
