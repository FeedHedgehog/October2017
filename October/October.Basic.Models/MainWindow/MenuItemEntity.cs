using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October.Basic.Models
{
    public class MenuItemEntity : BindableBase
    {

        public Action<double> OnUpdateHeight;
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 安全管理
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int parentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string menuUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string menuActive { get; set; }
        private List<MenuItemEntity> _children;
        /// <summary>
        /// 
        /// </summary>
        public List<MenuItemEntity> children
        {
            get
            {
                if (_children == null)
                {
                    _children = new List<MenuItemEntity>();
                }
                return _children;
            }
            set
            {
                _children = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string iconClass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int sort { get; set; }

        public void SetUpdateNotify(Action<double> updateAction)
        {
            OnUpdateHeight = updateAction;
        }

        private bool isSubItemOpen;
        public bool IsSubItemOpen
        {
            set
            {
                SetProperty(ref isSubItemOpen, value);
                if (OnUpdateHeight == null)
                    return;
                if (value)
                {
                    OnUpdateHeight(children.Count * 48 + 60.0);
                }
                else
                {
                    OnUpdateHeight(0f);
                }
            }
            get { return isSubItemOpen; }
        }
    }

    public class MenuEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public List<MenuItemEntity> menus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public StateEntity state { get; set; }
    }
}
