using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class Notice
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 通知接受人
        /// </summary>
        public virtual UserInfo ReceiveUser { get; set; }

        /// <summary>
        /// 申请标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        public virtual string Content { get; set; }

        /// <summary>
        /// 通知状态
        /// </summary>
        public virtual int State { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}