using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class RoleRights
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public virtual Role Role { get; set; }

        /// <summary>
        /// 模块
        /// </summary>
        public virtual SystemModel SystemModel { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public virtual Rights Rights { get; set; }
    }
}