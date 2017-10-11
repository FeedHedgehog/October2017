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
            //GlobalConfig.ActiveMQProviderURL = ConfigurationManager.AppSettings["ActiveMQProviderURL"];
            //GlobalConfig.MQProviderUserName = ConfigurationManager.AppSettings["MQProviderUserName"];
            //GlobalConfig.MQProviderUserPwd = ConfigurationManager.AppSettings["MQProviderUserPwd"];
            //GlobalConfig.CityMakerServerUserPwd = ConfigurationManager.AppSettings["CityMakerServerUserPwd"];
            //GlobalConfig.VideoServerIP = ConfigurationManager.AppSettings["VideoServerIP"];
            //uint temp = 0;
            //if (uint.TryParse(ConfigurationManager.AppSettings["VideoServerPort"], out temp))
            //{
            //    GlobalConfig.VideoServerPort = temp;
            //}
            //GlobalConfig.VideoServerUserName = ConfigurationManager.AppSettings["VideoServerUserName"];
            //GlobalConfig.VideoServerUserPwd = ConfigurationManager.AppSettings["VideoServerUserPwd"];
            //GlobalConfig.FtpServerUrl = ConfigurationManager.AppSettings["FtpServerUrl"];
            //GlobalConfig.FtpUserName = ConfigurationManager.AppSettings["FtpUserName"];
            //GlobalConfig.FtpUserPwd = ConfigurationManager.AppSettings["FtpUserPwd"];
            //GlobalConfig.FtpServerCategory = ConfigurationManager.AppSettings["FtpServerCategory"];

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
            //LogHelper.Error(e.Exception);
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
                //LogHelper.Error((System.Exception)e.ExceptionObject);
            }
        }
    }
}
