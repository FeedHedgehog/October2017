using Microsoft.Practices.Unity;
using October.Basic.Common;
using October.Basic.Contracts;
using October.Basic.Models;
using October.Component.Controls;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace October.Main.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private List<CustomPopupWindowAction> _windowActions = null;
        IEventAggregator _eventAggregator;
        IRegionManager _regionManager;
        IUnityContainer _container;
        IMenu _menuService;

        #region 属性
        private ObservableCollection<MenuItemEntity> menuList;
        /// <summary>
        /// 插件列表
        /// </summary>
        public ObservableCollection<MenuItemEntity> MenuList
        {
            get
            {
                return menuList;
            }
            set { SetProperty(ref menuList, value); }
        }

        private ObservableCollection<MenuItemEntity> userMenuList;
        /// <summary>
        /// 用户下拉列表
        /// </summary>
        public ObservableCollection<MenuItemEntity> UserMenuList
        {
            get
            {
                return userMenuList;
            }
            set
            {
                SetProperty(ref userMenuList, value);
            }
        }

        private string _currentUserName;
        public string CurrentUserName
        {
            get
            {
                //if (GlobalConfig.CurrentUser != null)
                //{
                //    _currentUserName = GlobalConfig.CurrentUser.name;
                //}
                _currentUserName = "Jason";
                return _currentUserName;
            }
            set
            {
                SetProperty(ref _currentUserName, value);
            }
        }

        private bool isShowRightInfo = false;
        /// <summary>
        /// 是否显示右侧信息栏
        /// </summary>
        public bool IsShowRightInfo
        {
            get { return isShowRightInfo; }
            set
            {
                SetProperty(ref isShowRightInfo, value);
            }
        }

        /// <summary>
        /// 实时报警
        /// </summary>
        //public ObservableCollection<AlarmInfoEntity> RealTimeAlarmList { get; set; } = new ObservableCollection<AlarmInfoEntity>();

        #region 右侧菜单项
        private bool backlogIsChecked;
        public bool BacklogIsChecked
        {
            get { return backlogIsChecked; }
            set
            {

                SetProperty(ref backlogIsChecked, value);
                IsShowRightInfo = value;
            }
        }

        private bool systemNoticeIsChecked;
        public bool SystemNoticeIsChecked
        {
            get { return systemNoticeIsChecked; }
            set
            {
                SetProperty(ref systemNoticeIsChecked, value);
                IsShowRightInfo = value;
            }
        }

        private bool workScheduleIsChecked;
        public bool WorkScheduleIsChecked
        {
            get { return workScheduleIsChecked; }
            set
            {
                SetProperty(ref workScheduleIsChecked, value);
                IsShowRightInfo = value;
            }
        }

        private bool alertListIsChecked;
        public bool AlertListIsChecked
        {
            get { return alertListIsChecked; }
            set
            {
                SetProperty(ref alertListIsChecked, value);
                IsShowRightInfo = value;
            }
        }

        #endregion
        #endregion

        #region Commands

        //public InteractionRequest<INotification> RealTimeMonitorPopupRequest { get; set; }
        /// <summary>
        /// 初始化用命令
        /// </summary>
        public DelegateCommand LoadedCommand { get; private set; }

        public DelegateCommand CloseCommand { get; private set; }

        /// <summary>
        /// 窗口按钮操作
        /// </summary>
        public DelegateCommand<Nullable<WindowChangeEnum>> StatusChangeCommand { get; private set; }

        /// <summary>
        /// 菜单点击命令
        /// </summary>
        public DelegateCommand<MenuItemEntity> MenuItemCommand { get; private set; }

        /// <summary>
        /// 显示报警详细信息
        /// </summary>
        //public DelegateCommand<AlarmInfoEntity> ShowDetailAlarmCommand { get; private set; }

        public DelegateCommand ShowRealtimeMonitorCommand { get; private set; }


        public IDictionary<string, InteractionRequest<INotification>> CustomPopupViewRequestDict { get; set; } = new Dictionary<string, InteractionRequest<INotification>>();

        #endregion

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IMenu menuService, IUnityContainer container)
        {
            this._windowActions = new List<CustomPopupWindowAction>();
            this.menuList = new ObservableCollection<MenuItemEntity>();
            this.userMenuList = new ObservableCollection<MenuItemEntity>();
            this._eventAggregator = eventAggregator;
            this._menuService = menuService;
            this._regionManager = regionManager;
            this._container = container;
            //RealTimeMonitorPopupRequest = new InteractionRequest<INotification>();

            //将View注册到各个Region
            //_container.RegisterTypeForNavigation<ScheduleDetails>(ParameterNames.ScheduleDetails);

            //_regionManager.RegisterViewWithRegion(RegionNames.BottomToolsRegion, typeof(MapToolBar));
            //_regionManager.RegisterViewWithRegion(RegionNames.SearchRegion, typeof(SearchComponent));

            //命令响应
            this.LoadedCommand = new DelegateCommand(LoadedExcute);
            this.StatusChangeCommand = new DelegateCommand<Nullable<WindowChangeEnum>>(StatusChangeExcute);
            this.MenuItemCommand = new DelegateCommand<MenuItemEntity>(MenuItemExcute);
            //this.ShowDetailAlarmCommand = new DelegateCommand<AlarmInfoEntity>(ShowDetailAlarmExcute);
            this.CloseCommand = new DelegateCommand(CloseWindow);
            //注册事件聚合器事件
            //this._eventAggregator.GetEvent<MQAlarmPushEvent>().Subscribe(AddAlarm);
            //this._eventAggregator.GetEvent<RemoveAlarmEvent>().Subscribe(RemoveAlarm);
            this._eventAggregator.GetEvent<CustomPopWindowShowEvents>().Subscribe(CustomPopWindowShow);
            //_eventAggregator.GetEvent<UpdateCurrentUserEvent>().Subscribe(UpdateCurrentUserMethod);        

            Task.Factory.StartNew(InitialUserMenuList);
        }

        #region Menu

        private void InitialUserMenuList()
        {
            MenuItemEntity childMenuItemEntity = new MenuItemEntity();
            childMenuItemEntity.id = Convert.ToInt32(2);
            childMenuItemEntity.code = "PasswordSettings";
            childMenuItemEntity.name = "修改密码";
            MenuItemEntity child1MenuItemEntity = new MenuItemEntity();
            child1MenuItemEntity.id = Convert.ToInt32(1);
            child1MenuItemEntity.code = "PersonalInfo";
            child1MenuItemEntity.name = "修改资料";
            MenuItemEntity menuItemEntity = new MenuItemEntity();
            menuItemEntity.id = Convert.ToInt32(0);
            menuItemEntity.code = "currentUser";
            menuItemEntity.name = "管理员";
            menuItemEntity.children.Add(childMenuItemEntity);
            menuItemEntity.children.Add(child1MenuItemEntity);

            UserMenuList.Add(menuItemEntity);
            RaisePropertyChanged("UserMenuList");
            Application.Current.Dispatcher.Invoke(() =>
            {
                //获取菜单
                _menuService.GetMenu<MenuEntity>((ret) =>
                {
                    if (ret.state.code != StateCodeEnum.Success)
                        LogHelper.Error(ret.state.msg);
                    (ret as MenuEntity).menus.ForEach(p =>
                    {
                        p.SetUpdateNotify(UpdateMenuItemHeight);
                        MenuList.Add(p);
                    });
                    this.MenuList = MenuList;
                    RaisePropertyChanged("MenuList");
                });
            });

        }

        public void UpdateMenuItemHeight(double height)
        {
            MenuItemActualHeight = height;
        }

        private double menuItemActualHeight = 0;

        public double MenuItemActualHeight
        {
            set { SetProperty(ref menuItemActualHeight, value); }
            get { return menuItemActualHeight; }
        }


        private void MenuItemExcute(MenuItemEntity menuItem)
        {

            //特殊的不走Action方式弹出
            LoadPopWindow(menuItem);
        }

        private void CustomPopWindowShow(Dictionary<string, object> datas)
        {
            MenuItemEntity menuItem = datas["MenuItem"] as MenuItemEntity;
            Dictionary<string, object> args = null;
            if (datas.ContainsKey("Args"))
                args = datas["Args"] as Dictionary<string, object>;
            this.IsShowRightInfo = false;
            this.BacklogIsChecked = false;
            this.AlertListIsChecked = false;
            this.SystemNoticeIsChecked = false;
            this.WorkScheduleIsChecked = false;
            LoadPopWindow(menuItem, args);
        }

        private void LoadPopWindow(MenuItemEntity menuItem, Dictionary<string, object> args = null)
        {
            //设置弹出Action 
            if (!this.CustomPopupViewRequestDict.ContainsKey(menuItem.code))
            {
                InteractionRequestTrigger interactionRequestTrigger = new InteractionRequestTrigger();
                CustomPopupWindowAction customPopupWindowAction = new CustomPopupWindowAction() { CenterOverAssociatedObject = true, IsModal = false };
                ContentControl contentControl = new ContentControl();
                RegionManager.SetRegionName(contentControl, menuItem.code + "Region");
                customPopupWindowAction.WindowContent = contentControl;

                interactionRequestTrigger.Actions.Add(customPopupWindowAction);
                InteractionRequest<INotification> request = new InteractionRequest<INotification>();
                this.CustomPopupViewRequestDict.Add(menuItem.code, request);

                interactionRequestTrigger.SourceObject = this.CustomPopupViewRequestDict[menuItem.code];
                System.Windows.Interactivity.Interaction.GetTriggers(Application.Current.MainWindow).Add(interactionRequestTrigger);//这里必须把MainWindow设置未Application.cureent
                this._windowActions.Add(customPopupWindowAction);
            }
            PopWindowInfoEntity popWindowInfo = _container.Resolve<PopWindowInfoEntity>(menuItem.code);
            popWindowInfo.RegionName = menuItem.code + "Region";
            popWindowInfo.HomePath = menuItem.code;
            if (args == null)
                args = new Dictionary<string, object>();
            args.Add(ParameterNames.PopWindowInfo, popWindowInfo);

            this.CustomPopupViewRequestDict[menuItem.code].Raise(
              new Notification { Content = args, Title = menuItem.name }, (r) =>
              {

              });
            _eventAggregator.GetEvent<PopWindowActivateEvents>().Publish(menuItem.code + "Region");
        }
        #endregion

        private void StatusChangeExcute(Nullable<WindowChangeEnum> windowChangeEnum)
        {
            if (windowChangeEnum.HasValue)
            {
                this._eventAggregator.GetEvent<MainWinChangeEvent>().Publish(windowChangeEnum.Value);
            }
        }

        private void LoadedExcute()
        {

        }

        private void CloseWindow()
        {
            MessageBoxResult objMessageBoxResult = MessageDialog.ShowMsg("您确定要关闭系统吗？", "系统提示：", MessageBoxButton.YesNo);
            if (objMessageBoxResult != MessageBoxResult.Yes)
                return;
            System.GC.Collect();
            foreach (CustomPopupWindowAction windowAction in this._windowActions)
                windowAction.CloseWindow();
        }
    }
}
