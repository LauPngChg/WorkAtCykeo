using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace Module_ControlBoard.LCB_G1.API.Connected
{
    public class ConnectedMethod
    {
        #region 事件上报开关
        public delegateMessageReceived dMsgReceived;
        public delegateDisconnected dDisconnected;
        public delegateSwitchLock dSwitchLock;
        public delegateErrorMsg dErrorMsg;
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

        public void SendSyncMsg(Msg.MessageObject msgObject)
        {
            this.SendSyncMsg(msgObject, this.timeOut);
        }
        public void SendSyncMsg(Msg.MessageObject msgObject, int tiemOut)
        {
            if (msgObject != null)
            {
                if (dictionary == null)
                {
                    dictionary = new Dictionary<byte, ManualReset>();
                }
                byte key = msgObject.ToKey();
                if (!dictionary.ContainsKey(key))
                {
                    ManualReset manualReset = new ManualReset(false) { msgMethod = null };
                    dictionary.Add(key, manualReset);
                }
                else
                {
                    dictionary[key].msgMethod = null;
                    dictionary[key].ResetEvent.Reset();
                }
                WaitHandle[] waitHandles = new WaitHandle[] { dictionary[key].ResetEvent };
                BaseConnect.SendMsg(msgObject);
                int num = WaitHandle.WaitAny(waitHandles, tiemOut, false);
                try
                {
                    if ((num == 0) && (dictionary[key].msgMethod != null))
                    {
                        msgObject.FrameMsg = dictionary[key].msgMethod.FrameMsg;
                        msgObject.CmdUnpacked(dictionary[key].msgMethod.Data);
                    }
                }
                catch { }
            }
        }
        public void SendNoSyncMsg(Msg.MessageObject msgObject)
        {
            if (msgObject != null)
            {
                this.BaseConnect.SendMsg(msgObject);
            }
        }
        public void SendNoSyncMsg(byte[] msgBytes)
        {
            if (msgBytes != null)
            {
                this.BaseConnect.SendMsg(msgBytes);
            }
        }

        private void SortMessage(Msg.MessageObject msgObject)
        {
            try
            {
                if (msgObject == null)
                    return;
                byte head = (byte)(msgObject.CmdType & 0xF0);
                if (head == 0xC0)
                {
                    if (msgObject.CmdType == 0xC3)
                    {
                        Msg.MsgObject_GetLockStatus getLockStatus = new Msg.MsgObject_GetLockStatus
                        {
                            FrameMsg = msgObject.FrameMsg,Data = msgObject.Data
                        };
                        getLockStatus.CmdUnpacked();
                        if (dSwitchLock != null)
                            dSwitchLock(getLockStatus);
                        return;
                    }
                    byte key = msgObject.ToKey();
                    if (dictionary.ContainsKey(key))
                    {
                        dictionary[key].msgMethod = msgObject;
                        dictionary[key].ResetEvent.Set();
                    }
                }
                else if (head == 0xF0)
                {
                    Msg.MsgObject_ErrorMsg error = new Msg.MsgObject_ErrorMsg
                    {
                        CmdType = msgObject.CmdType
                    };
                    error.CmdUnpacked();
                    if (dErrorMsg != null)
                        dErrorMsg(error);
                }
            }
            catch { }

        }




    }
}
