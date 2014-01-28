using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service.Implement
{
    public class CategoryManager : GenericManagerBase<Category>, ICategoryManager
    {
        public IList<Category> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            return ((Dao.ICategoryRepository)(this.CurrentRepository))
                .LoadAllByPage(out total, page, rows, order, sort).ToList();
        }

        public IList<Category> LoadAllEnable()
        {
            return ((Dao.ICategoryRepository)(this.CurrentRepository)).LoadAllEnable().ToList();
        }

        public IList<Category> LoadAllEnable(Guid forumId)
        {
            return ((Dao.ICategoryRepository)(this.CurrentRepository)).LoadAllEnable(forumId).ToList();
        }
    }
}
