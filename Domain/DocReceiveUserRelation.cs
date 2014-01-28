using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class DocReceiveUserRelation
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 公文传阅ID
        /// </summary>
        public virtual DocPass DocPass { get; set; }

        /// <summary>
        /// 传阅接收人
        /// </summary>
        public virtual UserInfo ReceiveUser { get; set; }

        /// <summary>
        /// 传阅状态 0:待阅读;1已经阅读
        /// </summary>
        public virtual int State { get; set; }

        /// <summary>
        /// 是否已读
        /// </summary>
        public virtual bool IsRead { get; set; }

        /// <summary>
        /// 是否已读
        /// </summary>
        public virtual string IsReadStateName { get; set; }

        /// <summary>
        /// 阅读时间
        /// </summary>
        public virtual DateTime ReadTime { get; set; }
    }
}