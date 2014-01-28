using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class CustomMaintain
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 维系的客户
        /// </summary>
        public virtual Custom Custom { get; set; }

        /// <summary>
        /// 维系目标:销售，回款,普通维系
        /// </summary>
        public virtual MaintainType MaintainType { get; set; }

        /// <summary>
        /// 维系方法:电话维系，当面维系
        /// </summary>
        public virtual MaintainMethod MaintainMethod { get; set; }

        /// <summary>
        /// 维系人
        /// </summary>
        public virtual UserInfo MaintainUser { get; set; }

        /// <summary>
        /// 维系时间
        /// </summary>
        public virtual DateTime MaintainTime { get; set; }

        /// <summary>
        /// 维系结果
        /// </summary>
        public virtual string Result { get; set; }

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