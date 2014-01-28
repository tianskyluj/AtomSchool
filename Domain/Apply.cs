using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class Apply
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public virtual UserInfo SendUser { get; set; }

        /// <summary>
        /// 申请标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        public virtual string Content { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public virtual int CheckState { get; set; }

        /// <summary>
        /// 审核状态名称
        /// </summary>
        public virtual String CheckStateName { get; set; }

        /// <summary>
        /// 审核步骤顺序
        /// </summary>
        public virtual int CheckStep { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public virtual string Attachment { get; set; }

        /// <summary>
        /// 申请类型
        /// </summary>
        public virtual ApplyType ApplyType { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}