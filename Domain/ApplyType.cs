using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class ApplyType
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 申请类型名称
        /// </summary>
        public virtual string ApplyTypeName { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public virtual int OrderIndex { get; set; }

        /// <summary>
        /// 关联的流程,非必需项，没有关联流程时，可向任意角色提交
        /// </summary>
        public virtual Flow Flow { get; set; }
    }
}