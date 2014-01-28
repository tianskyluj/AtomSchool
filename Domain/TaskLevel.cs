using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class TaskLevel
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 任务等级名称
        /// </summary>
        public virtual string LevelName { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public virtual int OrderIndex { get; set; }

    }
}