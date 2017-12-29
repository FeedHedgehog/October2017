using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace October.Component.Controls
{
    public class PopMessageDialogHelper
    {

        public static async void ShowPopMessageDialog(string identify, string text, PopMessageType msgType, Action<bool> callBack)
        {
            PopMessageDialog dialog = new PopMessageDialog
            {
                Text = text,

            };
            if (msgType == PopMessageType.Confirm)
            {
                dialog.MessageBoxButton = MessageBoxButton.OKCancel;
            }
            else if (msgType == PopMessageType.ConfirmYesNoCancel)
            {
                dialog.MessageBoxButton = MessageBoxButton.YesNoCancel;
            }
            else if (msgType == PopMessageType.ConfirmYesNo)
            {
                dialog.MessageBoxButton = MessageBoxButton.YesNo;
            }
            else
            {
                dialog.MessageBoxButton = MessageBoxButton.OK;
            }
            var flag = await DialogHost.Show(dialog, identify);
            if (callBack != null)
            {
                callBack((MessageBoxResult)flag == MessageBoxResult.OK);
            }
        }

    }

    public enum PopMessageType
    {
        Notifycation,
        Confirm,
        ConfirmYesNoCancel,
        ConfirmYesNo
    }
}
