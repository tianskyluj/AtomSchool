using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.Resources;

namespace System.Web.Mvc
{
    public static class LocalizationHelpers
    {
        /// <summary>
        /// 在外边的 Html 中直接使用
        /// </summary>
        /// <param name="htmlhelper"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Language(this HtmlHelper htmlhelper, string key)
        {
            string FilePath = htmlhelper.ViewContext.HttpContext.Server.MapPath("/") + "Resource\\";
            return GetLanguageString(htmlhelper.ViewContext.HttpContext, key, FilePath);
        }
        /// <summary>
        /// 在外边的 Html 中直接使用，对 JS 进行输出字符串
        /// </summary>
        /// <param name="htmlhelper"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string LanguageOutJsVar(this HtmlHelper htmlhelper, string key)
        {
            string FilePath = htmlhelper.ViewContext.HttpContext.Server.MapPath("/") + "Resource\\";
            string langstr = GetLanguageString(htmlhelper.ViewContext.HttpContext, key, FilePath);
            return string.Format("var {0} = '{1}'", key, langstr);
        }
        /// <summary>
        /// 在 C# 中使用
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string InnerLanguage(this HttpContextBase httpContext, string key)
        {
            string FilePath = httpContext.Server.MapPath("/") + "Resource\\";
            return GetLanguageString(httpContext, key, FilePath);
        }

        private static string GetLanguageString(HttpContextBase httpContext, string key, string FilePath)
        {
            var cin = httpContext.Session["isCN"];
            string langtype = (cin == null || cin.ToString() != false.ToString()) ? "zh-CN" : "en-US";

            return LangResourceFileProvider.GetLanguageString(key, langtype, FilePath);
        }
    }

    public static class LangResourceFileProvider
    {
        public static string GetLanguageString(string key, string cultureInfoName, string FilePath)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            ResourceManager rm = new ResourceManager("WebSite.Resource." + cultureInfoName, assembly);
            return rm.GetString(key);        
        }
    }
}