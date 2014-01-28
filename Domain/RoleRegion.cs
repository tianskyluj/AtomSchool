using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class RoleRegion
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 所属角色
        /// </summary>
        public virtual Role Role { get; set; }

        /// <summary>
        /// 所属区域
        /// </summary>
        public virtual Region Region { get; set; }
    }
}