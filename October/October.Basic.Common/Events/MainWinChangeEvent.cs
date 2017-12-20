using October.Basic.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October.Basic.Common
{
    public class MainWinChangeEvent : PubSubEvent<WindowChangeEnum>
    {
    }
}
