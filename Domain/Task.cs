using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class Task
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 任务分配人
        /// </summary>
        public virtual UserInfo SendUser { get; set; }

        /// <summary>
        /// 邮件标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        public virtual string Content { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public virtual string Attachment { get; set; }

        /// <summary>
        /// 任务级别
        /// </summary>
        public virtual TaskLevel TaskLevel { get; set; }

        /// <summary>
        /// 任务期限
        /// </summary>
        public virtual DateTime Deadline { get; set; }

        /// <summary>
        /// 任务分配时间
        /// </summary>
        public virtual DateTime SendTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}