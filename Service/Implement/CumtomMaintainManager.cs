using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using System.IO;
using Atom.Common.Sys;
using System.Web;

namespace Service.Implement
{
    public class CustomMaintainManager : GenericManagerBase<CustomMaintain>, ICustomMaintainManager
    {
        /// <summary>
        /// 根据客户信息删除客户维护信息
        /// </summary>
        /// <param name="custom"></param>
        public void DeleteMaintainWithCustom(Custom custom)
        {
            IList<CustomMaintain> customMaintainList = base.LoadAll().Where(f=>f.Custom.ID == custom.ID).ToList();
            for (int i = 0; i < customMaintainList.Count; i++)
            {
                base.Delete(customMaintainList[i].ID);  
            }
        }
    }
}
