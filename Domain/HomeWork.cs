using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class HomeWork
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 作业提交日期
        /// </summary>
        public virtual DateTime ComitDate { get; set; }

        /// <summary>
        /// 作业班级
        /// </summary>
        public virtual Classes Classes { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        public virtual Subject Subject { get; set; }

        /// <summary>
        /// 作业内容
        /// </summary>
        public virtual string Content { get; set; }

        /// <summary>
        /// 布置作业的老师
        /// </summary>
        public virtual Teacher Teacher { get; set; }

        /// <summary>
        /// 作业添加日期
        /// </summary>
        public virtual DateTime CreateDate { get; set; }

    }
}