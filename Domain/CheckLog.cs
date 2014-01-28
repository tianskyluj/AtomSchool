using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class CheckLog
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 待审申请单
        /// </summary>
        public virtual Apply Apply { get; set; }

        /// <summary>
        /// 待审角色
        /// </summary>
        public virtual Role Role { get; set; }

        /// <summary>
        /// 待审用户
        /// </summary>
        public virtual UserInfo UserInfo { get; set; }

        /// <summary>
        /// 审核状态 0 未审核;1 通过审核; -1 未通过审核
        /// </summary>
        public virtual Int32 CheckState { get; set; }

        /// <summary>
        /// 审核步骤顺序
        /// </summary>
        public virtual int CheckStep { get; set; }

        /// <summary>
        /// 是否已经提交
        /// </summary>
        public virtual bool IsRecommit { get; set; }

        /// <summary>
        /// 审核备注
        /// </summary>
        public virtual String Remark { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public virtual DateTime CheckTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}