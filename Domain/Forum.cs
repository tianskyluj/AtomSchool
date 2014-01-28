using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// 版块
    /// </summary>
    public class Forum
    {
        public virtual Guid ID { get; set; }

        public virtual int OrderNo { get; set; }

        public virtual string Name { get; set; }

        public virtual string NameEn { get; set; }

        public virtual bool IsEnabled { get; set; }

        public virtual IList<Category> CategoryList { get; set; }
    }
}
