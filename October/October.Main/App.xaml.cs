using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace October.Main
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();

            //GlobalConfig.ServerURL = ConfigurationManager.AppSettings["ServerURL"];
            //GlobalConfig.RequestTimeOut = int.Parse(ConfigurationManager.AppSettings["RequestTimeOut"]);            
            //uint temp = 0;
            //if (uint.TryParse(ConfigurationManager.AppSettings["VideoServerPort"], out temp))
            //{
            //    GlobalConfig.VideoServerPort = temp;
            //}        

            //bool isServerUrl = false;
            //bool.TryParse(ConfigurationManager.AppSettings["isServerUrl"], out isServerUrl);
            //GlobalConfig.IsMapServerModel = isServerUrl;

            this.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        /// <summary>
        /// 捕获分发未捕获的异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            LogHelper.Error(e.Exception);
            e.Handled = true;
        }

        /// <summary>
        /// 当前域 未捕获的异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is System.Exception)
            {
                LogHelper.Error((System.Exception)e.ExceptionObject);
            }
        }
    }
}
