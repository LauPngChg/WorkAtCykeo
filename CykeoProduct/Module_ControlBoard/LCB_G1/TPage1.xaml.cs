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

namespace Module_ControlBoard.LCB_G1
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
            if (connected.OpenRs232("COM8:115200"))
            {
                MessageBox.Show("连接成功");
                connected.dSwitchLock += new API.delegateSwitchLock(LockSwitch);
            }
            else
            {
                connected.Close();
                MessageBox.Show("已断开");
            }
        }
        public void LockSwitch(API.Msg.MsgObject_GetLockStatus lockSwitch)
        {
            switch (lockSwitch.GetLockID)
            {
                case API.Msg.eLockID.Lock1:
                    if (lockSwitch.GetLockStatus == API.Msg.eSwitchStatus.Close)
                    {
                        this.checkboxLock1.IsChecked = false;
                    }
                    else
                    {
                        this.checkboxLock1.IsChecked = true;
                    }
                    break;
                case API.Msg.eLockID.Lock2:
                    if (lockSwitch.GetLockStatus == API.Msg.eSwitchStatus.Close)
                    {
                        this.checkboxLock2.IsChecked = false;
                    }
                    else
                    {
                        this.checkboxLock2.IsChecked = true;
                    }
                    break;
            }
            MessageBox.Show( lockSwitch.GetLockID + "" + lockSwitch.GetLockStatus);
        }
        API.Msg.MsgObject_SwitchLED led1 = new API.Msg.MsgObject_SwitchLED() { Address = 0x02 };
        API.Msg.MsgObject_SwitchLED led2 = new API.Msg.MsgObject_SwitchLED() { Address = 0x02 };
        API.Msg.MsgObject_SwitchLED led3 = new API.Msg.MsgObject_SwitchLED() { Address = 0x02 };
        API.Msg.MsgObject_SwitchLED led4 = new API.Msg.MsgObject_SwitchLED() { Address = 0x02 };
        
        private void checkboxLED1_Checked(object sender, RoutedEventArgs e)
        {
                led1.LED = API.Msg.eLedID.LED1;
                led1.SwitchStatus = API.Msg.eSwitchStatus.Open;
                connected.SendSyncMsg(led1);
            test.Text = led1.ReturnMsg;
        }
        private void checkboxLED1_Checked1(object sender, RoutedEventArgs e) {
            led1.LED = API.Msg.eLedID.LED1;
                led1.SwitchStatus = API.Msg.eSwitchStatus.Close;
                connected.SendSyncMsg(led1);
            test.Text = led1.ReturnMsg;
        }
        private void checkboxLED2_Checked1(object sender, RoutedEventArgs e) {
            led2.LED = API.Msg.eLedID.LED2;
            led2.SwitchStatus = API.Msg.eSwitchStatus.Close;
            connected.SendSyncMsg(led2);
            test.Text = led2.ReturnMsg;
        }
        private void checkboxLED3_Checked1(object sender, RoutedEventArgs e) {
            led3.LED = API.Msg.eLedID.LED3;
            led3.SwitchStatus = API.Msg.eSwitchStatus.Close;
            connected.SendSyncMsg(led3);
            test.Text = led3.ReturnMsg;
        }
        private void checkboxLED4_Checked1(object sender, RoutedEventArgs e)
        {
            led4.LED = API.Msg.eLedID.LED4;
            led4.SwitchStatus = API.Msg.eSwitchStatus.Close;
            connected.SendSyncMsg(led4);
            test.Text = led4.ReturnMsg;
        }
        private void checkboxLED2_Checked(object sender, RoutedEventArgs e)
        {

                led2.LED = API.Msg.eLedID.LED2;
                led2.SwitchStatus = API.Msg.eSwitchStatus.Open;
                connected.SendSyncMsg(led2);
            test.Text = led2.ReturnMsg;

        }

        private void checkboxLED3_Checked(object sender, RoutedEventArgs e)
        {

                led3.LED = API.Msg.eLedID.LED3;
                led3.SwitchStatus = API.Msg.eSwitchStatus.Open;
                connected.SendSyncMsg(led3);
            test.Text = led3.ReturnMsg;

        }

        private void checkboxLED4_Checked(object sender, RoutedEventArgs e)
        {

                led4.LED = API.Msg.eLedID.LED4;
                led4.SwitchStatus = API.Msg.eSwitchStatus.Open;
                connected.SendSyncMsg(led4);
            test.Text = led4.ReturnMsg;

        }

        private void checkboxLock1_Checked(object sender, RoutedEventArgs e)
        {
            API.Msg.MsgObject_OpenLock locked = new API.Msg.MsgObject_OpenLock() { Address = 2};
            locked.LockID = API.Msg.eLockID.Lock2;
            connected.SendSyncMsg(locked);
            test.Text = locked.ReturnMsg;
        }

        private void checkboxLock1_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
