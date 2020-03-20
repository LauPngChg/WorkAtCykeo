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

namespace Module_ControlBoard.LCB_B1
{
    /// <summary>
    /// TPage1.xaml 的交互逻辑
    /// </summary>
    public partial class TPage1 : Page
    {
        API.Connected.ConnectedMethod connect;
        public TPage1()
        {
            InitializeComponent();
            connect = new API.Connected.ConnectedMethod();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (connect.OpenRs232("COM8:115200"))
            {
                this.cc.Content = "成功";
                connect.dLockStatus += CC;
            }
            else
            {
                connect.Close();
                this.cc.Content = "失败";
            }
        }
        public void CC(API.Msg.NotifyLockStatus notify)
        {
            MessageBox.Show(notify.OpenedLock.Count + "-");
        }
    }
}
