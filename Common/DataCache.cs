using System;
using System.Web;

namespace Atom.Common
{
    public class DataCache
    {
        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, absoluteExpiration, slidingExpiration);
        }

        ///// <summary>
        ///// 设置全局变量
        ///// </summary>
        //public static void SetGlobalCache(AtomOA.Model.GlobalSetting globalObj)
        //{
        //    SetCache("globalSetting", globalObj);
        //}

        ///// <summary>
        ///// 获取全局变量
        ///// </summary>
        //public static AtomOA.Model.GlobalSetting GetGlobalCache()
        //{
        //    return (AtomOA.Model.GlobalSetting)GetCache("globalSetting");
        //}
    }
}
