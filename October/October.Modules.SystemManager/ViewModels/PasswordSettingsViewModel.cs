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

namespace October.Modules.SystemManager
{
    public class PasswordSettingsViewModel : BindableBase, INavigationPage
    {

        #region Fields
        private bool _canSubmit = true;
        //private UserEntity _userEntity;
        private string _oldpassword = string.Empty;
        private StateCodeEnum _optionStatus = StateCodeEnum.Default;
        private IRegionManager _regionManager;
        private IUnityContainer _unityContainer;
        private IEventAggregator _eventAggregator;
        //private IUserManage _userService;
        #endregion

        #region Command
        public DelegateCommand<string> SubmitCommand { get; private set; }
        public DelegateCommand SuccessStoryboardCompleted { get; private set; }
        #endregion

        #region 属性
        //public UserEntity UsersEntity
        //{
        //    get
        //    {
        //        return _userEntity;
        //    }
        //    set
        //    {
        //        this.SetProperty(ref _userEntity, value);
        //        RaisePropertyChanged("UsersEntity");
        //    }
        //}


        public string OldPassword
        {
            get { return _oldpassword; }
            set
            {
                SetProperty(ref _oldpassword, value);
            }
        }

        private string _strTilte = "修改密码";
        public string Tilte
        {
            get { return _strTilte; }
            set
            {
                SetProperty(ref _strTilte, value);
            }
        }

        /// <summary>
        /// -1 默认；0：错误；正确
        /// </summary>
        public StateCodeEnum OptionStatus
        {
            get { return _optionStatus; }
            set { SetProperty(ref _optionStatus, value); }
        }
        #endregion 属性

        public PasswordSettingsViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IUnityContainer container)
        {
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
            _unityContainer = container;
            //_userService = _unityContainer.Resolve<IUserManage>();

            this.SubmitCommand = new DelegateCommand<string>(Submit, (a) => { return _canSubmit; });
            this.SuccessStoryboardCompleted = new DelegateCommand(SuccessCompleted);
        }

        #region INavigationPage
        public IRegionNavigationJournal Journal { get; set; }

        public PopupPageStatusEnum PageStatus { get; set; }

        public PopWindowInfoEntity PopWindowInfo { get; set; }

        public FrameworkElement CreateCustomControl()
        {
            return null;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //this.PopWindowInfo = navigationContext.Parameters[ParameterNames.PopWindowInfo] as PopWindowInfoEntity;
            //QueryData(GlobalConfig.CurrentUser.userId);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
        #endregion

        #region Private Method

        private void SuccessCompleted()
        {
            _eventAggregator.GetEvent<PopWindowCloseEvents>().Publish(this.PopWindowInfo.RegionName);
        }

        private void Submit(string args)
        {
            //if (!string.IsNullOrEmpty(this.UsersEntity.Error))
            //{
            //    this.OptionStatus = StateCodeEnum.Fail;
            //    return;
            //}
            //this._canSubmit = false;
            //_userService.ResetUsersPassword(this.UsersEntity, OldPassword, args, (result) =>
            //{
            //    this.OptionStatus = result.state.code;
            //    this.UsersEntity.Error = result.state.msg;
            //    RaisePropertyChanged("UsersEntity");
            //    this._canSubmit = true;
            //});
        }

        private void QueryData(long id)
        {

            //this.PopWindowInfo.IsLoading = true;
            //_userService.FindUsersDetailById(id, (result) =>
            //{
            //    this.PopWindowInfo.IsLoading = false;
            //    if (result.state.code != StateCodeEnum.Success)
            //    {
            //        return;
            //    }
            //    result.user.roleList = new System.Collections.ObjectModel.ObservableCollection<RoleEntity>(result.roles);
            //    result.user.UIType = 3;
            //    this.UsersEntity = result.user;
            //});
        }

        #endregion
    }
}
