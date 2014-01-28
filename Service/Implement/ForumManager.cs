using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service.Implement
{
    public class ForumManager : GenericManagerBase<Forum>, IForumManager
    {
        public IList<Forum> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            return ((Dao.IForumRepository)(this.CurrentRepository))
                .LoadAllByPage(out total, page, rows, order, sort).ToList();
        }

        public IList<Forum> LoadAllEnable()
        {
            return ((Dao.IForumRepository)(this.CurrentRepository)).LoadAllEnable().ToList();
        }
    }
}
