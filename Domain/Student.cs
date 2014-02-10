using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class Student
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 是否毕业
        /// </summary>
        public virtual bool IsGraduate { get; set; }
    }
}