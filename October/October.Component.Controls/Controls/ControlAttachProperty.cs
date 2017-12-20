using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace October.Component.Controls
{
    public static class ControlAttachProperty
    {
        /************************************ Attach Property **************************************/
        #region WatermarkProperty 水印
        /// <summary>
        /// 水印
        /// </summary>
        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached(
            "Watermark", typeof(string), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(""));

        public static string GetWatermark(DependencyObject d)
        {
            return (string)d.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }
        #endregion

        #region AllowsAnimationProperty 启用旋转动画
        /// <summary>
        /// 启用旋转动画
        /// </summary>
        public static readonly DependencyProperty AllowsAnimationProperty = DependencyProperty.RegisterAttached("AllowsAnimation"
            , typeof(bool), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(false, AllowsAnimationChanged));

        public static bool GetAllowsAnimation(DependencyObject d)
        {
            return (bool)d.GetValue(AllowsAnimationProperty);
        }

        public static void SetAllowsAnimation(DependencyObject obj, bool value)
        {
            obj.SetValue(AllowsAnimationProperty, value);
        }

        /// <summary>
        /// 旋转动画刻度
        /// </summary>
        private static DoubleAnimation RotateAnimation = new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(200)));

        /// <summary>
        /// 绑定动画事件
        /// </summary>
        private static void AllowsAnimationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uc = d as FrameworkElement;
            if (uc == null) return;
            if (uc.RenderTransformOrigin == new Point(0, 0))
            {
                uc.RenderTransformOrigin = new Point(0.5, 0.5);
                RotateTransform trans = new RotateTransform(0);
                uc.RenderTransform = trans;
            }
            var value = (bool)e.NewValue;
            if (value)
            {
                RotateAnimation.To = 180;
                uc.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, RotateAnimation);
            }
            else
            {
                RotateAnimation.To = 0;
                uc.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, RotateAnimation);
            }
        }
        #endregion

        #region CornerRadiusProperty Border圆角
        /// <summary>
        /// Border圆角
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached(
            "CornerRadius", typeof(CornerRadius), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(null));

        public static CornerRadius GetCornerRadius(DependencyObject d)
        {
            return (CornerRadius)d.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }
        #endregion

        #region LabelProperty TextBox的头部Label
        /// <summary>
        /// TextBox的头部Label
        /// </summary>
        public static readonly DependencyProperty LabelProperty = DependencyProperty.RegisterAttached(
            "Label", typeof(string), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(null));

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static string GetLabel(DependencyObject d)
        {
            return (string)d.GetValue(LabelProperty);
        }

        public static void SetLabel(DependencyObject obj, string value)
        {
            obj.SetValue(LabelProperty, value);
        }
        #endregion

        #region LabelTemplateProperty TextBox的头部Label模板
        /// <summary>
        /// TextBox的头部Label模板
        /// </summary>
        public static readonly DependencyProperty LabelTemplateProperty = DependencyProperty.RegisterAttached(
            "LabelTemplate", typeof(ControlTemplate), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(null));

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static ControlTemplate GetLabelTemplate(DependencyObject d)
        {
            return (ControlTemplate)d.GetValue(LabelTemplateProperty);
        }

        public static void SetLabelTemplate(DependencyObject obj, ControlTemplate value)
        {
            obj.SetValue(LabelTemplateProperty, value);
        }
        #endregion

        #region PageIndexIsCheckedProperty 分页按钮选择属性
        /// <summary>
        /// TextBox的头部Label模板
        /// </summary>
        public static readonly DependencyProperty PageIndexIsCheckedProperty = DependencyProperty.RegisterAttached(
            "PageIndexIsChecked", typeof(bool), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(false));

        public static bool GetPageIndexIsChecked(DependencyObject d)
        {
            return (bool)d.GetValue(PageIndexIsCheckedProperty);
        }

        public static void SetPageIndexIsChecked(DependencyObject obj, bool value)
        {
            obj.SetValue(PageIndexIsCheckedProperty, value);
        }
        #endregion

        #region ImgBtnNormalSource ImgBtn的图片资源
        /// <summary>
        /// TextBox的头部Label模板
        /// </summary>
        public static readonly DependencyProperty ImgBtnNormalSourceProperty = DependencyProperty.RegisterAttached(
            "ImgBtnNormalSource", typeof(ImageSource), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(null));

        public static ImageSource GetImgBtnNormalSource(DependencyObject d)
        {
            return (ImageSource)d.GetValue(ImgBtnNormalSourceProperty);
        }

        public static void SetImgBtnNormalSource(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(ImgBtnNormalSourceProperty, value);
        }
        #endregion

        #region ImgBtnCheckedSource ImgBtn的图片资源
        /// <summary>
        /// TextBox的头部Label模板
        /// </summary>
        public static readonly DependencyProperty ImgBtnCheckedSourceProperty = DependencyProperty.RegisterAttached(
            "ImgBtnCheckedSource", typeof(ImageSource), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(null));

        public static ImageSource GetImgBtnCheckedSource(DependencyObject d)
        {
            return (ImageSource)d.GetValue(ImgBtnCheckedSourceProperty);
        }

        public static void SetImgBtnCheckedSource(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(ImgBtnCheckedSourceProperty, value);
        }
        #endregion

        #region ImgUrlProperty 图片的Url地址
        /// <summary>
        /// 图片的Url地址
        /// </summary>
        public static readonly DependencyProperty ImgUrlProperty = DependencyProperty.RegisterAttached(
            "ImgUrl", typeof(ImageSource), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(null));

        public static ImageSource GetImgUrl(DependencyObject d)
        {
            return (ImageSource)d.GetValue(ImgUrlProperty);
        }

        public static void SetImgUrl(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(ImgUrlProperty, value);
        }
        #endregion

        #region IsExpanded 是否扩展属性
        /// <summary>
        /// 图片的Url地址
        /// </summary>
        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.RegisterAttached(
            "IsExpanded", typeof(bool), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(false));

        public static bool GetIsExpanded(DependencyObject d)
        {
            return (bool)d.GetValue(IsExpandedProperty);
        }

        public static void SetIsExpanded(DependencyObject obj, bool value)
        {
            obj.SetValue(IsExpandedProperty, value);
        }
        #endregion

        #region ShowItemData 是否扩展属性
        /// <summary>
        /// 图片的Url地址
        /// </summary>
        public static readonly DependencyProperty ShowItemDataProperty = DependencyProperty.RegisterAttached(
            "ShowItemData", typeof(object), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(null));

        public static object GetShowItemData(DependencyObject d)
        {
            return (object)d.GetValue(ShowItemDataProperty);
        }

        public static void SetShowItemData(DependencyObject obj, object value)
        {
            obj.SetValue(ShowItemDataProperty, value);
        }
        #endregion

        #region CustomContent 是否扩展属性
        /// <summary>
        /// 图片的Url地址
        /// </summary>
        public static readonly DependencyProperty CustomContentProperty = DependencyProperty.RegisterAttached(
            "CustomContent", typeof(FrameworkElement), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(null));

        public static object GetCustomContent(DependencyObject d)
        {
            return (object)d.GetValue(CustomContentProperty);
        }

        public static void SetCustomContent(DependencyObject obj, FrameworkElement value)
        {
            obj.SetValue(CustomContentProperty, value);
        }
        #endregion

        #region HasInfos 是否有数据属性
        /// <summary>
        /// 图片的Url地址
        /// </summary>
        public static readonly DependencyProperty HasInfosProperty = DependencyProperty.RegisterAttached(
            "HasInfos", typeof(bool), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(false));

        public static bool GetHasInfos(DependencyObject d)
        {
            return (bool)d.GetValue(HasInfosProperty);
        }

        public static void SetHasInfos(DependencyObject obj, bool value)
        {
            obj.SetValue(HasInfosProperty, value);
        }
        #endregion

        #region ImgWidth 图片的宽度
        /// <summary>
        /// 图片的Url地址
        /// </summary>
        public static readonly DependencyProperty ImgWidthProperty = DependencyProperty.RegisterAttached(
            "ImgWidth", typeof(double), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(0.0));

        public static double GetImgWidth(DependencyObject d)
        {
            return (double)d.GetValue(ImgWidthProperty);
        }

        public static void SetImgWidth(DependencyObject obj, double value)
        {
            obj.SetValue(ImgWidthProperty, value);
        }
        #endregion

        #region ImgHeight 图片的高度
        /// <summary>
        /// 图片的Url地址
        /// </summary>
        public static readonly DependencyProperty ImgHeightProperty = DependencyProperty.RegisterAttached(
            "ImgHeight", typeof(double), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(0.0));

        public static double GetImgHeight(DependencyObject d)
        {
            return (double)d.GetValue(ImgHeightProperty);
        }

        public static void SetImgHeight(DependencyObject obj, double value)
        {
            obj.SetValue(ImgHeightProperty, value);
        }
        #endregion

        #region Text 
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty TextProperty = DependencyProperty.RegisterAttached(
            "Text", typeof(string), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(""));

        public static object GetText(DependencyObject d)
        {
            return d.GetValue(TextProperty);
        }

        public static void SetText(DependencyObject obj, object value)
        {
            obj.SetValue(TextProperty, value);
        }
        #endregion

        #region Unit 
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty UnitProperty = DependencyProperty.RegisterAttached(
            "Unit", typeof(string), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(""));

        public static object GetUnit(DependencyObject d)
        {
            return d.GetValue(UnitProperty);
        }

        public static void SetUnit(DependencyObject obj, string value)
        {
            obj.SetValue(UnitProperty, value);
        }
        #endregion

        #region Year 
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty YearProperty = DependencyProperty.RegisterAttached(
            "Year", typeof(string), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(DateTime.Now.Year.ToString()));

        public static string GetYear(DependencyObject d)
        {
            return (string)d.GetValue(YearProperty);
        }

        public static void SetYear(DependencyObject obj, string value)
        {
            obj.SetValue(YearProperty, value);
        }
        #endregion

        #region Month 
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty MonthProperty = DependencyProperty.RegisterAttached(
            "Month", typeof(string), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(DateTime.Now.Month.ToString() + "月"));

        public static string GetMonth(DependencyObject d)
        {
            return (string)d.GetValue(MonthProperty);
        }

        public static void SetMonth(DependencyObject obj, string value)
        {
            obj.SetValue(MonthProperty, value);
        }
        #endregion

        /************************************ RoutedUICommand Behavior enable **************************************/
        #region Storyboard CompletedCommand  动画结束命令
        public static readonly DependencyProperty CompletedCommandProperty = DependencyProperty.RegisterAttached("CompletedCommand", typeof(ICommand), typeof(ControlAttachProperty), new PropertyMetadata(null, OnCompletedCommandChanged));
        public static readonly DependencyProperty CompletedCommandParameterProperty = DependencyProperty.RegisterAttached("CompletedCommandParameter", typeof(object), typeof(ControlAttachProperty), new PropertyMetadata(null));

        public static void SetCompletedCommand(DependencyObject o, ICommand value)
        {
            o.SetValue(CompletedCommandProperty, value);
        }

        public static ICommand GetCompletedCommand(DependencyObject o)
        {
            return (ICommand)o.GetValue(CompletedCommandProperty);
        }

        public static void SetCompletedCommandParameter(DependencyObject o, object value)
        {
            o.SetValue(CompletedCommandParameterProperty, value);
        }

        public static object GetCompletedCommandParameter(DependencyObject o)
        {
            return o.GetValue(CompletedCommandParameterProperty);
        }

        private static void OnCompletedCommandChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var sb = sender as Storyboard;

            if (sb != null)
            {
                sb.Completed += (a, b) =>
                {
                    var command = GetCompletedCommand(sb);

                    if (command != null)
                    {
                        if (command.CanExecute(GetCompletedCommandParameter(sb)))
                        {
                            command.Execute(GetCompletedCommandParameter(sb));
                        }
                    }
                };
            }
        }
        #endregion

        #region IsClearTextButtonBehaviorEnabledProperty 清除输入框Text值按钮行为开关（设为ture时才会绑定事件）
        /// <summary>
        /// 清除输入框Text值按钮行为开关
        /// </summary>
        public static readonly DependencyProperty IsClearTextButtonBehaviorEnabledProperty = DependencyProperty.RegisterAttached("IsClearTextButtonBehaviorEnabled"
            , typeof(bool), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(false, IsClearTextButtonBehaviorEnabledChanged));

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetIsClearTextButtonBehaviorEnabled(DependencyObject d)
        {
            return (bool)d.GetValue(IsClearTextButtonBehaviorEnabledProperty);
        }

        public static void SetIsClearTextButtonBehaviorEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsClearTextButtonBehaviorEnabledProperty, value);
        }

        /// <summary>
        /// 绑定清除Text操作的按钮事件
        /// </summary>
        private static void IsClearTextButtonBehaviorEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //var button = d as FButton;
            //if (e.OldValue != e.NewValue && button != null)
            //{
            //    button.CommandBindings.Add(ClearTextCommandBinding);
            //}
        }

        #endregion

        #region IsOpenFileButtonBehaviorEnabledProperty 选择文件命令行为开关
        /// <summary>
        /// 选择文件命令行为开关
        /// </summary>
        public static readonly DependencyProperty IsOpenFileButtonBehaviorEnabledProperty = DependencyProperty.RegisterAttached("IsOpenFileButtonBehaviorEnabled"
            , typeof(bool), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(false, IsOpenFileButtonBehaviorEnabledChanged));

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetIsOpenFileButtonBehaviorEnabled(DependencyObject d)
        {
            return (bool)d.GetValue(IsOpenFileButtonBehaviorEnabledProperty);
        }

        public static void SetIsOpenFileButtonBehaviorEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsOpenFileButtonBehaviorEnabledProperty, value);
        }

        private static void IsOpenFileButtonBehaviorEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //var button = d as FButton;
            //if (e.OldValue != e.NewValue && button != null)
            //{
            //    button.CommandBindings.Add(OpenFileCommandBinding);
            //}
        }

        #endregion

        #region IsOpenFolderButtonBehaviorEnabledProperty 选择文件夹命令行为开关
        /// <summary>
        /// 选择文件夹命令行为开关
        /// </summary>
        public static readonly DependencyProperty IsOpenFolderButtonBehaviorEnabledProperty = DependencyProperty.RegisterAttached("IsOpenFolderButtonBehaviorEnabled"
            , typeof(bool), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(false, IsOpenFolderButtonBehaviorEnabledChanged));

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetIsOpenFolderButtonBehaviorEnabled(DependencyObject d)
        {
            return (bool)d.GetValue(IsOpenFolderButtonBehaviorEnabledProperty);
        }

        public static void SetIsOpenFolderButtonBehaviorEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsOpenFolderButtonBehaviorEnabledProperty, value);
        }

        private static void IsOpenFolderButtonBehaviorEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //var button = d as FButton;
            //if (e.OldValue != e.NewValue && button != null)
            //{
            //    button.CommandBindings.Add(OpenFolderCommandBinding);
            //}
        }

        #endregion

        #region IsSaveFileButtonBehaviorEnabledProperty 选择文件保存路径及名称
        /// <summary>
        /// 选择文件保存路径及名称
        /// </summary>
        public static readonly DependencyProperty IsSaveFileButtonBehaviorEnabledProperty = DependencyProperty.RegisterAttached("IsSaveFileButtonBehaviorEnabled"
            , typeof(bool), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(false, IsSaveFileButtonBehaviorEnabledChanged));

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetIsSaveFileButtonBehaviorEnabled(DependencyObject d)
        {
            return (bool)d.GetValue(IsSaveFileButtonBehaviorEnabledProperty);
        }

        public static void SetIsSaveFileButtonBehaviorEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSaveFileButtonBehaviorEnabledProperty, value);
        }

        private static void IsSaveFileButtonBehaviorEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //var button = d as FButton;
            //if (e.OldValue != e.NewValue && button != null)
            //{
            //    button.CommandBindings.Add(SaveFileCommandBinding);
            //}
        }

        #endregion

        /************************************ attach behavior **************************************/
        #region CommandAttachParam
        public static object GetCommandAttachParam(DependencyObject obj)
        {
            return (object)obj.GetValue(CommandAttachParamProperty);
        }

        public static void SetCommandAttachParam(DependencyObject obj, object value)
        {
            obj.SetValue(CommandAttachParamProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandAttachParamProperty =
            DependencyProperty.RegisterAttached("CommandAttachParam", typeof(object), typeof(ControlAttachProperty), new PropertyMetadata(null));

        #endregion

        #region ControlLeftButtonUp and MouseDoubleClick
        public static ICommand GetControlLeftButtonUp(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ControlLeftButtonUpProperty);
        }

        public static void SetControlLeftButtonUp(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ControlLeftButtonUpProperty, value);
        }



        public static ICommand GetMouseDoubleClick(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(MouseDoubleClickProperty);
        }

        public static void SetMouseDoubleClick(DependencyObject obj, ICommand value)
        {
            obj.SetValue(MouseDoubleClickProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyPropertyMouseDoubleClick.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MouseDoubleClickProperty =
            DependencyProperty.RegisterAttached("MouseDoubleClick", typeof(ICommand), typeof(ControlAttachProperty), new PropertyMetadata(null, OnMouseDoubleClickPropertyChangedCallback));

        private static void OnMouseDoubleClickPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Control element = d as Control;
            if (element == null)
                return;


            if (e.NewValue != null && e.NewValue != e.OldValue)
            {
                element.MouseDoubleClick += Element_MouseDoubleClick; ;
            }
            else
            {
                element.PreviewMouseLeftButtonUp -= Element_MouseDoubleClick;
            }

        }

        private static void Element_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UIElement element = sender as UIElement;
            if (element == null)
                return;
            ICommand cmd = ControlAttachProperty.GetMouseDoubleClick(element);
            object param = ControlAttachProperty.GetCommandAttachParam(element);
            cmd.Execute(param);
        }





        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ControlLeftButtonUpProperty =
            DependencyProperty.RegisterAttached("ControlLeftButtonUp", typeof(ICommand), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(null, OnLeftButtonUpPropertyChangedCallback));

        private static void OnLeftButtonUpPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;

            if (element == null)
                return;


            if (e.NewValue != null && e.NewValue != e.OldValue)
            {
                element.PreviewMouseLeftButtonUp += Element_PreviewMouseLeftButtonUp;
            }
            else
            {
                element.PreviewMouseLeftButtonUp -= Element_PreviewMouseLeftButtonUp;
            }

        }

        private static void Element_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UIElement element = sender as UIElement;
            if (element == null)
                return;
            ICommand cmd = ControlAttachProperty.GetControlLeftButtonUp(element);
            object param = ControlAttachProperty.GetCommandAttachParam(element);
            cmd.Execute(param);
        }

        #endregion

        #region TreeViewSelectionChanged
        public static ICommand GetTreeViewSelectionChanged(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(TreeViewSelectionChangedProperty);
        }

        public static void SetTreeViewSelectionChanged(DependencyObject obj, ICommand value)
        {
            obj.SetValue(TreeViewSelectionChangedProperty, value);
        }

        // Using a DependencyProperty as the backing store for TreeViewSelectionChanged.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TreeViewSelectionChangedProperty =
            DependencyProperty.RegisterAttached("TreeViewSelectionChanged", typeof(ICommand), typeof(ControlAttachProperty), new PropertyMetadata(null, TreeViewSelectionPropertyChangedCallback));

        private static void TreeViewSelectionPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            TreeView element = d as TreeView;

            if (element == null)
                return;


            if (e.NewValue != null && e.NewValue != e.OldValue)
            {
                element.SelectedItemChanged += Element_SelectedItemChanged; ;
            }
            else
            {
                element.PreviewMouseLeftButtonUp -= Element_PreviewMouseLeftButtonUp;
            }

        }

        private static void Element_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView element = sender as TreeView;
            if (element == null)
                return;
            ICommand cmd = ControlAttachProperty.GetTreeViewSelectionChanged(element);
            object param = element.SelectedItem;
            cmd.Execute(param);
        }

        #endregion

        #region ListSelectionChanged
        public static ICommand GetListSelectionChanged(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ListSelectionChangedProperty);
        }

        public static void SetListSelectionChanged(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ListSelectionChangedProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListSelectionChangedProperty =
            DependencyProperty.RegisterAttached("ListSelectionChanged", typeof(ICommand), typeof(ControlAttachProperty), new PropertyMetadata(null, ListSelectionChangedPropertyChangedCallback));


        private static void ListSelectionChangedPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            Selector element = d as Selector;

            if (element == null)
                return;


            if (e.NewValue != null && e.NewValue != e.OldValue)
            {
                element.SelectionChanged += Element_SelectionChanged;
            }
            else
            {
                element.SelectionChanged -= Element_SelectionChanged;
            }

        }

        private static void Element_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Selector element = sender as Selector;
            if (element == null)
                return;
            ICommand cmd = ControlAttachProperty.GetListSelectionChanged(element);
            object param = element.SelectedItem;
            cmd.Execute(param);
        }
        #endregion

        #region LostFocus 
        public static ICommand GetLostFocus(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(LostFocusProperty);
        }

        public static void SetLostFocus(DependencyObject obj, ICommand value)
        {
            obj.SetValue(LostFocusProperty, value);
        }


        public static readonly DependencyProperty LostFocusProperty =
            DependencyProperty.RegisterAttached("LostFocus", typeof(ICommand), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(null, OnLostFocusCallback));

        private static void OnLostFocusCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBox element = d as TextBox;

            if (element == null)
                return;
            if (e.NewValue != null && e.NewValue != e.OldValue)
            {
                element.LostFocus += Element_LostFocus;
            }
            else
            {
                element.LostFocus -= Element_LostFocus;
            }

        }

        private static void Element_LostFocus(object sender, RoutedEventArgs e)
        {
            UIElement element = sender as UIElement;
            if (element == null)
                return;
            ICommand cmd = ControlAttachProperty.GetLostFocus(element);
            object param = ControlAttachProperty.GetCommandAttachParam(element);
            cmd.Execute(param);
        }

        //private static void Element_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    UIElement element = sender as UIElement;
        //    if (element == null)
        //        return;
        //    ICommand cmd = ControlAttachProperty.GetTextChanged(element);
        //    object param = ControlAttachProperty.GetCommandAttachParam(element);
        //    cmd.Execute(param);
        //}
        #endregion

        #region  CustomCommand
        public static readonly DependencyProperty CustomCommandProperty = DependencyProperty.RegisterAttached(
            "CustomCommand", typeof(ICommand), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(null));

        public static ICommand GetCustomCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(CustomCommandProperty);
        }

        public static void SetCustomCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CustomCommandProperty, value);
        }
        #endregion

        #region DragOver
        public static ICommand GetDragOver(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ControlLeftButtonUpProperty);
        }

        public static void SetDragOver(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ControlLeftButtonUpProperty, value);
        }


        public static readonly DependencyProperty DragOverProperty =
           DependencyProperty.RegisterAttached("DragOver", typeof(ICommand), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(null, OnDragOverPropertyChangedCallback));

        private static void OnDragOverPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;

            if (element == null)
                return;


            if (e.NewValue != null && e.NewValue != e.OldValue)
            {
                element.DragOver += Element_DragOver;
            }
            else
            {
                element.DragOver -= Element_DragOver;
            }

        }

        private static void Element_DragOver(object sender, DragEventArgs e)
        {
            UIElement element = sender as UIElement;
            if (element == null)
                return;
            ICommand cmd = ControlAttachProperty.GetDragOver(element);
            List<object> param = new List<object>();
            param.Add("DragOver");
            param.Add(e);
            cmd.Execute(param);
        }
        #endregion

        #region Drag
        public static ICommand GetDrag(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ControlLeftButtonUpProperty);
        }

        public static void SetDrag(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ControlLeftButtonUpProperty, value);
        }


        public static readonly DependencyProperty DragProperty =
           DependencyProperty.RegisterAttached("Drag", typeof(ICommand), typeof(ControlAttachProperty), new FrameworkPropertyMetadata(null, OnDragPropertyChangedCallback));

        private static void OnDragPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;

            if (element == null)
                return;


            if (e.NewValue != null && e.NewValue != e.OldValue)
            {
                element.Drop += Element_Drag;
            }
            else
            {
                element.Drop -= Element_Drag;
            }

        }

        private static void Element_Drag(object sender, DragEventArgs e)
        {
            UIElement element = sender as UIElement;
            if (element == null)
                return;
            ICommand cmd = ControlAttachProperty.GetDrag(element);
            List<object> param = new List<object>();
            param.Add("Drag");
            param.Add(e);
            cmd.Execute(param);
        }
        #endregion
        /************************************ RoutedUICommand **************************************/

        #region ClearTextCommand 清除输入框Text事件命令

        /// <summary>
        /// 清除输入框Text事件命令，需要使用IsClearTextButtonBehaviorEnabledChanged绑定命令
        /// </summary>
        public static RoutedUICommand ClearTextCommand { get; private set; }

        /// <summary>
        /// ClearTextCommand绑定事件
        /// </summary>
        private static readonly CommandBinding ClearTextCommandBinding;

        /// <summary>
        /// 清除输入框文本值
        /// </summary>
        private static void ClearButtonClick(object sender, ExecutedRoutedEventArgs e)
        {
            var tbox = e.Parameter as FrameworkElement;
            if (tbox == null) return;
            if (tbox is TextBox)
            {
                ((TextBox)tbox).Clear();
            }
            if (tbox is PasswordBox)
            {
                ((PasswordBox)tbox).Clear();
            }
            if (tbox is ComboBox)
            {
                var cb = tbox as ComboBox;
                cb.SelectedItem = null;
                cb.Text = string.Empty;
            }
            //if (tbox is MultiComboBox)
            //{
            //    var cb = tbox as MultiComboBox;
            //    cb.SelectedItem = null;
            //    cb.UnselectAll();
            //    cb.Text = string.Empty;
            //}
            if (tbox is DatePicker)
            {
                var dp = tbox as DatePicker;
                dp.SelectedDate = null;
                dp.Text = string.Empty;
            }
            tbox.Focus();
        }

        #endregion

        #region OpenFileCommand 选择文件命令

        /// <summary>
        /// 选择文件命令，需要使用IsClearTextButtonBehaviorEnabledChanged绑定命令
        /// </summary>
        public static RoutedUICommand OpenFileCommand { get; private set; }

        /// <summary>
        /// OpenFileCommand绑定事件
        /// </summary>
        private static readonly CommandBinding OpenFileCommandBinding;

        /// <summary>
        /// 执行OpenFileCommand
        /// </summary>
        private static void OpenFileButtonClick(object sender, ExecutedRoutedEventArgs e)
        {
            var tbox = e.Parameter as FrameworkElement;
            var txt = tbox as TextBox;
            string filter = txt.Tag == null ? "所有文件(*.*)|*.*" : txt.Tag.ToString();
            if (filter.Contains(".bin"))
            {
                filter += "|所有文件(*.*)|*.*";
            }
            if (txt == null) return;
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "请选择文件";
            //“图像文件(*.bmp, *.jpg)|*.bmp;*.jpg|所有文件(*.*)|*.*”
            fd.Filter = filter;
            fd.FileName = txt.Text.Trim();
            if (fd.ShowDialog() == true)
            {
                txt.Text = fd.FileName;
            }
            tbox.Focus();
        }

        #endregion

        #region OpenFolderCommand 选择文件夹命令

        /// <summary>
        /// 选择文件夹命令
        /// </summary>
        public static RoutedUICommand OpenFolderCommand { get; private set; }

        /// <summary>
        /// OpenFolderCommand绑定事件
        /// </summary>
        private static readonly CommandBinding OpenFolderCommandBinding;

        /// <summary>
        /// 执行OpenFolderCommand
        /// </summary>
        private static void OpenFolderButtonClick(object sender, ExecutedRoutedEventArgs e)
        {
            //var tbox = e.Parameter as FrameworkElement;
            //var txt = tbox as TextBox;
            //if (txt == null) return;
            //FolderBrowserDialog fd = new FolderBrowserDialog();
            //fd.Description = "请选择文件路径";
            //fd.SelectedPath = txt.Text.Trim();
            //if (fd.ShowDialog() == DialogResult.OK)
            //{
            //    txt.Text = fd.SelectedPath;
            //}
            //tbox.Focus();
        }

        #endregion

        #region SaveFileCommand 选择文件保存路径及名称

        /// <summary>
        /// 选择文件保存路径及名称
        /// </summary>
        public static RoutedUICommand SaveFileCommand { get; private set; }

        /// <summary>
        /// SaveFileCommand绑定事件
        /// </summary>
        private static readonly CommandBinding SaveFileCommandBinding;

        /// <summary>
        /// 执行OpenFileCommand
        /// </summary>
        private static void SaveFileButtonClick(object sender, ExecutedRoutedEventArgs e)
        {
            //var tbox = e.Parameter as FrameworkElement;
            //var txt = tbox as TextBox;
            //if (txt == null) return;
            //SaveFileDialog fd = new SaveFileDialog();
            //fd.Title = "文件保存路径";
            //fd.Filter = "所有文件(*.*)|*.*";
            //fd.FileName = txt.Text.Trim();
            //if (fd.ShowDialog() == DialogResult.OK)
            //{
            //    txt.Text = fd.FileName;
            //}
            //tbox.Focus();
        }

        #endregion


        /// <summary>
        /// 静态构造函数
        /// </summary>
        static ControlAttachProperty()
        {
            //ClearTextCommand
            ClearTextCommand = new RoutedUICommand();
            ClearTextCommandBinding = new CommandBinding(ClearTextCommand);
            ClearTextCommandBinding.Executed += ClearButtonClick;
            //OpenFileCommand
            OpenFileCommand = new RoutedUICommand();
            OpenFileCommandBinding = new CommandBinding(OpenFileCommand);
            OpenFileCommandBinding.Executed += OpenFileButtonClick;
            //OpenFolderCommand
            OpenFolderCommand = new RoutedUICommand();
            OpenFolderCommandBinding = new CommandBinding(OpenFolderCommand);
            OpenFolderCommandBinding.Executed += OpenFolderButtonClick;

            SaveFileCommand = new RoutedUICommand();
            SaveFileCommandBinding = new CommandBinding(SaveFileCommand);
            SaveFileCommandBinding.Executed += SaveFileButtonClick;
        }
    }
}
