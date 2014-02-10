using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class Grade
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 年级名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 所属年纪类型：小学，初中，高中
        /// </summary>
        public virtual GradeType GradeType { get; set; }

        /// <summary>
        /// 上一年级
        /// </summary>
        public virtual string ParentGrade { get; set; }
    }
}