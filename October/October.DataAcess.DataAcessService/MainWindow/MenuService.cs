using Newtonsoft.Json;
using October.Basic.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October.DataAcess.DataAcessService
{
    public class MenuService : IMenu
    {
        public void GetMenu<T>(Action<T> resultCallback)
        {
            //TODO:暂时取消从服务器上加载，因为老版本演示的问题，从本地加载上去
            //HttpHelper.GetRequestAsync("/server/c/privilege/privilege/mymenu.json", resultCallback);
            string result = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Data", "mainmenu.json"));
            if (string.IsNullOrEmpty(result))
            {
                resultCallback?.Invoke(default(T));
            }
            else
            {
                resultCallback?.Invoke(JsonConvert.DeserializeObject<T>(result));
            }

        }
    }
}
