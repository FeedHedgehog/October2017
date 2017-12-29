using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October.Basic.Common
{
    /// <summary>
    ///Name:PopWindowActivateEvents
    ///Editor:Jason    
    ///Modifier:
    ///ModificationTime:
    ///Content:弹出窗体激活通知事件
    /// </summary>
    public class PopWindowActivateEvents : PubSubEvent<string>
    {

    }

    /// <summary>
    ///Name:PopWindowActivateEvents
    ///Editor:Jason    
    ///Modifier:
    ///ModificationTime:
    ///Content:弹出窗体激活通知事件
    /// </summary>
    public class PopWindowCloseEvents : PubSubEvent<string>
    {

    }

    /// <summary>
    ///Name:PopWindowActivateEvents
    ///Editor:Jason    
    ///Modifier:
    ///ModificationTime:
    ///Content:自定义窗体弹出通知事件
    /// </summary>
    public class CustomPopWindowShowEvents : PubSubEvent<Dictionary<string, object>>
    {
    }
}
