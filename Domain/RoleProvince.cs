using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class RoleProvince
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
        /// 所属省份
        /// </summary>
        public virtual Province Province { get; set; }
    }
}