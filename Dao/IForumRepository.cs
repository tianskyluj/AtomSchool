using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Dao
{
    public interface IForumRepository : IRepository<Forum>
    {
        IQueryable<Forum> LoadAllByPage(out long total, int page, int rows, string order, string sort);

        IQueryable<Forum> LoadAllEnable();
    }
}
