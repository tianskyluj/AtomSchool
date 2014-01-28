using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Article
    {
        public virtual Guid ID { get; set; }

        public virtual string Name { get; set; }

        public virtual string NameEn { get; set; }

        public virtual string Content { get; set; }

        public virtual string ContentEn { get; set; }

        public virtual string Keyword { get; set; }

        public virtual string KeywordEn { get; set; }

        public virtual string Description { get; set; }

        public virtual string DescriptionEn { get; set; }

        public virtual bool IsEnabled { get; set; }

        public virtual bool IsFirst { get; set; }

        public virtual int ViewCount { get; set; }

        public virtual string From { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual DateTime UpdateDate { get; set; }

        public virtual Category Category { get; set; }
    }
}
