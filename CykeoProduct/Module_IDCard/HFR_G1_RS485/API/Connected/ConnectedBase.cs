using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Collections;
using System.IO.Ports;
using System.Diagnostics;
namespace Module_IDCard.HFR_G1_RS485.API.Connected
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
                        if (receivedRingBuffer.DataCount <6)
                        {
                            Monitor.Wait(SyncObject);
                            continue;
                        }
                        if (receivedRingBuffer[0] != 170)
                        {
                            receivedRingBuffer.Clear(1);
                            continue;
                        }
                        int len = receivedRingBuffer[2]+5;
                        if (receivedRingBuffer.DataCount < len)
                        {
                            Monitor.Wait(SyncObject);
                            continue;
                        }
                        if (receivedRingBuffer[len - 1] != 187)
                        {
                            receivedRingBuffer.Clear(1);
                            continue;
                        }
                        receivedBytes = new byte[len];
                        receivedRingBuffer.ReadFromRingBuffer(receivedBytes, 0, len);
                        receivedRingBuffer.Clear(len);
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
