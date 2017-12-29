using October.Basic.Models;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace October.Basic.Contracts
{
    /// <summary>
    ///Name:INavigationPage
    ///Editor:Jason    
    ///Modifier:
    ///ModificationTime:
    ///Content:导航窗体公用接口
    /// </summary>
    public interface INavigationPage : INavigationAware
    {
        /// <summary>
        /// 导航信息
        /// </summary>
        IRegionNavigationJournal Journal { get; set; }

        /// <summary>
        /// 弹出窗体的状态
        /// </summary>
        PopupPageStatusEnum PageStatus { get; set; }

        /// <summary>
        /// 弹出窗体信息
        /// </summary>
        PopWindowInfoEntity PopWindowInfo { get; set; }

        /// <summary>
        /// 创建自定义工具
        /// </summary>
        FrameworkElement CreateCustomControl();
    }
}
