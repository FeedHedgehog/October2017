using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October.Basic.Models
{
    public class PopWindowInfoEntity : BindableBase
    {
        private bool _isShowNavTool = true;
        private bool _isNext = false;
        private bool _isUp = false;
        private string _strHomePath = null;
        private bool _isLoading = false;
        private double _windowHegiht = 600;
        private double _windowWidth = 1024;

        public delegate void CustomHomeHandle();

        public CustomHomeHandle CustomHome;

        public string RegionName { get; set; }

        public string HomePath
        {
            get { return _strHomePath; }
            set { _strHomePath = value; }
        }

        public bool IsShowNavTool
        {
            get { return _isShowNavTool; }
            set { SetProperty(ref _isShowNavTool, value); }
        }

        public bool IsNext
        {
            get { return _isNext; }
            set { SetProperty(ref _isNext, value); }
        }

        public bool IsUp
        {

            get { return _isUp; }
            set { SetProperty(ref _isUp, value); }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private string loadPercent;
        public string LoadPercent
        {
            get { return loadPercent; }
            set { SetProperty(ref loadPercent, value); }
        }

        public double WindowHegiht
        {
            get { return _windowHegiht; }
            set { SetProperty(ref _windowHegiht, value); }
        }

        public double WindowWidth
        {
            get { return _windowWidth; }
            set { SetProperty(ref _windowWidth, value); }
        }
    }
}
