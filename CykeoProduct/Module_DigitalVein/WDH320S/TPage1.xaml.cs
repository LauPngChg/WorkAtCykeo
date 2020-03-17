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

namespace Module_DigitalVein.WDH320S
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
            if (connected.OpenRs232("COM6:115200"))
            {
                MessageBox.Show("OK");
            }
            else
            {
                connected.Close();
                MessageBox.Show("Closed");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            API.Msg.MsgObject_Get_FirmwareVersion cc = new API.Msg.MsgObject_Get_FirmwareVersion();
            connected.SendSyncMsg(cc);
            if (cc.ReturnValue == 0)
            {
                MessageBox.Show(cc.GetFirmwareVersion);
            }
        }
    }
}
