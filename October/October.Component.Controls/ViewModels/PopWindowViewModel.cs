using Microsoft.Practices.Unity;
using October.Basic.Common;
using October.Basic.Contracts;
using October.Basic.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace October.Component.Controls
{
    /// <summary>
    ///Name:PopWindowViewModel
    ///Editor:jason   
    ///Modifier:
    ///ModificationTime:
    ///Content:弹出窗体的视图模型
    /// </summary>
    public class PopWindowViewModel : BindableBase
    {
        private bool _isActivate = false;
        private bool _isClose = false;
        private Dictionary<string, object> _initDatas = null;
        private IRegionManager _regionManager = null;
        private IEventAggregator _eventAggregator = null;
        private IUnityContainer _container = null;
        private INavigationPage _currentView = null;
        private PopWindowInfoEntity _popWindowInfoEntity = null;
        private FrameworkElement _customControl = null;
        #region Commands

        public DelegateCommand<object> LoadCommand { get; private set; }

        public DelegateCommand CloseCommand { get; private set; }

        public DelegateCommand UpCommand { get; private set; }

        public DelegateCommand NextCommand { get; private set; }

        public DelegateCommand HomeCommand { get; private set; }
        #endregion

        #region Attribute
        public PopWindowInfoEntity PopWindowInfo
        {
            get { return _popWindowInfoEntity; }
            set
            {
                SetProperty(ref _popWindowInfoEntity, value);
            }
        }

        public FrameworkElement CustomControl
        {
            get { return _customControl; }
            set
            {
                SetProperty(ref _customControl, value);
            }
        }

        public Dictionary<string, object> InitDatas
        {
            get { return _initDatas; }
            set { SetProperty(ref _initDatas, value); }
        }

        public bool IsActivate
        {
            get { return _isActivate; }
            set
            {

                SetProperty(ref _isActivate, value);
                RaisePropertyChanged("IsActivate");
            }
        }

        public bool IsClose
        {

            get { return _isClose; }
            set
            {

                SetProperty(ref _isClose, value);
                RaisePropertyChanged("IsClose");
            }
        }

        #endregion

        public PopWindowViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _container = container;

            this.NextCommand = new DelegateCommand(Next);
            this.UpCommand = new DelegateCommand(Up);
            this.HomeCommand = new DelegateCommand(Home);
            this.LoadCommand = new DelegateCommand<object>(LoadMainPage);
            this.CloseCommand = new DelegateCommand(Close);
            _eventAggregator.GetEvent<PopWindowActivateEvents>().Subscribe(ActivateWindow);
            _eventAggregator.GetEvent<PopWindowCloseEvents>().Subscribe(CloseWindow);
        }

        #region private Method

        private void Up()
        {
            _currentView.Journal.GoBack();
        }

        private void Next()
        {
            _currentView.Journal.GoForward();
        }

        private void Home()
        {
            if (this.PopWindowInfo.CustomHome == null)
            {
                _regionManager.Regions[PopWindowInfo.RegionName].RemoveAll();
                _currentView.Journal.Clear();
                _currentView = null;
                RegionManager.UpdateRegions();
                NavigationParameters parameters = new NavigationParameters();
                parameters.Add(ParameterNames.PopWindowInfo, this.PopWindowInfo);
                _regionManager.RequestNavigate(PopWindowInfo.RegionName, this.PopWindowInfo.HomePath, parameters);
            }
            else
            {
                this.PopWindowInfo.CustomHome();
            }
        }

        private void LoadMainPage(object popWindow)
        {
            NavigationParameters parameters = new NavigationParameters();
            parameters.Add(ParameterNames.PopWindowInfo, this.PopWindowInfo);
            if (this.InitDatas != null && this.InitDatas.Count > 0)
            {
                foreach (KeyValuePair<string, object> pair in this.InitDatas)
                {
                    parameters.Add(pair.Key, pair.Value);
                }
            }
            _regionManager.Regions[PopWindowInfo.RegionName].NavigationService.Navigated += NavigationService_Navigated;
            _regionManager.RequestNavigate(PopWindowInfo.RegionName, PopWindowInfo.HomePath, parameters);
        }

        private void Close()
        {
            _regionManager.Regions[PopWindowInfo.RegionName].RemoveAll();
            //_currentView.Journal.Clear();
            _currentView = null;
            RegionManager.UpdateRegions();
            _regionManager.Regions[PopWindowInfo.RegionName].NavigationService.Navigated -= NavigationService_Navigated;
        }

        private void NavigationService_Navigated(object sender, RegionNavigationEventArgs e)
        {
            SetViewInfo();
            if (_currentView != null)
            {
                _currentView.Journal = e.NavigationContext.NavigationService.Journal;
                this.PopWindowInfo.IsUp = _currentView.Journal.CanGoBack;
                this.PopWindowInfo.IsNext = _currentView.Journal.CanGoForward;
            }
        }

        private void SetViewInfo()
        {
            IViewsCollection views = _regionManager.Regions[this.PopWindowInfo.RegionName].ActiveViews;
            if (views.Count() > 0 && (views.ToList()[0] is FrameworkElement) && (views.ToList()[0] as FrameworkElement).DataContext is INavigationPage)
            {
                _currentView = (views.ToList()[0] as FrameworkElement).DataContext as INavigationPage;
                _currentView.PopWindowInfo = this.PopWindowInfo;
                this.CustomControl = _currentView.CreateCustomControl();
            }
        }

        private void ActivateWindow(string strName)
        {
            if (this.PopWindowInfo.RegionName == strName)
                this.IsActivate = true;
        }

        private void CloseWindow(string strName)
        {
            if (this.PopWindowInfo.RegionName == strName)
                this.IsClose = true;
        }

        #endregion

    }
}
