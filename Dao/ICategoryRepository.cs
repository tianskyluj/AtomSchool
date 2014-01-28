using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Dao
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IQueryable<Category> LoadAllByPage(out long total, int page, int rows, string order, string sort);

        IQueryable<Category> LoadAllEnable();

        IQueryable<Category> LoadAllEnable(Guid forumId);
    }
}
