using Microsoft.Practices.ServiceLocation;
using October.Main.ViewModels;
using October.Main.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace October.Main
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this.Closed += MainWindow_Closed;
        }      

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(new Action(LoadedExcute));
        }
        private void LoadedExcute()
        {
            AxRenderWindow axRenderWindow = ServiceLocator.Current.GetInstance<AxRenderWindow>();
            //FullScreenHelper.RepairWpfWindowFullScreenBehavior(axRenderWindow);
            axRenderWindow.WindowState = WindowState.Minimized;
            Window mainWin = this;
            mainWin.LocationChanged += (s, args) =>
            {
                axRenderWindow.Left = mainWin.Left;
                axRenderWindow.Top = mainWin.Top;
            };
            mainWin.StateChanged += (s, argrs) =>
            {
                axRenderWindow.WindowState = mainWin.WindowState;
            };
            mainWin.Closed += (s, args) =>
            {
                //(this.DataContext as MainWindowViewModel).CloseCommand.Execute();
                //axRenderWindow.Close();
            };
            axRenderWindow.Show();
            mainWin.Owner = axRenderWindow;
            this.Background = Brushes.Transparent;
            axRenderWindow.WindowState = WindowState.Maximized;
            //mainWin.Activate();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {

        }
    }
}
