using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class EmailReceiveUserRelation
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// EmailID
        /// </summary>
        public virtual Email Email { get; set; }

        /// <summary>
        /// 收件人
        /// </summary>
        public virtual UserInfo ReceiveUser { get; set; }

        /// <summary>
        /// 是否从收件箱中删除
        /// </summary>
        public virtual bool IsDeleteFromInBox { get; set; }

        /// <summary>
        /// 是否阅读
        /// </summary>
        public virtual bool IsRead { get; set; }

        /// <summary>
        /// 是否阅读名称
        /// </summary>
        public virtual string IsReadStateName { get; set; }
    }
}