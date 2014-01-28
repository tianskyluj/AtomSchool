using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Category
    {
        public virtual Guid ID { get; set; }

        public virtual int OrderNo { get; set; }

        public virtual string Name { get; set; }

        public virtual string NameEn { get; set; }

        public virtual string Content { get; set; }

        public virtual string ContentEn { get; set; }

        public virtual string Keyword { get; set; }

        public virtual string KeywordEn { get; set; }

        public virtual string Description { get; set; }

        public virtual string DescriptionEn { get; set; }

        public virtual bool IsEnabled { get; set; }

        public virtual string CategoryType { get; set; }

        public virtual Forum Forum { get; set; }

        public virtual IList<Article> ArticleList { get; set; }
    }
}
