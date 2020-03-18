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

namespace Module_IDCard.HFR_G1_RS485
{
    /// <summary>
    /// TPage1.xaml 的交互逻辑
    /// </summary>
    public partial class TPage1 : Page
    {
        API.Connected.ConnectedMethod connected;
        public TPage1()
        {
            InitializeComponent();
            connected = new API.Connected.ConnectedMethod();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (connected.OpenRs232("COM8:9600"))
            {
                this.cc.Content = "连接成功";
            }
            else
            {
                connected.Close();
                this.cc.Content = "已关闭";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            API.Msg.MsgObject_MifaAppCmd_Read cc = new API.Msg.MsgObject_MifaAppCmd_Read();
            
            connected.SendSyncMsg(cc);
            if (cc.ReturnValue == 0)
                this.cc.Content = cc.GetCardSerial[0].ToString("X2") +"-"+ cc.GetCardSerial[1].ToString("X2") + "-" + cc.GetCardSerial[2].ToString("X2") + "-" + cc.GetCardSerial[3].ToString("X2") ;
        }//99 99 E5 39
    }
}
