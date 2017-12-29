using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace October.Component.Controls
{
    /// <summary>
    /// PopMessageDialog.xaml 的交互逻辑
    /// </summary>
    public partial class PopMessageDialog : UserControl
    {

        #region MessageBoxButton
        public static readonly DependencyProperty MessageBoxButtonProperty = DependencyProperty.Register("MessageBoxButton",
              typeof(MessageBoxButton), typeof(PopMessageDialog), new FrameworkPropertyMetadata(MessageBoxButton.OK));
        [Category("Behavior")]
        public MessageBoxButton MessageBoxButton
        {
            get
            {
                return (MessageBoxButton)this.GetValue(PopMessageDialog.MessageBoxButtonProperty);
            }
            set
            {
                this.SetValue(PopMessageDialog.MessageBoxButtonProperty, value);
            }
        }
        #endregion

        #region Text
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text",
              typeof(string), typeof(PopMessageDialog), new FrameworkPropertyMetadata(null));
        [Category("Behavior")]
        public string Text
        {
            get
            {
                return (string)this.GetValue(PopMessageDialog.TextProperty);
            }
            set
            {
                this.SetValue(PopMessageDialog.TextProperty, value);
            }
        }
        #endregion

        public PopMessageDialog()
        {
            InitializeComponent();
        }
    }
}
