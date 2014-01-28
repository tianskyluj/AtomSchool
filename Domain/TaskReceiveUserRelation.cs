using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class TaskReceiveUserRelation
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 任务ID
        /// </summary>
        public virtual Task Task { get; set; }

        /// <summary>
        /// 任务接收人
        /// </summary>
        public virtual UserInfo ReceiveUser { get; set; }

        /// <summary>
        /// 任务状态
        /// </summary>
        public virtual TaskState TaskState { get; set; }

        /// <summary>
        /// 任务完成百分比
        /// </summary>
        public virtual double TaskPercentage { get; set; }

        /// <summary>
        /// 任务完成时间
        /// </summary>
        public virtual DateTime FinishTime { get; set; }
    }
}