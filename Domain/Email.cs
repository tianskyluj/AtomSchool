using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class Email
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 发件人
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
        /// 是否已读
        /// </summary>
        public virtual bool IsRead { get; set; }

        /// <summary>
        /// 是否从发件箱中删除
        /// </summary>
        public virtual bool IsDeleteFromOutBox { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        public virtual DateTime SendTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}