using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class GlobalSetting
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public virtual string CompanyName { get; set; }

        /// <summary>
        /// 是否开启省份权限控制
        /// </summary>
        public virtual bool IsProvince { get; set; }

        /// <summary>
        /// 是否开启地市权限控制
        /// </summary>
        public virtual bool IsCity { get; set; }

        /// <summary>
        /// 是否开启区域权限控制
        /// </summary>
        public virtual bool IsRegion { get; set; }

        /// <summary>
        /// 是否开启科室部门权限控制
        /// </summary>
        public virtual bool IsDepartment { get; set; }
    }
}