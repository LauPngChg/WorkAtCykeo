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
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Xaml;

namespace ConsumablesCabinet
{
    public enum eShowMainPage
    {
        eTest, eDisplay, eLink
    }
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public Module_Connected.Page1 LPage1;
        public TestMode.Page1 Tpage1;
        public DisplayMode.Page1 Dpage1;
        public eShowMainPage showMainPage;
        bool IsChs;
        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += WindowMove;
            this.checkBoxMode.Click += ModeSwitchFun;
            this.checkBoxLang.Click += LanguageSwitchFun;
            this.BtnShutdown.MouseLeftButtonDown += ShutDown;
            this.BtnLog.MouseLeftButtonDown += ShowLog;
            this.BtnConnect.MouseLeftButtonDown += Connected;
            Init();            
        }
        private void WindowMove(object sender, MouseButtonEventArgs e) => this.DragMove();
        private void ModeSwitchFun(object sender, RoutedEventArgs e)
        {
            if (((CheckBox)sender).IsChecked == true)
            {
                SwitchMode(eShowMainPage.eTest);
                this.appName.Text = this.Resources["THM-0001"].ToString();//
            }
            else
            {
                SwitchMode(eShowMainPage.eDisplay);
                this.appName.Text = this.Resources["THM-0002"].ToString();//
            }
        }
        private void LanguageSwitchFun(object sender, RoutedEventArgs e)
        {
            if (((CheckBox)sender).IsChecked == true)
            {
                IsChs = true;
                PublicResources.AutoSave.ConfigManager.SaveAppSetting("Chs-Eng", "0");
            }
            else
            {
                IsChs = false;
                PublicResources.AutoSave.ConfigManager.SaveAppSetting("Chs-Eng", "1");
            }
            SwitchLanguage(showMainPage);
            if (showMainPage == eShowMainPage.eTest)//
                this.appName.Text = this.Resources["THM-0001"].ToString();//
            else if (showMainPage == eShowMainPage.eDisplay)//
                this.appName.Text = this.Resources["THM-0002"].ToString();//
        }
        private void ShutDown(object sender, MouseButtonEventArgs e) => this.Close();
        private void ShowLog(object o, MouseButtonEventArgs e) { }
        private void Connected(object o, MouseButtonEventArgs e) { SwitchMode(showMainPage = eShowMainPage.eLink);}
        private void Init()
        {
            //启动获取用户上次操作使用的界面、语言
            this.checkBoxLang.IsChecked = IsChs = GetUserData("Chs-Eng") == "0" ? true : false;
            switch (GetUserData("Test-Display"))
            {
                case "0":
                    this.checkBoxMode.IsChecked = true;
                    showMainPage = eShowMainPage.eTest;
                    break;
                case "1":
                    this.checkBoxMode.IsChecked = false;
                    showMainPage = eShowMainPage.eDisplay;
                    break;
                default:
                    showMainPage = eShowMainPage.eLink;
                    break;
            }
            SwitchMode(showMainPage);
        }

        private void SwitchMode(eShowMainPage show)
        {
            try
            {
                switch (show)
                {
                    case eShowMainPage.eTest:
                        Dpage1 = null;
                        LPage1 = null;
                        this.pageContainer.Content = Tpage1 = new TestMode.Page1();
                        break;
                    case eShowMainPage.eDisplay:
                        Tpage1 = null;
                        LPage1 = null;
                        this.pageContainer.Content = Dpage1 = new DisplayMode.Page1();
                        break;
                    default:
                        this.checkBoxMode.IsEnabled = false;
                        this.pageContainer.Content = LPage1 = new Module_Connected.Page1();
                        Dpage1 = null;
                        Tpage1 = null;
                        break;
                }
                SwitchLanguage(show);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void SwitchLanguage(eShowMainPage show)
        {
            try
            {
                var resourceDistionary = new ResourceDictionary() { Source = IsChs ? PublicResources.lang.Languages.ResourceChsUri : PublicResources.lang.Languages.ResourceEngUri };
                this.Resources.MergedDictionaries.Add(resourceDistionary);
                switch (show)
                {
                    case eShowMainPage.eTest:
                        showMainPage = eShowMainPage.eTest;
                        Tpage1.Resources.MergedDictionaries.Add(resourceDistionary);
                        break;
                    case eShowMainPage.eDisplay:
                        showMainPage = eShowMainPage.eDisplay;
                        Dpage1.Resources.MergedDictionaries.Add(resourceDistionary);
                        break;
                    default:
                        showMainPage = eShowMainPage.eLink;
                        LPage1.Resources.MergedDictionaries.Add(resourceDistionary);
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private string GetUserData(string Key)  { return PublicResources.AutoSave.ConfigManager.GetAppSetting(Key); }
        private void SaveUserData(string Key, string Value)  {  PublicResources.AutoSave.ConfigManager.SaveAppSetting(Key,Value); }

    }

            //this.pageContainer.Content = displayMode;
            //this.pageContainer.Source = new Uri("/DisplayMode/Page1.xaml", UriKind.RelativeOrAbsolute);
            //this.pageContainer.Navigate(new Uri("pack://application:,,,/DisplayMode;component/Page1.xaml", UriKind.RelativeOrAbsolute));
            //PublicResources.AutoSave.ConfigManager.SaveAppSetting("test-display", "1");

    }
