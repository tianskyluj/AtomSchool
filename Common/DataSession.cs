using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atom.Common
{
    public class DataSession
    {
        public DataSession()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }


        // 销毁session 数据
        public static void destroySession()
        {
            HttpContext.Current.Session.Clear();
        }

        //取得Session中的变量值
        public static object getSessionValue(string Sessinname)
        {
            object obj = null;
            try
            {
                obj = HttpContext.Current.Session[Sessinname];
            }
            catch
            {

            }
            return obj;
        }

        //设置Session变量及值
        public static void setSession(string Sessionname, object Sessionvalue)
        {
            HttpContext.Current.Session[Sessionname] = Sessionvalue;
        }
    }
}
