using Common.WPF.Helpers;
using CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using October.Basic.Common;
using October.Basic.Models;
using Prism.Interactivity;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace October.Component.Controls
{
    public class CustomPopupWindowAction : PopupWindowAction
    {
        private Window _window = null;

        public void CloseWindow()
        {
            if (_window != null)
                _window.Close();
        }

        /// <summary>
        /// 通过重写PopupWindowAction中的GetWindow方法，设置Window的Style属性。
        /// 否则打开的只能是默认窗体，无法设置样式。
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        protected override Window GetWindow(INotification notification)
        {
            if (this.WindowContent != null)
            {

                IUnityContainer container = ServiceLocator.Current.GetInstance<IUnityContainer>();
                _window = container.Resolve<PopWindow>();
                Dictionary<string, object> args = notification.Content as Dictionary<string, object>;
                (_window.DataContext as PopWindowViewModel).PopWindowInfo = args[ParameterNames.PopWindowInfo] as PopWindowInfoEntity;
                args.Remove(ParameterNames.PopWindowInfo);
                (_window.DataContext as PopWindowViewModel).InitDatas = args;
                float dpi = FullScreenHelper.GetDPI();
                (_window.DataContext as PopWindowViewModel).PopWindowInfo.WindowWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / (dpi / 100) * 0.8;//计算dpi 再乘以当前屏幕的80%
                (_window.DataContext as PopWindowViewModel).PopWindowInfo.WindowHegiht = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / (dpi / 100) * 0.8;
                _window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                _window.Title = notification.Title;
                this.PrepareContentForWindow(notification, _window);
            }
            else
            {
                _window = this.CreateDefaultWindow(notification);
            }
            return _window;
        }
    }
}
