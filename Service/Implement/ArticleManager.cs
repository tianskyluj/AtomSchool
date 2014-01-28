using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service.Implement
{
    public class ArticleManager : GenericManagerBase<Article>, IArticleManager
    {
        public IList<Article> LoadAllByPage(out long total, Guid categoryId, int page, int rows, string order, string sort)
        {
            return ((Dao.IArticleRepository)(this.CurrentRepository))
                .LoadAllByPage(out total, categoryId, page, rows, order, sort).ToList();
        }

        public void ViewsAdd(Guid id)
        {
            var repository = (Dao.IArticleRepository)this.CurrentRepository;
            var entity = repository.Get(id);
            if (entity == null)
            {
                return;
            }

            entity.ViewCount++;
            repository.Save(entity);
        }

        public IList<Article> LoadAllEnable(Guid categoryId)
        {
            return ((Dao.IArticleRepository)(this.CurrentRepository)).LoadAllEnable(categoryId).ToList();
        }
    }
}
