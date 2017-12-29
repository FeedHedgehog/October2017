using MaterialDesignThemes.Wpf;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace October.Component.Controls
{
    /// <summary>
    /// Represents a Modern UI styled dialog window.
    /// </summary>
    public class MessageDialog : Window
    {
        /// <summary>
        /// Identifies the BackgroundContent dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseCommandProperty = DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(MessageDialog));
        /// <summary>
        /// Identifies the Buttons dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register("Buttons", typeof(IEnumerable<Button>), typeof(MessageDialog));

        private ICommand closeTrueCommand;
        private ICommand closeFalseCommand;
        private ICommand cancelCommand;

        private Button okButton;
        private Button cancelButton;
        private Button yesButton;
        private Button noButton;
        private Button closeButton;

        private MessageBoxResult msgResult;
        /// <summary>
        /// 消息结果
        /// </summary>
        public MessageBoxResult MsgResult
        {
            get { return msgResult; }
            set { msgResult = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageDialog"/> class.
        /// </summary>
        public MessageDialog()
        {
            this.DefaultStyleKey = typeof(MessageDialog);
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.closeTrueCommand = new DelegateCommand(() =>
            {
                this.DialogResult = true;
                this.MsgResult = MessageBoxResult.Yes;
                Close();
            });
            this.closeFalseCommand = new DelegateCommand(() =>
            {
                this.DialogResult = false;
                this.MsgResult = MessageBoxResult.No;
                Close();
            });
            this.CloseCommand = new DelegateCommand(() =>
            {
                this.MsgResult = MessageBoxResult.None;
                Close();
            });
            this.cancelCommand = new DelegateCommand(() =>
            {
                this.DialogResult = null;
                this.MsgResult = MessageBoxResult.Cancel;
                Close();
            });

            this.Buttons = new Button[] { this.CloseButton };

            // set the default owner to the app main window (if possible)
            if (Application.Current != null && Application.Current.MainWindow != this)
            {
                this.Owner = Application.Current.MainWindow;
            }
        }

        private Button CreateDialogButton(string content, bool isDefault, bool isCancel, ICommand command)
        {
            return new Button
            {
                Content = content,
                Command = command,
                IsDefault = isDefault,
                IsCancel = isCancel,
                MinHeight = 21,
                MinWidth = 65,
                Margin = new Thickness(4, 0, 0, 0)
            };
        }

        /// <summary>
        /// Gets the close window command that sets the dialog result to True.
        /// </summary>
        public ICommand CloseTrueCommand
        {
            get { return this.closeTrueCommand; }
        }

        /// <summary>
        /// Gets the close window command that sets the dialog result to false.
        /// </summary>
        public ICommand CloseFalseCommand
        {
            get { return this.closeFalseCommand; }
        }

        ///// <summary>
        ///// Gets the close window command that sets the dialog result to a null value.
        ///// </summary>
        //public ICommand CloseCommand
        //{
        //    get { return this.closeCommand; }
        //}

        /// <summary>
        /// Gets the Ok button.
        /// </summary>
        public Button OkButton
        {
            get
            {
                if (this.okButton == null)
                {
                    this.okButton = CreateDialogButton("确定", true, false, this.closeTrueCommand);
                }
                return this.okButton;
            }
        }

        /// <summary>
        /// Gets the Cancel button.
        /// </summary>
        public Button CancelButton
        {
            get
            {
                if (this.cancelButton == null)
                {
                    this.cancelButton = CreateDialogButton("取消", false, true, this.CancelCommand);
                }
                return this.cancelButton;
            }
        }

        /// <summary>
        /// Gets or sets the background content of this window instance.
        /// </summary>
        public ICommand CancelCommand
        {
            get { return this.cancelCommand; }
        }

        /// <summary>
        /// Gets the Yes button.
        /// </summary>
        public Button YesButton
        {
            get
            {
                if (this.yesButton == null)
                {
                    this.yesButton = CreateDialogButton("是", true, false, this.closeTrueCommand);
                }
                return this.yesButton;
            }
        }

        /// <summary>
        /// Gets the No button.
        /// </summary>
        public Button NoButton
        {
            get
            {
                if (this.noButton == null)
                {
                    this.noButton = CreateDialogButton("否", false, true, this.closeFalseCommand);
                }
                return this.noButton;
            }
        }

        /// <summary>
        /// Gets the Close button.
        /// </summary>
        public Button CloseButton
        {
            get
            {
                if (this.closeButton == null)
                {
                    this.closeButton = CreateDialogButton("关闭", true, false, this.CloseCommand);
                }
                return this.closeButton;
            }
        }

        /// <summary>
        /// Gets or sets the background content of this window instance.
        /// </summary>
        public ICommand CloseCommand
        {
            get { return (ICommand)GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); }
        }

        /// <summary>
        /// Gets or sets the dialog buttons.
        /// </summary>
        public IEnumerable<Button> Buttons
        {
            get { return (IEnumerable<Button>)GetValue(ButtonsProperty); }
            set { SetValue(ButtonsProperty, value); }
        }

        /// <summary>
        /// Displays a messagebox.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="title">The title.</param>
        /// <param name="button">The button.</param>
        /// <returns></returns>
        public static bool? ShowMessage(string text, string title, MessageBoxButton button)
        {
            var dlg = new MessageDialog
            {
                Title = title,
                Content = new TextBlock { Text = text, Margin = new Thickness(0, 0, 0, 8) },
                MinHeight = 0,
                MinWidth = 0,
                MaxHeight = 480,
                MaxWidth = 640,
            };

            dlg.Buttons = GetButtons(dlg, button);

            return dlg.ShowDialog();
        }

        public static MessageBoxResult ShowMsg(string text, string title, MessageBoxButton button)
        {
            var dlg = new MessageDialog
            {
                Title = title,
                Content = new TextBlock { Text = text, Margin = new Thickness(0, 0, 0, 8) },
                MinHeight = 0,
                MinWidth = 0,
                MaxHeight = 480,
                MaxWidth = 640,
            };

            dlg.Buttons = GetButtons(dlg, button);

            dlg.ShowDialog();
            return dlg.MsgResult;
        }

        /// <summary>
        /// 使用窗口内部弹出消息的方式弹出，有返回
        /// </summary>
        /// <param name="text"></param>
        /// <param name="button"></param>
        /// <param name="regionName"></param>
        /// <returns></returns>
        public static async Task<MessageBoxResult> ShowMsg(string text, MessageBoxButton button, string regionName)
        {
            PopMessageDialog dialog = new PopMessageDialog
            {
                Text = text,
                MessageBoxButton = button
            };
            var flag = await DialogHost.Show(dialog, regionName);
            return (MessageBoxResult)flag;
        }

        /// <summary>
        /// 使用窗口内部弹出消息方式弹出，无返回
        /// </summary>
        /// <param name="text"></param>
        /// <param name="regionName"></param>
        public static void Show(string text, string regionName)
        {
            PopMessageDialog errorDialog = new PopMessageDialog
            {
                Text = text,
                MessageBoxButton = MessageBoxButton.OK
            };
            DialogHost.Show(errorDialog, regionName);
        }

        public static void Show(string text)
        {
            MessageDialog.ShowMessage(text, "提示", MessageBoxButton.OK);
        }

        private static IEnumerable<Button> GetButtons(MessageDialog owner, MessageBoxButton button)
        {
            if (button == MessageBoxButton.OK)
            {
                yield return owner.OkButton;
            }
            else if (button == MessageBoxButton.OKCancel)
            {
                yield return owner.OkButton;
                yield return owner.CancelButton;
            }
            else if (button == MessageBoxButton.YesNo)
            {
                yield return owner.YesButton;
                yield return owner.NoButton;
            }
            else if (button == MessageBoxButton.YesNoCancel)
            {
                yield return owner.YesButton;
                yield return owner.NoButton;
                yield return owner.CancelButton;
            }
        }
    }
}
