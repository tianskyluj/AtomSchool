using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Domain
{
    public class UploadFile
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 属于哪个ID的上传文件
        /// </summary>
        public virtual Guid BaseID { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public virtual String FileName { get; set; }

        /// <summary>
        /// 文件地址
        /// </summary>
        public virtual String FileURL { get; set; }

        /// <summary>
        /// 上传类型:邮件附件，传阅附件
        /// </summary>
        public virtual String FileType { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public virtual UserInfo CreateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }

        public virtual bool success { get; set; }
    }
}