using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class Teacher
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 教师名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 教师登录用户名
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// 教授科目
        /// </summary>
        public virtual Subject Subject { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public virtual string Telephone { get; set; }

    }
}