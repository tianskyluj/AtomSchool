using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class Registration
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public virtual Guid UserId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// 签到时间
        /// </summary>
        public virtual DateTime RegistrationStartTime { get; set; }

        /// <summary>
        /// 签到结束时间
        /// </summary>
        public virtual DateTime RegistrationEndTime { get; set; }

        /// <summary>
        /// 当天工作时间(小时)
        /// </summary>
        public virtual double WorkTimeSpan { get; set; }

        /// <summary>
        /// 签到备注
        /// </summary>
        public virtual string Remark { get; set; }
    }
}