using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class ClassTeacherRelation
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 班级
        /// </summary>
        public virtual Classes Classes { get; set; }

        /// <summary>
        /// 老师
        /// </summary>
        public virtual Teacher Teacher { get; set; }

        /// <summary>
        /// 教师在本班教授的科目
        /// </summary>
        public virtual Subject Subject { get; set; }
    }
}