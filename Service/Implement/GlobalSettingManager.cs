using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service.Implement
{
    public class GlobalSettingManager : GenericManagerBase<GlobalSetting>, IGlobalSettingManager
    {
        public GlobalSetting GetGlobalsetting()
        {
            return ((Dao.IGlobalSettingRepository)(this.CurrentRepository)).GetGlobalsetting();
        }

        public void SetGlobalCache()
        {
            GlobalSetting global = ((Dao.IGlobalSettingRepository)(this.CurrentRepository)).GetGlobalsetting();
            Atom.Common.DataCache.SetCache("globalSetting", global);
        }

        public GlobalSetting GetGlobalCache()
        {
            return (GlobalSetting)Atom.Common.DataCache.GetCache("globalSetting");
        }
    }
}
