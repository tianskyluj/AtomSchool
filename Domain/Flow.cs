using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class Flow
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 状态名称
        /// </summary>
        public virtual string FlowName { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}