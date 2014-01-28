using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class City
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 地市名称
        /// </summary>
        public virtual string CityName { get; set; }

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