﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace Module_IDCard.HFR_G1_RS485.API.Connected
{
    public class ConnectedMethod
    {
        public delegateMessageReceived dMsgReceived;
        public delegateDisconnected dDisconnected;
        public bool LinkStatus;
        private Msg.RingBuffer ringBuffer;
        private ConnectedBase BaseConnect;
        private int timeOut;
        private string ReaderName;
        private Dictionary<string, ManualReset> dictionary;
        public byte Address { get; set; }
        private string key;
        public ConnectedMethod()
        {
            timeOut = 3000;
            dictionary = new Dictionary<string, ManualReset>();
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
                    dictionary = new Dictionary<string, ManualReset>();
                }
                string key = msgObject.ToKey();
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
                this.key = key;
                WaitHandle[] waitHandles = new WaitHandle[] { dictionary[key].ResetEvent };
                BaseConnect.SendMsg(msgObject);
                int num = WaitHandle.WaitAny(waitHandles, tiemOut, false);
                try
                {
                    if ((num == 0) && (dictionary[key].msgMethod != null))
                    {
                        msgObject.Child = dictionary[key].msgMethod;
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

        private void SortMessage(Msg.MessageObject_Child msgObject)
        {
            try
            {
                if (msgObject == null)
                    return;
                msgObject.Key = this.key ;
                if (dictionary.ContainsKey(msgObject.Key))
                {
                    dictionary[key].msgMethod = msgObject;
                    dictionary[key].ResetEvent.Set();
                }
            }
            catch { }
        }
    }
}
