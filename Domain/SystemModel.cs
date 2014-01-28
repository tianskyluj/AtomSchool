using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class SystemModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        public virtual string ShortName { get; set; }

        /// <summary>
        /// 图标路径
        /// </summary>
        public virtual string Icon { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public virtual string Url { get; set; }

        /// <summary>
        /// 上级节点
        /// </summary>
        public virtual Guid ParentId { get; set; }

        /// <summary>
        /// 左兄弟节点
        /// </summary>
        public virtual Guid SiblingId { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public virtual int OrderIndex { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public virtual bool IsEnabled { get; set; }
    }
}