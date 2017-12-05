using October.Component.BimViewer.Controls;
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

namespace October.Main.Views
{
    /// <summary>
    /// AxRenderWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AxRenderWindow : Window
    {
        public AxRenderWindow()
        {
            InitializeComponent();
            AxRenderUc axRenderUc = new AxRenderUc();
            host.Child = axRenderUc;
            this.Loaded += AxRenderWindow_Loaded;
        }

        private void AxRenderWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
