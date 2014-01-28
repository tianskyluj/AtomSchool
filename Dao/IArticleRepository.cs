using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Dao
{
    public interface IArticleRepository : IRepository<Article>
    {
        IQueryable<Article> LoadAllByPage(out long total, Guid categoryId, int page, int rows, string order, string sort);

        IQueryable<Article> LoadAllEnable(Guid categoryId);
    }
}
