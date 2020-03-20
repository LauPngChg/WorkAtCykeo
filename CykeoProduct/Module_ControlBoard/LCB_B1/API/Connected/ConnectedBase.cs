using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace Module_ControlBoard.LCB_B1.API.Connected
{
    internal class ConnectedBase : IDisposable
    {
        private delegateMessageReceived dMsgReceived;
        private delegateDisconnected dDisconnected;

        protected Msg.RingBuffer receivedRingBuffer;
        protected object SyncObject;
        public bool isConnected = false;
        protected byte[] readTempBuffer;
        public Stopwatch stopwatch;
        public Dictionary<byte, ManualReset> dictionary;

        protected ConnectedBase()
        {
            stopwatch = new Stopwatch();
            receivedRingBuffer = new Msg.RingBuffer(1024 );
            SyncObject = new object();
            readTempBuffer = new byte[512];
        }
        public void ReceivedCombineMethod(delegateMessageReceived msgReceived) { dMsgReceived += msgReceived; }
        public void RececivedRemoveMethod(delegateMessageReceived msgReceived) { dMsgReceived -= msgReceived; }
        public void DisconnectedCombineMethod(delegateDisconnected disconnected) { dDisconnected += disconnected; }
        public void DisconnectedRemoveMethod(delegateDisconnected disconnected) { dDisconnected -= disconnected; }
        protected void CallDelegateDisconnected()
        {
            try
            {
                if (this.dDisconnected != null)
                {
                    this.dDisconnected();
                }
            }
            catch { }
        }
        protected void CallDelegateReceived(Msg.MessageObject messageObject)
        {
            try
            {
                if (this.dMsgReceived != null)
                {
                    this.dMsgReceived(messageObject);
                }
            }
            catch { }
        }
        protected void ReceivedDataSplit_AddToThreadPool()
        {
            try
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ReceivedDataSplit));
            }
            catch { }
        }
        [CompilerGenerated]
        protected void ReceivedDataSplit(object state)
        {
            while (this.isConnected)
            {
                byte[] receivedBytes = null;
                lock (SyncObject)
                {
                    try
                    {
                        if (receivedRingBuffer.DataCount < 4)
                        {
                            Monitor.Wait(SyncObject);
                            continue;
                        }
                        if (receivedRingBuffer[0] !=8)
                        {
                            receivedRingBuffer.Clear(1);
                            continue;
                        }
                        if (receivedRingBuffer[1] != 129)
                        {
                            receivedRingBuffer.Clear(1);
                            continue;
                        }
                        receivedBytes = new byte[4];
                        receivedRingBuffer.ReadFromRingBuffer(receivedBytes, 0, 4);
                        receivedRingBuffer.Clear(4);
                        Monitor.Pulse(SyncObject);
                    }
                    catch { }
                }
                if (receivedBytes != null)
                {
                    Msg.MessageObject msg = new Msg.MessageObject(receivedBytes);
                    CallDelegateReceived(msg);
                }
            }
        }
        public virtual bool Connected(string readerName)
        {
            return false;
        }
        public virtual void ReceivedMsg()
        { }
        public virtual void SendMsg(byte[] sendBytes)
        {
        }
        public virtual void SendMsg(Msg.MessageObject message)
        {
            if (message == null)
                return;
            message.CmdPacked();
            for(int i =0;i<message.Data.Count;i++)
                this.SendMsg(message.Data[i]);
        }
        public virtual void Closed()
        { }
        public virtual void Dispose()
        { }
    }
}
