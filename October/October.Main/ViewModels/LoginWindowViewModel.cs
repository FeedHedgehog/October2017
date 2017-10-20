using Microsoft.Practices.ServiceLocation;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace October.Main.ViewModels
{
    public class LoginWindowViewModel
    {
        #region Fields

        public Action CloseAction { get; set; }
        public DelegateCommand LoginCommand { get; private set; }

        #endregion


        public LoginWindowViewModel()
        {
            this.LoginCommand = new DelegateCommand(Login);
        }


        #region Methods

        private void Login()
        {
            ShowMainWindowAndAxWindow();
        }

        private void ShowMainWindowAndAxWindow()
        {
            MainWindow mainWin = ServiceLocator.Current.GetInstance<MainWindow>();
            //mainWin.Topmost = true;
            //FullScreenHelper.RepairWpfWindowFullScreenBehavior(mainWin);

            mainWin.WindowState = WindowState.Maximized;
            Application.Current.MainWindow = mainWin;
            CloseAction();//根据客户要求，先关闭登录窗口，再加载动画
            //显示加载动画
            //ServiceLocator.Current.GetInstance<EventAggregator>().GetEvent<ShowWaitIndicatorEvent>().Publish(false);
            mainWin.Show();
        }

        #endregion

    }
}
