using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class DocPass
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 传阅发起人
        /// </summary>
        public virtual UserInfo SendUser { get; set; }

        /// <summary>
        /// 传阅标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public virtual string Attachment { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}