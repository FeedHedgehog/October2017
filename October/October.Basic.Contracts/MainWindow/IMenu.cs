using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October.Basic.Contracts
{
    public interface IMenu
    {
        void GetMenu<T>(Action<T> resultCallback);
    }
}
