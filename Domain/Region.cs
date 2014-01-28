using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class Region
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public virtual string RegionName { get; set; }

        /// <summary>
        /// 所属地市
        /// </summary>
        public virtual City City { get; set; }

        /// <summary>
        /// 所属省份
        /// </summary>
        public virtual Province Province { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual bool IsEnabled { get; set; }
    }
}