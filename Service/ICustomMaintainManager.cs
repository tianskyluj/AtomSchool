using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface ICustomMaintainManager : IGenericManager<CustomMaintain>
    {
        /// <summary>
        /// 根据客户信息删除客户维护信息
        /// </summary>
        /// <param name="custom"></param>
        void DeleteMaintainWithCustom(Custom custom);
    }
}
