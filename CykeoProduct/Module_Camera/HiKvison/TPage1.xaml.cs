using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace Module_Camera.HiKvison
{
    /// <summary>
    /// TPage1.xaml 的交互逻辑
    /// </summary>
    public partial class TPage1 : Window
    {
        private uint iLastErr = 0;
        private Int32 m_lUserID = -1;
        private bool m_bInitSDK = false;
        private bool m_bRecord = false;
        private Int32 m_lRealHandle = -1;
        private int lVoiceComHandle = -1;
        private string str;
        CHCNetSDK.REALDATACALLBACK RealData = null;
        public CHCNetSDK.NET_DVR_PTZPOS m_struPtzCfg;
        public TPage1()
        {
            InitializeComponent();
            this.login.Click += Button_Click;
            this.photo.MouseLeftButtonDown += Button_Click_1;
            this.video.MouseLeftButtonDown += btn_Exit_Click;
            m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                MessageBox.Show("NET_DVR_Init error!");
                return;
            }
            else
            {
                //保存SDK日志 To save the SDK log
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
            }
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            #region
            if (m_lUserID < 0)
            {
                string DVRIPAddress = "192.168.1.64"; //设备IP地址或者域名
                Int16 DVRPortNumber = Int16.Parse("8000");//设备服务端口号
                string DVRUserName = "admin";//设备登录用户名
                string DVRPassword = "sk123456";//设备登录密码
                CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
                //登录设备 Login the device
                m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                if (m_lUserID < 0)
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_Login_V30 failed, error code= " + iLastErr; //登录失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    //登录成功
                    MessageBox.Show("Login Success!");
                }
            }
            else
            {
                //注销登录 Logout the device
                if (m_lRealHandle >= 0)
                {
                    MessageBox.Show("Please stop live view firstly");
                    return;
                }
                if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_Logout failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
                m_lUserID = -1;
            }
            return;
            #endregion
        }
        public void Button_Click_1(object sender, RoutedEventArgs e)
        {

            #region
            if (m_lUserID < 0)
            {
                MessageBox.Show("Please login the device firstly");
                return;
            }
            if (m_lRealHandle < 0)
            {
                CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                lpPreviewInfo.hPlayWnd = image.Handle;//预览窗口
                //lpPreviewInfo.hPlayWnd = ((HwndSource)PresentationSource.FromVisual(this)).Handle;//预览窗口
                //lpPreviewInfo.hPlayWnd = new WindowInteropHelper(display).Handle;//预览窗口
                lpPreviewInfo.lChannel = Int16.Parse("1");//预te览的设备通道
                lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
                lpPreviewInfo.dwDisplayBufNum = 1; //播放库播放缓冲区最大缓冲帧数
                lpPreviewInfo.byProtoType = 0;
                lpPreviewInfo.byPreviewMode = 0;
                if (RealData == null)
                {
                    RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
                }

                IntPtr pUser = new IntPtr();//用户数据
                //打开预览 Start live view 
                m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                if (m_lRealHandle < 0)
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_RealPlay_V40 failed, error code= " + iLastErr; //预览失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
                else
                {

                }
                //SetParent(lpPreviewInfo.hPlayWnd, RealPlayWnd.Handle);
                //ShowWindowAsync(lpPreviewInfo.hPlayWnd, 3);
            }
            else
            {
                //停止预览 Stop live view 
                if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_StopRealPlay failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
                m_lRealHandle = -1;
            }

            return;
            #endregion
        }
        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            if (dwBufSize > 0)
            {
                byte[] sData = new byte[dwBufSize];
                Marshal.Copy(pBuffer, sData, 0, (Int32)dwBufSize);

                string str = "实时流数据.ps";
                FileStream fs = new FileStream(str, FileMode.Create);
                int iLen = (int)dwBufSize;
                fs.Write(sData, 0, iLen);
                fs.Close();
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            //停止预览 Stop live view 
            if (m_lRealHandle >= 0)
            {
                CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle);
                m_lRealHandle = -1;
            }

            //注销登录 Logout the device
            if (m_lUserID >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(m_lUserID);
                m_lUserID = -1;
            }

            CHCNetSDK.NET_DVR_Cleanup();
            this.Close();
        }
        //private void btnBMP_Click(object sender, EventArgs e)
        //{
        //    string sBmpPicFileName;
        //    //图片保存路径和文件名 the path and file name to save
        //    sBmpPicFileName = "BMP_test.bmp";

        //    //BMP抓图 Capture a BMP picture
        //    if (!CHCNetSDK.NET_DVR_CapturePicture(m_lRealHandle, sBmpPicFileName))
        //    {
        //        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
        //        str = "NET_DVR_CapturePicture failed, error code= " + iLastErr;
        //        MessageBox.Show(str);
        //        return;
        //    }
        //    else
        //    {
        //        str = "Successful to capture the BMP file and the saved file is " + sBmpPicFileName;
        //        MessageBox.Show(str);
        //    }
        //    return;
        //}
        //private void btnJPEG_Click(object sender, EventArgs e)
        //{
        //    string sJpegPicFileName;
        //    //图片保存路径和文件名 the path and file name to save
        //    sJpegPicFileName = "JPEG_test.jpg";

        //    int lChannel = Int16.Parse("1"); //通道号 Channel number

        //    CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara = new CHCNetSDK.NET_DVR_JPEGPARA();
        //    lpJpegPara.wPicQuality = 0; //图像质量 Image quality
        //    lpJpegPara.wPicSize = 0xff; //抓图分辨率 Picture size: 2- 4CIF，0xff- Auto(使用当前码流分辨率)，抓图分辨率需要设备支持，更多取值请参考SDK文档

        //    //JPEG抓图 Capture a JPEG picture
        //    if (!CHCNetSDK.NET_DVR_CaptureJPEGPicture(m_lUserID, lChannel, ref lpJpegPara, sJpegPicFileName))
        //    {
        //        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
        //        str = "NET_DVR_CaptureJPEGPicture failed, error code= " + iLastErr;
        //        MessageBox.Show(str);
        //        return;
        //    }
        //    else
        //    {
        //        str = "Successful to capture the JPEG file and the saved file is " + sJpegPicFileName;
        //        MessageBox.Show(str);
        //    }
        //    return;
        //}








        //#region

        ///// <summary>
        ///// Gets/Sets 回显Image控件依赖的图像属性
        ///// </summary>
        //public ImageSource ShowBackground
        //{
        //    get { return (ImageSource)GetValue(ShowBackgroundProperty); }
        //    set
        //    {
        //        SetValue(ShowBackgroundProperty, value);
        //    }
        //}
        //public static DependencyProperty ShowBackgroundProperty =
        //    DependencyProperty.Register("ShowBackground", typeof(ImageSource), typeof(MainWindow),
        //    new UIPropertyMetadata(new BitmapImage(new Uri("F:\\OpenAll.png", UriKind.Relative)))//给个默认图片
        //    );
        //public Socket _WinSkt = null;
        //private BitmapImage _memBmp = new BitmapImage();
        //public Thread _RdThread;
        //byte[] _header = new byte[54];//保存bitmap图片的头信息
        //private delegate void ShowPicHandler(MemoryStream imgstream);
        //private ShowPicHandler _dShowpic;//显示图片委托
        //public int _PortNum;
        //private int _lenstart;//记录包是位图中的哪一行
        //public int _width;//图片宽度
        //public int _height;//图片高度
        //private IPAddress _ipa;
        ////此方法是启动方法，启动时将IP和端口数据传给服务端在另外一个类里做的，这里只管接收
        //public void InitPreview()
        //{
        //    _WinSkt = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
        //    while (true)
        //    {
        //        _PortNum = new Random().Next(1, 65534);
        //        try
        //        {
        //            IPEndPoint myIP = new IPEndPoint(_ipa, _PortNum);
        //            _WinSkt.Bind(myIP);
        //            _WinSkt.ReceiveBufferSize = 1024 * 768 * 3;
        //        }
        //        catch
        //        {
        //            continue;
        //        }
        //        break;
        //    }
        //    //实例化显示图片委托
        //    _dShowpic = new ShowPicHandler(ShowImage);
        //    //开启线程接收数据
        //    _RdThread = new Thread(new ThreadStart(RdRcvThread));
        //    _RdThread.Start();
        //}
        //int _length;
        //private void RdRcvThread()
        //{
        //    byte[] nMsgLenBuf = new byte[65535];
        //    byte[] RgbBuf = new byte[6000];         //两行数据，最大像素点1000 * 3 * 2
        //    int nRev = 0;
        //    //用来依次写入图片包数据
        //    MemoryStream buffstream = new MemoryStream();
        //    //存储一张完成的图片并绘到image
        //    MemoryStream imgstream = new MemoryStream();

        //    #region VIDEO信号
        //    int tmpInt = Convert.ToInt32(_width * 3);//传过去的参数要是4的倍数,这是适应位图数据的一些逻辑,可以不用细究
        //    int i = tmpInt / 4;
        //    int j = 0;
        //    if (tmpInt % 4 != 0) j = (i + 1) * 4;
        //    else j = tmpInt;
        //    int row = 0;
        //    _length = j * _height;//计算一张图片大小
        //    CreateHeader();//创建文件头
        //    buffstream.Write(_header, 0, 54);//将文件头写入内存
        //    while (true)
        //    {
        //        try
        //        {
        //            nRev = _WinSkt.Receive(nMsgLenBuf);
        //        }
        //        catch { return; }

        //        try
        //        {
        //            _lenstart = nMsgLenBuf[0] * 256 + nMsgLenBuf[1];//包的头两个byte是此包所在的图片位置
        //                                                            //丢包的图片数据内存区域没有处理
        //                                                            //丢失的数据包直接不管,找到当前包其所在的位置并写入
        //            buffstream.Position = j * _lenstart + 54;
        //            buffstream.Write(nMsgLenBuf, 0, j);

        //            if (_lenstart >= _height - 1)//一张图片传结束了
        //            {
        //                //解决buff被接收线程修改的问题,将buff中的数据复制到图片内存区
        //                imgstream.Position = 0;
        //                imgstream.Write(buffstream.GetBuffer(), 0, _length + 54);
        //                //显示图片
        //                Application.Current.Dispatcher.BeginInvoke(_dShowpic, imgstream);
        //            }
        //        }
        //        catch
        //        {
        //            buffstream.Dispose();
        //            buffstream = new MemoryStream();
        //            buffstream.Write(_header, 0, 54);
        //        }
        //    }
        //    #endregion
        //}
        //private void CreateHeader()
        //{
        //    MemoryStream stream = new MemoryStream(14 + 40);   //为头腾出54个长度的空间
        //    byte[] buffer = new byte[13];
        //    buffer[0] = 0x42;               //Bitmap固定常数
        //    buffer[1] = 0x4d;               //Bitmap固定常数
        //    stream.Write(buffer, 0, 2);     //先写入头的前两个字节
        //    //把我们之前获得的数据流的长度转换成字节,
        //    //这个是用来告诉“头”我们的实际图像数据有多大
        //    byte[] bytes = BitConverter.GetBytes(_length + 54);
        //    stream.Write(bytes, 0, 4);      //把这个长度写入头中去
        //    buffer[0] = 0; buffer[1] = 0;
        //    buffer[2] = 0; buffer[3] = 0;
        //    stream.Write(buffer, 0, 4);     //在写入4个字节长度的数据到头中去
        //    int num2 = 0x36;                //Bitmap固定常数
        //    bytes = BitConverter.GetBytes(num2);
        //    stream.Write(bytes, 0, 4);      //在写入最后4个字节的长度

        //    tagBITMAPINFOHEADER sInfoHead = new tagBITMAPINFOHEADER();
        //    sInfoHead.biSize = 40;          //本结构所占字节数，实际上该结构占用40个字节，但Windows每次还是需要您亲自添上
        //    sInfoHead.biWidth = _width;     //Convert.ToInt32(GqyFactVWWidth+1);
        //    sInfoHead.biHeight = -_height;   //Convert.ToInt32(GqyFactVWHight);
        //    sInfoHead.biPlanes = 1;         //目标设备的平面数，约定必须为1
        //    sInfoHead.biSizeImage = 0;
        //    sInfoHead.biBitCount = 24;      //每个像素所需的位数，必须是1（双色）、 4（16色）、8（256色）、24（真彩色）或32（32位真彩）之一
        //    sInfoHead.biCompression = 0;    //位图压缩类型，必须是0（不压缩）、1（BI_RLE8压缩类型）或2（BI_RLE4压缩类型）之一
        //    sInfoHead.biXPelsPerMeter = 0;  //水平分辨率，每米像素数，一般不用关心，设为0
        //    sInfoHead.biYPelsPerMeter = 0;  //垂直分辨率，每米像素数，一般不用关心，设为0
        //    sInfoHead.biClrUsed = 0;        //位图实际使用的颜色表中的颜色数，一般不用关心，设为0
        //    sInfoHead.biClrImportant = 0;
        //    byte[] bufffffff = new byte[40];
        //    bufffffff = StructToBytes(sInfoHead);
        //    stream.Write(bufffffff, 0, 40);

        //    _header = stream.GetBuffer();   //将bmp文件头保存为全局变量 
        //}
        //private void ShowImage(MemoryStream imgstream)
        //{
        //    try
        //    {
        //        _memBmp = new BitmapImage();
        //        _memBmp.BeginInit();
        //        _memBmp.StreamSource = imgstream;
        //        _memBmp.EndInit();
        //        ShowBackground = _memBmp;//将最终的图片给image控件的资源依赖项属性
        //    }
        //    catch { }
        //}
        //private byte[] StructToBytes(object structObj)
        //{
        //    int size = Marshal.SizeOf(structObj);//得到结构体的大小
        //    byte[] bytes = new byte[size];//创建byte数组
        //    IntPtr structPtr = Marshal.AllocHGlobal(size);//分配结构体大小的内存空间
        //    Marshal.StructureToPtr(structObj, structPtr, false);//将结构体拷到分配好的内存空间
        //    Marshal.Copy(structPtr, bytes, 0, size); //从内存空间拷到byte数组
        //    Marshal.FreeHGlobal(structPtr); //释放内存空间
        //    return bytes;//返回byte数组
        //}
        //#endregion

    }
}
