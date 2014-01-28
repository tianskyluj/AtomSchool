using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using Domain;

namespace Dao.Implement
{
    public class GlobalSettingRepository : RepositoryBase<GlobalSetting>, IGlobalSettingRepository
    {
        public GlobalSetting GetGlobalsetting()
        {
            return this.LoadAll().FirstOrDefault();
        }
    }
}
