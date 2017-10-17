using October.Component.Controls;
using October.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace October.Main
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : BaseWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
            LoginWindowViewModel login = new LoginWindowViewModel();
            login.CloseAction = new Action(this.Close);
            this.DataContext = login;
            //设置关闭
            //(this.DataContext as LoginWindowViewModel).CloseAction = new Action(this.Close);
        }
    }
}
