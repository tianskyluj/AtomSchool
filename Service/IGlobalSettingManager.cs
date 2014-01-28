using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface IGlobalSettingManager : IGenericManager<GlobalSetting>
    {
        /// <summary>
        /// 获取全局变量参数
        /// </summary>
        /// <returns></returns>
        GlobalSetting GetGlobalsetting();

        /// <summary>
        /// 将全局变量存入Cache中，方便其他方法调用
        /// </summary>
        void SetGlobalCache();

        /// <summary>
        /// 从Cache中获取全局变量
        /// </summary>
        /// <returns></returns>
        GlobalSetting GetGlobalCache();
    }
}
