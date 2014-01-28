using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class Custom
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 客户类型：新客户，老客户，潜在客户
        /// </summary>
        public virtual CustomType CustomType { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public virtual DateTime Birthday { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public virtual string Telphone { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        public virtual string Company { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public virtual string Department { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public virtual string Position { get; set; }

        /// <summary>
        /// 兴趣爱好
        /// </summary>
        public virtual string Intresting { get; set; }

        /// <summary>
        /// 忌讳
        /// </summary>
        public virtual string Hating { get; set; }

        /// <summary>
        /// 家庭情况:是否结婚,是否有子女,
        /// </summary>
        public virtual string Famaily { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public virtual UserInfo CreateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}