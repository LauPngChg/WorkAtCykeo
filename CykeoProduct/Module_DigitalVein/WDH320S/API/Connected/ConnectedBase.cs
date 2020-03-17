using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace Module_DigitalVein.WDH320S.API.Connected
{
    internal class ConnectedBase:IDisposable
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
            receivedRingBuffer = new Msg.RingBuffer(1024 * 1024);
            SyncObject = new object();
            readTempBuffer = new byte[1024];
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
                        if (receivedRingBuffer.DataCount < 8)
                        {
                            Monitor.Wait(SyncObject);
                            continue;
                        }
                        if (receivedRingBuffer[0] != 64)
                        {
                            receivedRingBuffer.Clear(1);
                            continue;
                        }
                        if (receivedRingBuffer[7] != 13)
                        {
                            receivedRingBuffer.Clear(1);
                            continue;
                        }
                        int len = 0;
                        switch (receivedRingBuffer[1])
                        {
                            case 4: case 7: case 8: case 9: 
                            case 10: case 11: case 13: case 16:
                                len = (ushort)(((0xff & receivedRingBuffer[4]) << 8) + (0xff & receivedRingBuffer[3]));
                                break;
                        }
                        if (len != 0)
                        {
                            if (receivedRingBuffer.DataCount < len + 13)
                            {
                                Monitor.Wait(SyncObject);
                                continue;
                            }
                            if (receivedRingBuffer[8] != 62)
                            {
                                receivedRingBuffer.Clear(1);
                                continue;
                            }
                            if (receivedRingBuffer[len + 12] != 13)
                            {
                                receivedRingBuffer.Clear(1);
                                continue;
                            }
                        } 
                        receivedBytes = new byte[len==0?8:(len+13)];
                        receivedRingBuffer.ReadFromRingBuffer(receivedBytes, 0, receivedBytes.Length);
                        receivedRingBuffer.Clear(receivedBytes.Length);
                        Monitor.Pulse(SyncObject);
                    }
                    catch { }
                }
                if (receivedBytes != null)
                {
                    Msg.MessageObject msg = new Msg.MessageObject(receivedBytes);
                    if (msg.CheckData())
                    {
                        CallDelegateReceived(msg);
                    }
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
            this.SendMsg(message.CmdToBytes());
        }
        public virtual void Closed()
        { }
        public virtual void Dispose()
        { }
    }
}
