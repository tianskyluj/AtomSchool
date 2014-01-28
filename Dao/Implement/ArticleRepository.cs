using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using Domain;

namespace Dao.Implement
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public IQueryable<Article> LoadAllByPage(out long total, Guid categoryId, int page, int rows, string order, string sort)
        {
            var list = this.LoadAll().Where(w => w.Category != null && w.Category.ID == categoryId);

            total = list.LongCount();

            list = list.OrderByDescending(o => o.IsFirst);
            list = list.OrderBy(sort + " " + order);

            list = list.Skip((page - 1) * rows).Take(rows);

            return list;
        }

        public IQueryable<Article> LoadAllEnable(Guid categoryId)
        {
            return from li in this.LoadAll()
                   where li.Category.ID == categoryId && li.IsEnabled
                   orderby li.IsFirst descending
                   orderby li.CreateDate descending
                   select li;
        }
    }
}
