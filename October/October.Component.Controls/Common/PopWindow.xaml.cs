using Microsoft.Practices.ServiceLocation;
using October.Component.Controls;
using Prism.Regions;
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
    /// PopWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PopWindow : BaseWindow
    {
        private Grid _titlegrid = null;

        public PopWindow()
        {
            InitializeComponent();
            RegionManager.SetRegionManager(this, ServiceLocator.Current.GetInstance<IRegionManager>());
            RegionManager.UpdateRegions();
            (this.DataContext as PopWindowViewModel).PropertyChanged += PopWindow_PropertyChanged;
        }



        private void PopWindow_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsActivate")
            {
                ActivateWindow((this.DataContext as PopWindowViewModel).IsActivate);
            }
            if (e.PropertyName == "IsClose")
            {
                CloseWindow((this.DataContext as PopWindowViewModel).IsClose);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (_titlegrid != null)
                _titlegrid.MouseLeftButtonDown -= Grid_MouseLeftButtonDown;
            (this.DataContext as PopWindowViewModel).CloseCommand.Execute();
            base.OnClosing(e);

        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _titlegrid = this.Template.FindName("Title", this) as Grid;
            if (_titlegrid != null)
                _titlegrid.MouseLeftButtonDown += Grid_MouseLeftButtonDown;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ActivateWindow(bool isActivate)
        {
            if (isActivate)
            {
                this.Focus();
                this.WindowState = WindowState.Normal;
                this.Activate();
            }
        }

        private void CloseWindow(bool isClose)
        {
            if (isClose)
            {
                this.Close();
            }
        }
    }
}
