using Common.WPF.Helpers;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using October.Basic.Common;
using October.Basic.Models;
using October.Main.ViewModels;
using October.Main.Views;
using Prism.Events;
using Prism.Regions;
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

namespace October.Main.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        IEventAggregator _eventAggregator;
        public MainWindow()
        {
            InitializeComponent();
            this.IsHitTestVisible = false;
            IUnityContainer container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            this.Loaded += MainWindow_Loaded;
            this.Closed += MainWindow_Closed;
            RegionManager.SetRegionManager(this, container.Resolve<IRegionManager>());
            _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            _eventAggregator.GetEvent<MainWinChangeEvent>().Subscribe(StatusChange);
            _eventAggregator.GetEvent<ActiveMainWindowEvent>().Subscribe(ActiveMainWindow);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(new Action(LoadedExcute));
        }
        private void LoadedExcute()
        {
            AxRenderWindow axRenderWindow = ServiceLocator.Current.GetInstance<AxRenderWindow>();
            FullScreenHelper.RepairWpfWindowFullScreenBehavior(axRenderWindow);
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
            mainWin.Closing += (s, args) =>
            {
                axRenderWindow.Close();
            };
            mainWin.Closed += (s, args) =>
            {                
                (this.DataContext as MainWindowViewModel).CloseCommand.Execute();
            };
            axRenderWindow.Show();
            mainWin.Owner = axRenderWindow;
            this.Background = Brushes.Transparent;
            axRenderWindow.WindowState = WindowState.Maximized;
            mainWin.Activate();
        }

        public void ActiveMainWindow(bool? disable)
        {
            if (disable == null)
            {
                this.Activate();
            }
            else if (disable.GetValueOrDefault())
            {
                this.Activate();
                this.IsHitTestVisible = false;
            }
            else
            {
                this.IsHitTestVisible = true;
            }
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            //ImageToggleButton_Unchecked(null, null);
        }

        private void TitleMenuContainer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            tbTitle.Focus();
        }

        private void StatusChange(WindowChangeEnum windowChangeEnum)
        {
            switch (windowChangeEnum)
            {
                case WindowChangeEnum.Min:
                    this.WindowState = WindowState.Minimized;
                    break;
                case WindowChangeEnum.Max:
                    this.WindowState = WindowState.Normal;
                    break;
                case WindowChangeEnum.Normal:
                    this.WindowState = WindowState.Maximized;
                    break;
                case WindowChangeEnum.Close:
                    {
                        //ServiceLocator.Current.GetInstance<EventAggregator>().GetEvent<ShowWaitIndicatorEvent>().Publish(true);
                        this.Close();
                    }
                    break;
            }
        }

        private void ImageToggleButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
