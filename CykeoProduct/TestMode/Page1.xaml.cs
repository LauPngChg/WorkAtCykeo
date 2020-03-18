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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestMode
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        public Module_ControlBoard.LCB_G1.TPage1 Test_LockControlBoard_G1_Page1;
        public Module_ControlBoard.LCB_B1.TPage1 Test_LockControlBoard_B1_Page1;
        public Module_IDCard.HFR_G1_RS485.TPage1 Test_IDCard_G1_RS485;
        public Module_IDCard.HFR_G2_USB.TPage1 Test_IDCard_G2_USB;
        public Module_DigitalVein.WDH320S.TPage1 Test_DigitalVein_WDH320S;
        public Module_QRCode.FreeDevelopement.TPage1 Test_QRCode_FreeDevelopment;
        public Module_Camera.LongSe.TPage1 Test_Camera_LongSe;
        public Module_Camera.HiKvison.TPage1 Test_Camera_HiKvison;
        public Module_UHF_RFID.SK_Series.TPage1 Test_UHF_RFID_SK_Series;
        public Module_UHF_RFID.RD_Series.TPage1 Test_UHF_RFID_RD_Series;
        public PublicResources.eModule TestModule;
        public Page1()
        {
            InitializeComponent();
            TestModule = PublicResources.eModule.ControlBoard_LCB_B1;
        }


        private bool __isLeftHide = false;
        private void spliter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            __isLeftHide = !__isLeftHide;
            if (__isLeftHide)
            {
                grid.ColumnDefinitions[0].Width = new GridLength(1d);
            }
            else
            {
                grid.ColumnDefinitions[0].Width = new GridLength(200d);
            }
        }
        #region 锁控板
        private void Label_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            //this.pageContainer.Source = new Uri("/Module_ControlBoard/LCB_B1/TPage1.xaml", UriKind.RelativeOrAbsolute);
        }
        private void Label_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            this.pageContainer.Content = new Module_ControlBoard.LCB_G1.TPage1();
        }
        #endregion

        #region 高频卡
        private void Label_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            this.pageContainer.Source = new Uri("/Module_IDcard;component/HFR_G1_RS485/TPage1.xaml", UriKind.RelativeOrAbsolute);
        }
        private void Label_MouseLeftButtonDown_4(object sender, MouseButtonEventArgs e)
        {
            //this.pageContainer.Source = new Uri("/Module_IDcard/USB/Page1.xaml", UriKind.RelativeOrAbsolute);
        }
        #endregion

        #region 指静脉
        private void Label_MouseLeftButtonDown_5(object sender, MouseButtonEventArgs e)
        {
            this.pageContainer.Source = new Uri("/Module_DigitalVein;component/WDH320S/TPage1.xaml", UriKind.RelativeOrAbsolute);
        }
        #endregion
        #region 摄像头
        private void Label_MouseLeftButtonDown_7(object sender, MouseButtonEventArgs e)
        {
            //this.pageContainer.Source = new Uri("/Module_Camera/LongSe/Page1.xaml", UriKind.RelativeOrAbsolute);
        }
        private void Label_MouseLeftButtonDown_8(object sender, MouseButtonEventArgs e)
        {
            //this.pageContainer.Source = new Uri("/Module_Camera/HiKvison/Page1.xaml", UriKind.RelativeOrAbsolute);
        }
        #endregion
        #region 二维码
        private void Label_MouseLeftButtonDown_6(object sender, MouseButtonEventArgs e)
        {
            //this.pageContainer.Source = new Uri("/Module_QRcode/Free/Page1.xaml", UriKind.RelativeOrAbsolute);
        }
        #endregion
        #region 读写器
        private void Label_MouseLeftButtonDown_9(object sender, MouseButtonEventArgs e)
        {
            //this.pageContainer.Source = new Uri("/Module_UHF_RFID/SK_Series/Page1.xaml", UriKind.RelativeOrAbsolute);
        }
        private void Label_MouseLeftButtonDown_10(object sender, MouseButtonEventArgs e)
        {
            //this.pageContainer.Source = new Uri("/Module_UHF_RFID/RD_Series/Page1.xaml", UriKind.RelativeOrAbsolute);
        }
        #endregion


    }
}
