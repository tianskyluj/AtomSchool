using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface ICategoryManager : IGenericManager<Category>
    {
        IList<Category> LoadAllByPage(out long total, int page, int rows, string order, string sort);

        IList<Category> LoadAllEnable();

        IList<Category> LoadAllEnable(Guid forumId);
    }
}
