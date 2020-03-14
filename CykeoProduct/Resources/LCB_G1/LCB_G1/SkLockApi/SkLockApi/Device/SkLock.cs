using SkLockApi.Device.Enum;
using SkLockApi.Device.MyEvent;
using SkLockApi.Device.Protocol;
using SkLockApi.Device.Utils;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace SkLockApi.Device
{
    /// <summary>
    /// 控制板串口通讯类库
    /// </summary>
    public class SkLock
    {
        #region 私有变量
        //- 默认帧头，帧尾
        private readonly byte DEFAULT_HEAD = 0xAA;
        private readonly byte DEFAULT_END = 0xBB;
        //- 缓冲的最大值
        private const int MAX_BUFFER = 100;
        private byte eof;
        private string _error;
        private int ilen;
        private bool is_sync = true;    //切换同步，异步方式，默认是同步
        private Message msg;
        private object tag;
        private SerialPort serialPort = new SerialPort();
        #endregion

        #region 协议记录处理
        //记录未处理的接收数据，主要考虑接收数据分段
        byte[] m_btAryBuffer = new byte[4096];
        //记录未处理数据的有效长度
        int m_nLenth = 0;
        /// <summary>
        /// 数据帧协议记录处理
        /// </summary>
        /// <param name="btAryReceiveData"></param>
        private void RunReceiveDataCallBack(byte[] btAryReceiveData)
        {
            try
            {
                //需要处理的新长度
                int nCount = btAryReceiveData.Length;
                //保存未处理数据和新添加的未处理数据
                byte[] btAryBuffer = new byte[nCount + m_nLenth];
                //把未处理数据保存到btAryBuffer中，后面追加新添加的未处理数据
                Array.Copy(m_btAryBuffer, btAryBuffer, m_nLenth);
                Array.Copy(btAryReceiveData, 0, btAryBuffer, m_nLenth, btAryReceiveData.Length);

                //分析接收数据，以0xAA为起点，以协议中命令类型为终止点
                int nIndex = 0; //记录一条数据的终止点
                int nMarkIndex = 0; //当数据不存在AA时，nMarkIndex等于数据组最大索引，此时数据帧全部分隔处理结束
                for (int nLoop = 0; nLoop < btAryBuffer.Length; nLoop++)
                {
                    //判断待处理的数据是否大于需要判断的数据长度
                    if (btAryBuffer.Length > nLoop + 5)
                    {
                        if (btAryBuffer[nLoop] == 0xAA)
                        {
                            int nLen = DevConvert.ConvertInteger(new byte[]
                                { btAryBuffer[nLoop + 1], btAryBuffer[nLoop + 2] });
                            if (nLoop + 5 + nLen <= btAryBuffer.Length)
                            {
                                byte[] btAryAnaly = new byte[nLen + 5];
                                //从待处理的数据中切割出需要解析的完整数据帧
                                Array.Copy(btAryBuffer, nLoop, btAryAnaly, 0, nLen + 5);

                                //解析数据帧
                                ResolveProtocol(btAryAnaly);

                                nLoop += 1 + nLen;
                                nIndex = nLoop + 1;
                            }
                            else
                            {
                                nLoop += 1 + nLen;
                            }

                        }
                        else
                        {
                            nMarkIndex = nLoop;
                        }
                    }
                    if (nIndex < nMarkIndex)
                        nIndex = nMarkIndex + 1;

                    if (nIndex < btAryBuffer.Length)
                    {
                        m_nLenth = btAryBuffer.Length - nIndex;
                        Array.Clear(m_btAryBuffer, 0, 4096);
                        Array.Copy(btAryBuffer, nIndex, m_btAryBuffer, 0, btAryBuffer.Length - nIndex);
                    }
                    else
                    {
                        m_nLenth = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                if (OnDataErrorHandler != null)
                {
                    OnDataErrorHandler(tag, 0, ex.Message);
                }
            }
        }
        #endregion

        #region 属性
        /// <summary>
        /// 获取和设置同步，异步方式
        /// </summary>
        public bool IsSync
        {
            get { return is_sync; }
            set { is_sync = value; }
        }
        /// <summary>
        /// 获取或设置错误信息
        /// </summary>
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }
        /// <summary>
        /// 获取和设置串口号
        /// </summary>
        public string PortName
        {
            get { return serialPort.PortName; }
            set { serialPort.PortName = value; }
        }
        /// <summary>
        /// 获取和设置波特率
        /// </summary>
        public int BaudRate
        {
            get { return serialPort.BaudRate; }
            set { serialPort.BaudRate = value; }
        }
        /// <summary>
        /// 获取和设置数据位
        /// </summary>
        public int DataBits
        {
            get { return serialPort.DataBits; }
            set { serialPort.DataBits = value; }
        }
        /// <summary>
        /// 获取和设置校验位
        /// </summary>
        public Parity Parity
        {
            get { return serialPort.Parity; }
            set { serialPort.Parity = value; }
        }
        /// <summary>
        /// 获取和设置停止位
        /// </summary>
        public StopBits StopBits
        {
            get { return serialPort.StopBits; }
            set { serialPort.StopBits = value; }
        }
        /// <summary>
        /// 获取当前串口对象
        /// </summary>
        public SerialPort MySerial
        {
            get { return this.serialPort; }
        }
        /// <summary>
        /// 获取和设置指令结束符
        /// </summary>
        public byte EOF
        {
            get { return this.eof; }
            set { this.eof = value; }
        }
        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }
        #endregion

        #region 公共事件
        // - 通用事件
        /// <summary>
        /// 系统发送事件
        /// </summary>
        public event DataSendedHandler OnDataSendedHandler = null;
        /// <summary>
        /// 系统基础反馈事件（废弃）
        /// </summary>
        public event DataBaseReceivedHandler OnDataBaseReceivedHandler = null;
        /// <summary>
        /// 系统反馈事件（解析）
        /// </summary>
        public event DataReceivedHandler OnDataReceivedHandler = null;
        /// <summary>
        /// 系统错误事件
        /// </summary>
        public event DataErrorHandler OnDataErrorHandler = null;

        // - 读写器事件
        /// <summary>
        /// 获取设备反馈事件
        /// </summary>
        public event EquipmentFeedbackHandler OnEquipmentFeedbackHandler = null;
        #endregion

        #region 私有方法
        /// <summary>
        /// 设备信息反馈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DevSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (is_sync)
                return;
            try
            {
                int index = this.serialPort.BytesToRead;
                if (index > 0)
                {
                    byte[] buffer = new byte[index];
                    this.serialPort.Read(buffer, 0, buffer.Length);
                    if (OnDataBaseReceivedHandler != null)
                        OnDataBaseReceivedHandler(tag, buffer);
                    //Console.WriteLine(DevConvert.ToHexString2Format(buffer, ""));
                    RunReceiveDataCallBack(buffer);
                }
            }
            catch (Exception ex)
            {
                if (OnDataErrorHandler != null)
                    OnDataErrorHandler(this, -1, ex.Message);
            }
        }
        /// <summary>
        /// 设备错误状态反馈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DevSerial_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            string error = string.Empty;
            switch (e.EventType)
            {
                case SerialError.RXOver:
                    error = "发生输入缓冲区溢出。输入缓冲区空间不足，或在文件尾 (EOF) 字符之后接收到字符。";
                    break;

                case SerialError.Overrun:
                    error = "发生字符缓冲区溢出。下一个字符将丢失。";
                    break;

                case SerialError.RXParity:
                    error = "硬件检测到奇偶校验错误。";
                    break;

                case SerialError.Frame:
                    error = "硬件检测到一个组帧错误。";
                    break;

                case SerialError.TXFull:
                    error = "应用程序尝试传输一个字符，但是输出缓冲区已满。";
                    break;

                default:
                    error = "未知错误.";
                    break;
            }
            if (OnDataErrorHandler != null)
            {
                OnDataErrorHandler(this, -1, error);
            }
        }
        /// <summary>
        /// 写入数据到串口
        /// </summary>
        /// <param name="sendBytes"></param>
        private void WriteBytes(byte[] sendBytes)
        {
            int index = 0;
            if (OnDataSendedHandler != null)
                OnDataSendedHandler(tag, sendBytes);
            Monitor.Enter(serialPort);
            try
            {
                //必须清空缓存区
                serialPort.DtrEnable = true;
                serialPort.DiscardOutBuffer();
                serialPort.DiscardInBuffer();
                serialPort.Write(sendBytes, 0, sendBytes.Length);

                //while (serialPort.BytesToRead == 0)
                //{
                //    Thread.Sleep(1);
                //    index++;
                //    if (index >= 3000)
                //        break;
                //}
                //Thread.Sleep(100);
                //byte[] revData = new byte[serialPort.BytesToRead];
                //serialPort.Read(revData, 0, revData.Length);    
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Monitor.Exit(serialPort);
            }
        }
        private int Read(byte[] buffer, int offset, int count)
        {
            try
            {
                if (this.serialPort.IsOpen && (this.serialPort.BytesToRead > 0))
                {
                    return this.serialPort.Read(buffer, offset, count);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return 0;    
        }
        /// <summary>
        /// 读取数据反馈信息
        /// </summary>
        /// <returns></returns>
        private byte[] ReadBytes(int timeout)
        {
            try
            {
                //int index = 0;
                //while (serialPort.BytesToRead == 0)
                //{
                //    Thread.Sleep(1);
                //    index++;
                //    if (index > 1000)
                //        return null;
                //}
                //Thread.Sleep(timeout);
                //读取数据反馈信息
                //Thread.Sleep(100);
                byte[] buffer = new byte[5];
                int icount = this.serialPort.Read(buffer, 0, buffer.Length);
                if ((icount >= 5) && (buffer[0] == 0xAA))
                {
                    byte[] len = new byte[] { buffer[1], buffer[2] };
                    byte addr = buffer[3];
                    byte cmd = buffer[4];
                    int size = DevConvert.ConvertInteger(new byte[] { buffer[1], buffer[2] });
                    buffer = new byte[size];
                    int offset = this.Read(buffer, 0, buffer.Length);
                    if (offset < size)  //未读取完全
                    {
                        Thread.Sleep(20);
                        //继续读取完毕
                        offset += this.Read(buffer, offset, buffer.Length - offset);
                    }
                    //读取完毕
                    byte[] revbytes = new byte[size + 5];
                    revbytes[0] = 0xAA;
                    revbytes[1] = len[0];
                    revbytes[2] = len[1];
                    revbytes[3] = addr;
                    revbytes[4] = cmd;
                    for (int i = 0; i < size; i++)
                    {
                        revbytes[i + 5] = buffer[i];
                    }
                    if (OnDataReceivedHandler != null)
                        OnDataReceivedHandler(tag, revbytes);

                    //解析信息
                    return revbytes;
                }
            }
            catch (Exception ex)
            {
                if (OnDataErrorHandler != null)
                    OnDataErrorHandler(this, -1, ex.Message);
                return null;
            }
            return null;
        }
        /// <summary>
        /// 移除反馈线程
        /// </summary>
        /// <param name="removed">是否移除</param>
        private void RemoveReceived(bool removed)
        {
            is_sync = removed;
            if (removed)
            {
                this.serialPort.DataReceived -= new SerialDataReceivedEventHandler(this.DevSerial_DataReceived);
            }
            else
            {
                this.serialPort.DataReceived -= new SerialDataReceivedEventHandler(this.DevSerial_DataReceived);
                this.serialPort.DataReceived += new SerialDataReceivedEventHandler(this.DevSerial_DataReceived);
            }
        }
        /// <summary>
        /// 串口数据接收函数
        /// </summary>
        /// <param name="revs"></param>
        private void RevFromDevice(ref byte[] revs)
        {
            this.serialPort.ReadTimeout = 500;
            int rcvDataLength = 0;
            byte[] rcvData = new byte[1024];
            try
            {
                int icount = serialPort.BytesToRead;
                if (icount > 0)
                {
                    rcvDataLength = this.serialPort.Read(rcvData, 0, rcvData.Length);
                    revs = new byte[rcvDataLength];
                    for (int i = 0; i < rcvDataLength; i++)
                    {
                        revs[i] = rcvData[i];
                    }
                }
                else
                {
                    revs = null;
                }
            }
            catch (Exception)
            {
                revs = null;
            }
        }
        /// <summary>
        /// 发送同步数据
        /// </summary>
        /// <param name="msg">需要发送的数据</param>
        /// <param name="timeout">超时时间</param>
        private void SendSynMsg(Message msg, int timeout)
        {
            this.msg = msg;
            //发送同步操作函数
            byte[] sendBytes = msg.ToByte();
            WriteBytes(sendBytes);
            Thread.Sleep(timeout);
            //读取串口缓存区数据
            byte[] outBytes = ReadBytes(timeout);
            if (outBytes == null)
            {
                msg.ReaultOk = false;
                msg.ResultMsg = "没有获取串口缓存区数据";
            }
            else
            {
                //接收数据解析
                MsgType msgType = msg.MyMsgType.ToConvert(outBytes);
                msg.MyMsgType = msgType;
                byte[] data = msgType.Data;
                msg.ReaultOk = true;
                msg.ResultMsg = "成功读取";
            }
        }
        /// <summary>
        /// 发送同步数据，默认超时时间100
        /// </summary>
        /// <param name="msg">需要发送的数据</param>
        private void SendSynMsg(Message msg)
        {
            this.SendSynMsg(msg, 100);
        }
        /// <summary>
        /// 发送retry次同步数据
        /// </summary>
        /// <param name="msg">需要发送的数据</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="retry">发送多少次</param>
        private void SendSynMsg(Message msg, int timeout, int retry)
        {
            for (int i = 0; i < retry; i++)
            {
                this.SendSynMsg(msg, timeout);
            }
        }
        /// <summary>
        /// 发送异步Message类型数据
        /// </summary>
        /// <param name="msg">需要发送的Message类型数据</param>
        private void SendUnsynMsg(Message msg)
        {
            this.msg = msg;
            byte[] sendbytes = msg.ToByte();
            WriteBytes(sendbytes);
        }
        /// <summary>
        /// 发送异步bytes类型数据
        /// </summary>
        /// <param name="msg">需要发送的bytes类型数据</param>
        private void SendUnsynMsg(byte[] msg)
        {
            WriteBytes(msg);
        }
        /// <summary>
        /// n次发送Message类型数据
        /// </summary>
        /// <param name="msg">需要发送的Message类型数据</param>
        /// <param name="retry">需要发送多少次</param>
        private void SendUnsynMsgRetry(Message msg, int retry)
        {
            for (int i = 0; i < retry; i++)
            {
                this.SendUnsynMsg(msg);
            }
        }
        /// <summary>
        /// 解析数据帧协议
        /// </summary>
        /// <param name="buffer">需要解析的数据帧</param>
        private void ResolveProtocol(byte[] buffer)
        {
            if (OnDataReceivedHandler != null)
                OnDataReceivedHandler(tag, buffer);
            //Console.WriteLine(DevConvert.ToHexString2Format(buffer, ""));
            //检验数据合法性
            byte[] my_bytes = DevConvert.ReadBytes(buffer, 1, buffer.Length - 3);
            byte _bcc = BccParityUtil.BccCheckUtil(buffer);
            byte[] data_bytes = DevConvert.ReadBytes(buffer, 5, buffer.Length - 7);
            byte imsg_type = buffer[4];
            switch (imsg_type)
            {
                case (byte)EnumFeedbackMid.SetControlAddr:
                    //设置控制板地址
                    Console.WriteLine("设置控制板地址");
                    if (OnEquipmentFeedbackHandler != null)
                        OnEquipmentFeedbackHandler(imsg_type, data_bytes);
                    break;
                case (byte)EnumFeedbackMid.SetLockStatus:
                    //设置电磁锁状态
                    Console.WriteLine("设置电磁锁状态");
                    if (OnEquipmentFeedbackHandler != null)
                        OnEquipmentFeedbackHandler(imsg_type, data_bytes);
                    break;                
                case (byte)EnumFeedbackMid.GetLockStatus:
                    //获取电磁锁状态
                    Console.WriteLine("获取电磁锁状态");
                    if (OnEquipmentFeedbackHandler != null)
                        OnEquipmentFeedbackHandler(imsg_type, data_bytes);
                    break;
                case (byte)EnumFeedbackMid.SetLedStatus:
                    //设置LED灯状态
                    Console.WriteLine("设置LED灯状态");
                    if (OnEquipmentFeedbackHandler != null)
                        OnEquipmentFeedbackHandler(imsg_type, data_bytes);
                    break;                
                case (byte)EnumFeedbackMid.GetControlEdition:
                    //获取控制板设备版本
                    Console.WriteLine("获取控制板设备版本");
                    if (OnEquipmentFeedbackHandler != null)
                        OnEquipmentFeedbackHandler(imsg_type, data_bytes);
                    break;
                case (byte)EnumFeedbackMid.AddrError:
                    //地址错误匹配反馈
                    Console.WriteLine("设备地址错误匹配反馈");
                    if (OnEquipmentFeedbackHandler != null)
                        OnEquipmentFeedbackHandler(imsg_type, data_bytes);
                    break;                
                case (byte)EnumFeedbackMid.FrameCheckError:
                    //数据帧校验匹配错误反馈
                    Console.WriteLine("数据帧校验匹配错误反馈");
                    if (OnEquipmentFeedbackHandler != null)
                        OnEquipmentFeedbackHandler(imsg_type, data_bytes);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 公有方法
        /// <summary>
        /// 构造函数，默认115200,8,1，none
        /// </summary>
        public SkLock()
        {
            serialPort.BaudRate = 115200;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Parity = Parity.None;
            is_sync = true;
            eof = 0xEF;
            msg = new Message();
        }
        /// <summary>
        /// 获取串口资源
        /// </summary>
        /// <returns></returns>
        public string[] GetPortName()
        {
            return SerialPort.GetPortNames();
        }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="portName">串口号</param>
        /// <returns></returns>
        public bool Open(string portName)
        {
            try
            {
                if (!this.serialPort.IsOpen)
                {
                    this.serialPort.PortName = portName;
                    //this.serialPort.DataReceived += new SerialDataReceivedEventHandler(this.DevSerial_DataReceived);
                    this.serialPort.ErrorReceived += new SerialErrorReceivedEventHandler(this.DevSerial_ErrorReceived);
                    this.serialPort.Open();
                    RemoveReceived(is_sync);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 自动匹配打开串口
        /// </summary>
        /// <param name="portName">串口号</param>
        /// <returns></returns>
        public bool AutoOpen(string portName)
        {
            List<int> baudRateList = new List<int> { 9600, 19200, 38400, 57600, 115200 };
            is_sync = true;//同步设置
            bool flag = false;
            foreach (var baudRate in baudRateList)
            {
                this.serialPort.Close();
                this.serialPort.BaudRate = baudRate;
                this.serialPort.PortName = portName;
                this.serialPort.Open();
                flag = true;
                break;
            }
            return flag;
        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            try
            {
                if (this.serialPort.IsOpen)
                {
                    this.serialPort.DataReceived -= new SerialDataReceivedEventHandler(this.DevSerial_DataReceived);
                    this.serialPort.ErrorReceived -= new SerialErrorReceivedEventHandler(this.DevSerial_ErrorReceived);
                    this.serialPort.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 设置控制板地址（异步模式）
        /// </summary>
        /// <param name="sourceAddr">源地址</param>
        /// <param name="destinationData">更变后目标地址</param>
        public void SetControlAddr(byte sourceAddr, byte[] destinationAddr)
        {
            byte[] bytes = new byte[5];
            bytes[0] = 0x00;
            bytes[1] = 0x03;
            bytes[2] = sourceAddr;
            bytes[3] = (byte)EnumControlMid.SetControlAddr;
            Array.Copy(destinationAddr, 0, bytes, 4, 1);
            Message message = new Message(EnumControlMid.SetControlAddr, bytes);
            SendUnsynMsg(message);
        }
        /// <summary>
        /// 设置控制板的电磁锁状态（异步模式）
        /// </summary>
        /// <param name="Addr">控制板地址</param>
        /// <param name="sequence">设备序列号枚举</param>
        public void SetLockStatus(byte Addr, EnumDeviceSequence sequence)
        {
            byte[] bytes = new byte[5];
            bytes[0] = 0x00;
            bytes[1] = 0x03;
            bytes[2] = Addr;
            bytes[3] = (byte)EnumControlMid.SetLockStatus;
            bytes[4] = (byte)sequence;
            Message message = new Message(EnumControlMid.SetLockStatus, bytes);
            SendUnsynMsg(message);
        }
        /// <summary>
        /// 获取控制板的电磁锁状态（异步模式）
        /// </summary>
        /// <param name="Addr">控制板地址</param>
        /// <param name="sequence">设备序列号枚举</param>
        public void GetLockStatus(byte Addr, EnumDeviceSequence sequence)
        {
            byte[] bytes = new byte[5];
            bytes[0] = 0x00;
            bytes[1] = 0x03;
            bytes[2] = Addr;
            bytes[3] = (byte)EnumControlMid.GetLockStatus;
            bytes[4] = (byte)sequence;
            Message message = new Message(EnumControlMid.GetLockStatus, bytes);
            SendUnsynMsg(message);
        }
        /// <summary>
        /// 设置控制板的 LED 灯状态（异步模式）
        /// </summary>
        /// <param name="Addr">控制板地址</param>
        /// <param name="sequence">设备序列号枚举</param>
        /// <param name="status">开关灯状态:01开灯;02关灯;</param>
        public void SetLedStatus(byte Addr, EnumDeviceSequence sequence, byte status)
        {
            byte[] bytes = new byte[6];
            bytes[0] = 0x00;
            bytes[1] = 0x04;
            bytes[2] = Addr;
            bytes[3] = (byte)EnumControlMid.SetLedStatus;
            bytes[4] = (byte)sequence;
            bytes[5] = status;
            Message message = new Message(EnumControlMid.SetLedStatus, bytes);
            SendUnsynMsg(message);
        }
        /// <summary>
        /// 获取设备版本号（同步模式）
        /// </summary>
        /// <param name="Addr">控制板地址</param>
        /// <param name="ver">回调的字符串数据</param>
        /// <returns></returns>
        public bool GetControlEdition(byte Addr,ref string ver)
        {
            byte[] bytes = new byte[5];
            bytes[0] = 0x00;
            bytes[1] = 0x03;
            bytes[2] = Addr;
            bytes[3] = (byte)EnumControlMid.GetControlEdition;
            bytes[4] = 0x00;
            Message message = new Message(EnumControlMid.GetControlEdition, bytes);
            SendSynMsg(message,300);
            if (msg.ReaultOk)
            {
                byte[] data = msg.MyMsgType.Data;
                ver = "V" + DevConvert.ConvertInteger(new byte[] { data[0], data[1] });
            }
            return msg.ReaultOk;
        }
        /// <summary>
        /// 获取设备版本号（异步模式）
        /// </summary>
        /// <param name="Addr">控制板地址</param>
        public void GetControlEdition(byte Addr)
        {
            byte[] bytes = new byte[5];
            bytes[0] = 0x00;
            bytes[1] = 0x03;
            bytes[2] = Addr;
            bytes[3] = (byte)EnumControlMid.GetControlEdition;
            bytes[4] = 0x00;
            Message message = new Message(EnumControlMid.GetControlEdition, bytes);
            SendUnsynMsg(message);
        }
        /// <summary>
        /// 获取最后一次的Msg数据
        /// </summary>
        /// <returns></returns>
        public Message GetLastMsg()
        {
            return msg;
        }
        #endregion
    }
}
