using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace October.Component.Controls
{
    public enum ImagePlacement
    {
        Left,
        Top
    }



    public class ImageToggleButton : ToggleButton
    {
        static ImageToggleButton()
        {

            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageToggleButton), new FrameworkPropertyMetadata(typeof(ImageToggleButton)));
        }


        /// <summary>
        /// 设置初始显示图片，必填此属性
        /// </summary>
        public ImageSource NormalImage
        {
            get { return (ImageSource)GetValue(NormalImageProperty); }
            set { SetValue(NormalImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NormalImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NormalImageProperty =
            DependencyProperty.Register("NormalImage", typeof(ImageSource), typeof(ImageToggleButton), new PropertyMetadata(null));




        /// <summary>
        /// 设置鼠标悬停时的显示图片，默认为NormalImage
        /// </summary>
        public ImageSource HoverImage
        {
            get { return (ImageSource)GetValue(HoverImageProperty); }
            set { SetValue(HoverImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HoverImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HoverImageProperty =
            DependencyProperty.Register("HoverImage", typeof(ImageSource), typeof(ImageToggleButton), new PropertyMetadata(null));



        /// <summary>
        /// 设置鼠标按下但未松开时的显示图片，默认为HoverImage
        /// </summary>
        public ImageSource PressedImage
        {
            get { return (ImageSource)GetValue(PressedImageProperty); }
            set { SetValue(PressedImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PressedImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PressedImageProperty =
            DependencyProperty.Register("PressedImage", typeof(ImageSource), typeof(ImageToggleButton), new PropertyMetadata(null));



        /// <summary>
        /// 设置disable=true时的显示图片，默认切换到NormalImage
        /// </summary>
        public ImageSource DisableImage
        {
            get { return (ImageSource)GetValue(DisableImageProperty); }
            set { SetValue(DisableImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisableImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisableImageProperty =
            DependencyProperty.Register("DisableImage", typeof(ImageSource), typeof(ImageToggleButton), new PropertyMetadata(null));


        public object ImageCheckedContent
        {
            get { return (object)GetValue(ImageCheckedContentProperty); }
            set { SetValue(ImageCheckedContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageCheckedContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageCheckedContentProperty =
            DependencyProperty.Register("ImageCheckedContent", typeof(object), typeof(ImageToggleButton), new PropertyMetadata(null));


        /// <summary>
        /// 设置点击按钮后的显示图片，默认切换到NormalImage
        /// </summary>
        public ImageSource ToggleImage
        {
            get { return (ImageSource)GetValue(ToggleImageProperty); }
            set { SetValue(ToggleImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToggleImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToggleImageProperty =
            DependencyProperty.Register("ToggleImage", typeof(ImageSource), typeof(ImageToggleButton), new PropertyMetadata(null));



        /// <summary>
        /// 设置图片的宽度，不设置此属性则图片宽度为实际宽度
        /// </summary>
        public double ImageWidth
        {
            get { return (double)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageWidthProperty =
            DependencyProperty.Register("ImageWidth", typeof(double), typeof(ImageToggleButton), new PropertyMetadata(0.0));




        /// <summary>
        /// 设置图片的显示高度，不设置此属性则图片高度为实际高度
        /// </summary>
        public double ImageHeight
        {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register("ImageHeight", typeof(double), typeof(ImageToggleButton), new PropertyMetadata(0.0));



        /// <summary>
        /// 设置图片相对于内容（如果不为空）的位置，默认在内容上面
        /// </summary>
        public ImagePlacement ToggleImagePlacement
        {
            get { return (ImagePlacement)GetValue(ToggleImagePlacementProperty); }
            set { SetValue(ToggleImagePlacementProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToggleContentPlacement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToggleImagePlacementProperty =
            DependencyProperty.Register("ToggleImagePlacement", typeof(ImagePlacement), typeof(ImageToggleButton), new PropertyMetadata(ImagePlacement.Top));




        public ICommand ImageButtonClick
        {
            get { return (ICommand)GetValue(ImageButtonClickProperty); }
            set { SetValue(ImageButtonClickProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageButtonClick.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageButtonClickProperty =
            DependencyProperty.Register("ImageButtonClick", typeof(ICommand), typeof(ImageToggleButton), new PropertyMetadata(null));





        public ICommand ImageButtonChecked
        {
            get { return (ICommand)GetValue(ImageButtonCheckedProperty); }
            set { SetValue(ImageButtonCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageButtonChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageButtonCheckedProperty =
            DependencyProperty.Register("ImageButtonChecked", typeof(ICommand), typeof(ImageToggleButton), new PropertyMetadata(null));









        #region 透明度添加
        public double NormalOpacity
        {
            get { return (double)GetValue(NormalOpacityProperty); }
            set { SetValue(NormalOpacityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NormalOpacity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NormalOpacityProperty =
            DependencyProperty.Register("NormalOpacity", typeof(double), typeof(ImageToggleButton), new PropertyMetadata(0.7));




        public double HoverOpacity
        {
            get { return (double)GetValue(HoverOpacityProperty); }
            set { SetValue(HoverOpacityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HoverOpacity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HoverOpacityProperty =
            DependencyProperty.Register("HoverOpacity", typeof(double), typeof(ImageToggleButton), new PropertyMetadata(1.0));



        public double PressedOpacity
        {
            get { return (double)GetValue(PressedOpacityProperty); }
            set { SetValue(PressedOpacityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PressedOpacity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PressedOpacityProperty =
            DependencyProperty.Register("PressedOpacity", typeof(double), typeof(ImageToggleButton), new PropertyMetadata(0.4));



        public double ActiveOpacity
        {
            get { return (double)GetValue(ActiveOpacityProperty); }
            set { SetValue(ActiveOpacityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ActiveOpacity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActiveOpacityProperty =
            DependencyProperty.Register("ActiveOpacity", typeof(double), typeof(ImageToggleButton), new PropertyMetadata(1.0));
        #endregion

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.Checked += ImageToggleButton_Checked;
            this.Unchecked += ImageToggleButton_Unchecked;
            this.PreviewMouseLeftButtonUp += _grid_PreviewMouseLeftButtonUp;
        }

        private void ImageToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ICommand cmdCheked = this.GetValue(ImageButtonCheckedProperty) as ICommand;

            if (cmdCheked != null)
            {
                cmdCheked.Execute(this.IsChecked.GetValueOrDefault());

            }
        }

        private void ImageToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            ICommand cmdCheked = this.GetValue(ImageButtonCheckedProperty) as ICommand;

            if (cmdCheked != null)
            {
                cmdCheked.Execute(this.IsChecked.GetValueOrDefault());

            }
        }

        private void _grid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ICommand cmdClick = this.GetValue(ImageButtonClickProperty) as ICommand;

            FrameworkElement cur = sender as FrameworkElement;

            object param = (cur == null ? sender : cur.DataContext);

            if (cmdClick != null)
            {
                cmdClick.Execute(param);
            }


        }
    }
}
