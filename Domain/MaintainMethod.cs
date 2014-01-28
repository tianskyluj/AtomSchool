using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class MaintainMethod
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 维系方法:电话维系，当面维系
        /// </summary>
        public virtual string MethodName { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public virtual int OrderIndex { get; set; }
    }
}