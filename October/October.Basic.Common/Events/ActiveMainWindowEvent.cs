using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October.Basic.Common
{
    /// <summary>
    /// 激活主窗口，参数指示是否禁用主窗体操作,null:仅激活主窗体，true:激活主窗体并禁用主窗体，false：取消禁用主窗体
    /// </summary>
    public class ActiveMainWindowEvent : PubSubEvent<bool?>
    {
    }

    public class AxRenderWindowCloseEvent : PubSubEvent
    {

    }
}
