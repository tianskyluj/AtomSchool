using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class Classes
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 所属年级
        /// </summary>
        public virtual Grade Grade { get; set; }

        /// <summary>
        /// 班主任
        /// </summary>
        public virtual Teacher Teacher { get; set; }
    }
}