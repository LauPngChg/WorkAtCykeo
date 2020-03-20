using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ControlBoard.LCB_B1.API.Connected
{
    public class ConnectedMethod
    {
        #region 事件上报开关
        public delegateMessageReceived dMsgReceived;
        public delegateDisconnected dDisconnected;
        public delegateSwitchLock dLockStatus;

        #endregion
        public bool LinkStatus;
        private Msg.RingBuffer ringBuffer;
        private ConnectedBase BaseConnect;
        private int timeOut;
        private string ReaderName;
        private Dictionary<byte, ManualReset> dictionary;
        public byte Address { get; set; }

        public ConnectedMethod()
        {
            timeOut = 3000;
            dictionary = new Dictionary<byte, ManualReset>();
        }
        public bool Close()
        {
            try
            {
                if (BaseConnect != null)
                {
                    LinkStatus = false;
                    BaseConnect.isConnected = false;
                    BaseConnect.Closed();
                    BaseConnect.RececivedRemoveMethod(new delegateMessageReceived(this.SortMessage));
                    BaseConnect = null;
                    return true;
                }
            }
            catch { }
            return false;
        }

        public bool OpenRs232(string readerName)
        {
            BaseConnect = new ConnectedTypeSerial();
            BaseConnect.ReceivedCombineMethod(new delegateMessageReceived(this.SortMessage));
            if (BaseConnect.Connected(readerName))
            {
                this.ReaderName = readerName;
                BaseConnect.isConnected = true;
                LinkStatus = true;
                return true;
            }
            else
            {
                this.Close();
                return false;
            }
        }

        public void SendMsg(Msg.MessageObject msgObject)
        {
            if (msgObject != null)
            {              
                BaseConnect.SendMsg(msgObject);
            }
        }  

        private void SortMessage(Msg.MessageObject msgObject)
        {
            try
            {
                if (msgObject == null)
                    return;
                Msg.NotifyLockStatus getLockStatus = new Msg.NotifyLockStatus
                {
                    Data = msgObject.Data
                };
                getLockStatus.Unpacked();
                if (dLockStatus != null)
                    dLockStatus(getLockStatus);         
            }
            catch { }
        }
    }
}
