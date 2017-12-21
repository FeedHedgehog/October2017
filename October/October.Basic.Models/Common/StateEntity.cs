using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October.Basic.Models
{
    /// <summary>
    /// 状态枚举
    /// </summary>
    public enum StateCodeEnum
    {
        Default = -1,
        Fail = 0,
        Success = 1,
    }

    public class StateEntity
    {
        /// <summary>
        ///  请求结果代码
        /// <para>0 表示失败</para>   
        /// <para>1 表示成功</para>   
        /// </summary>
        public StateCodeEnum code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string debugmsg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? editDate { get; set; }
    }

    public class OperationResultEntity
    {
        public StateEntity state { get; set; }

    }

    public class GenerateCodeResultEntity
    {

        public StateEntity state { get; set; }

        public string code { get; set; }
    }
}
