using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Net;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Management;

namespace Atom.Common
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// 把日期转换成：2011-12-01的格式
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToDateString(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 把字符串转化成Int32，如果出错则返回0
        /// </summary>
        /// <param name="intString"></param>
        /// <returns></returns>
        public static int ToInt(this string intString)
        {
            try
            {
                return Convert.ToInt32(intString);
            }
            catch { return 0; }
        }
        /// <summary>
        /// 把object对象转化成Int32，如果出错则返回0
        /// </summary>
        /// <param name="intString"></param>
        /// <returns></returns>
        public static int ToInt(this object intString)
        {
            try
            {
                return Convert.ToInt32(intString);
            }
            catch { return 0; }
        }

        /// <summary>
        /// 把字符串转化成Int32，如果出错则返回默认值
        /// </summary>
        /// <param name="intString"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int ToInt(this string intString, int defaultValue)
        {
            try
            {
                return Convert.ToInt32(intString);
            }
            catch { return defaultValue; }
        }

        /// <summary>
        ///  把object对象转化成Int32，如果出错则返回默认值
        /// </summary>
        /// <param name="intObject"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt(this object intObject, int defaultValue)
        {
            try
            {
                return Convert.ToInt32(intObject);
            }
            catch { return defaultValue; }
        }

        /// <summary>
        /// 把日期字段串转化成日期格式，如果出错，则返回new DateTime()
        /// </summary>
        /// <param name="dateTimeString"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string dateTimeString)
        {
            try
            {
                return Convert.ToDateTime(dateTimeString);
            }
            catch { return DateTime.Now; }
        }

        /// <summary>
        /// 把日期object对象转化成日期格式，如果出错，则返回new DateTime()
        /// </summary>
        /// <param name="dateTimeObject"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object dateTimeObject)
        {
            try
            {
                return Convert.ToDateTime(dateTimeObject);
            }
            catch { return DateTime.Now; }
        }

        /// <summary>
        /// 把日期object对象转化成日期格式，如果出错，则返回默认值
        /// </summary>
        /// <param name="dateTimeObject"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object dateTimeObject, DateTime defaultValue)
        {
            try
            {
                return Convert.ToDateTime(dateTimeObject);
            }
            catch { return defaultValue; }
        }

        /// <summary>
        /// 把字符串转化成double，如果出错则返回0
        /// </summary>
        /// <param name="doubleString"></param>
        /// <returns></returns>
        public static double ToDouble(this string doubleString)
        {
            try
            {
                return Convert.ToDouble(doubleString);
            }
            catch { return 0; }
        }

        /// <summary>
        /// 把object对象转化成double，如果出错则返回0
        /// </summary>
        /// <param name="doubleObject"></param>
        /// <returns></returns>
        public static double ToDouble(this object doubleObject)
        {
            try
            {
                return Convert.ToDouble(doubleObject);
            }
            catch { return 0; }
        }

        /// <summary>
        /// 把object对象转化成String，如果出错则返回0
        /// </summary>
        /// <param name="doubleObject"></param>
        /// <returns></returns>
        public static string ToStr(this object doubleObject)
        {
            try
            {
                return doubleObject.ToString();
            }
            catch { return ""; }
        }

        /// <summary>
        /// 把object对象转化成double，如果出错则返回默认值
        /// </summary>
        /// <param name="doubleObject"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double ToDouble(this object doubleObject, double defaultValue)
        {
            try
            {
                return Convert.ToDouble(doubleObject);
            }
            catch { return defaultValue; }
        }

        /// <summary>
        /// 设置DropDownList的选定值
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        public static void SetValue(this DropDownList list, string value)
        {
            list.SelectedIndex = list.Items.IndexOf(list.Items.FindByValue(value));
        }
    }

    public enum StringType { String, Num, Bool, Date };
    /// <summary>
    /// inc 的摘要说明
    /// </summary>
    public class inc
    {
        public static string SessionUserName = "UserName";
        public static string SessionUserID = "UserId";
        public static string SessionCompanyId = "CompanyId";
        public static string SessionCompanyName = "CompanyName";
        public inc()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        // 销毁session 数据
        public static void destroySession()
        {
            HttpContext.Current.Session.Clear();
        }
        //取得Session中的用户ID
        public static int getSessionUserID()
        {

            int _id = 0;
            try
            {
                _id = Convert.ToInt32(HttpContext.Current.Session["id"].ToString());
            }
            catch
            {

            }
            return _id;
        }
        //取得Session中的用户名
        public static string getSessionUsername()
        {
            string _yhm = "";
            try
            {
                _yhm = HttpContext.Current.Session["yhm"].ToString();
            }
            catch
            {

            }
            return _yhm;
        }
        //取得Session中的用户姓名
        public static string getSessionName()
        {
            string _yhm = "";
            try
            {
                _yhm = HttpContext.Current.Session["xm"].ToString();
            }
            catch
            {

            }
            return _yhm;
        }
        //取得Session中的变量值
        public static string getSessionValue(string Sessinname)
        {
            string _str = "";
            try
            {
                _str = HttpContext.Current.Session[Sessinname].ToString();
            }
            catch
            {

            }
            return _str;
        }

        //设置Session变量及值
        public static void setSession(string Sessionname, object Sessionvalue)
        {
            HttpContext.Current.Session[Sessionname] = Sessionvalue;
        }


        //MD5加密
        public static string md5(string str)
        {
            //return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str,"MD5").ToLower().Substring(8,16) ;//16位加密
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToUpper();//32位加密(大写)

        }

        //检查是否为合法字符串
        public static bool checkstring(string str)
        {
            if (str.Trim().Length > 0)
            {
                str = str.ToLower().Replace(" ", "");
                if (str.IndexOf("'") > -1)
                    return false;
                if (str.ToLower().IndexOf(" or ") > -1)
                    return false;
                if (str.ToLower().IndexOf("<script") > -1)
                    return false;
                if (str.ToLower().IndexOf("<iframe") > -1)
                    return false;
            }
            return true;
        }

        public static bool checkstring(string str, bool ifnull)
        {
            if (ifnull)
            {
                if (str.Trim().Length > 0)
                {
                    str = str.ToLower().Replace(" ", "");
                    if (str.IndexOf("'") > -1)
                        return false;
                    if (str.ToLower().IndexOf(" or ") > -1)
                        return false;
                    if (str.ToLower().IndexOf("<script") > -1)
                        return false;
                    if (str.ToLower().IndexOf("<iframe") > -1)
                        return false;

                    return true;
                }
                return false;
            }
            else
            {
                if (str.Trim().Length > 0)
                {
                    str = str.ToLower().Replace(" ", "");
                    if (str.IndexOf("'") > -1)
                        return false;
                    if (str.ToLower().IndexOf(" or ") > -1)
                        return false;
                    if (str.ToLower().IndexOf("<script") > -1)
                        return false;
                    if (str.ToLower().IndexOf("<iframe") > -1)
                        return false;
                }
                return true;
            }
        }

        //检查是否为合法字符串，并判断长度
        public static bool checkstring(string str, bool ifnull, int count)
        {
            if (str.Length <= count)
            {

                if (ifnull)
                {
                    if (str.Trim().Length > 0)
                    {
                        str = str.ToLower().Replace(" ", "");
                        if (str.IndexOf("'") > -1)
                            return false;
                        if (str.ToLower().IndexOf(" or ") > -1)
                            return false;
                        if (str.ToLower().IndexOf("<script") > -1)
                            return false;
                        if (str.ToLower().IndexOf("<iframe") > -1)
                            return false;
                        return true;
                    }
                    return false;
                }
                else
                {
                    if (str.Trim().Length > 0)
                    {
                        str = str.ToLower().Replace(" ", "");
                        if (str.IndexOf("'") > -1)
                            return false;
                        if (str.ToLower().IndexOf(" or ") > -1)
                            return false;
                        if (str.ToLower().IndexOf("<script") > -1)
                            return false;
                        if (str.ToLower().IndexOf("<iframe") > -1)
                            return false;

                    }
                    return true;
                }
            }
            else
                return false;
        }
        //替换<和 >
        public static string replacehtml(string str)
        {
            if (str.Trim().Length > 0)
            {
                str = str.Replace("<", "&lt;");
                str = str.Replace(">", "&gt;");
            }
            return str;
        }

        // 判断是否为数值
        public static bool IsNumeric(string value)
        {
            try
            {
                Decimal temp = Convert.ToDecimal(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
        // 判断是否为整数值
        public static bool CheckisInt(string value)
        {
            try
            {
                Int32 temp = Convert.ToInt32(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
        // 判断是否为日期
        public static bool IsDate(string value)
        {
            try
            {
                DateTime temp = Convert.ToDateTime(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // 判断是否为布尔值 
        public static bool IsBool(string value)
        {
            try
            {
                bool temp = Convert.ToBoolean(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //弹出消息框（Response）
        public static void AspMsg(string str)
        {
            System.Web.HttpContext.Current.Response.Write("<script>alert('" + str + "');</script>");
        }

        //弹出消息框
        public static void msg(string str)
        {
            ((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).ClientScript.RegisterStartupScript(((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).GetType(), "script", "alert('" + str + "');", true);
        }



        //页面转向(页面名)
        public static void gotopage(string _pagename)
        {
            ((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).ClientScript.RegisterStartupScript(((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).GetType(), "script", "window.location.href='" + _pagename + "';", true);
        }
        //页面转向(页面名，框架名)
        public static void gotopage(string _pagename, string target)
        {
            ((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).ClientScript.RegisterStartupScript(((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).GetType(), "script", target + ".window.location.href='" + _pagename + "';", true);
        }
        //页面转向()
        public static void gotopage()
        {
            ((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).ClientScript.RegisterStartupScript(((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).GetType(), "script", "window.location.href='" + inc.getNowPageName() + "';", true);
        }
        //弹出警告框和页面转向(警告消息，页面名)
        public static void msgandgotopage(string _message, string _pagename)
        {
            ((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).ClientScript.RegisterStartupScript(((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).GetType(), "script", "alert('" + _message + "');window.location.href='" + _pagename + "';", true);
        }
        //弹出警告框和页面转向当前页(警告消息)
        public static void msgandgotopage(string _message)
        {
            ((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).ClientScript.RegisterStartupScript(((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).GetType(), "script", "alert('" + _message + "');window.location.href='" + inc.getNowPageName() + "';", true);
        }


        //执行客户端的Script语句
        public static void ExecuteScript(string str)
        {
            ((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).ClientScript.RegisterStartupScript(((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).GetType(), "script", str, true);
        }

        public static string findstr(DataTable dt, string tjzdm, string jgzdm, string e)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][tjzdm].ToString() == e)
                    return dt.Rows[i][jgzdm].ToString();
            }
            return "";
        }

        public static string findstr(DataTable dt, string tjzdm, string jgzdm, string e, string res)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][tjzdm].ToString() == e)
                    return dt.Rows[i][jgzdm].ToString();
            }
            return res;
        }

        public static string findstr(string[,] dt, int tjzdm, int jgzdm, string e)
        {
            for (int i = 0; i < dt.GetLength(0); i++)
            {
                if (dt[i, tjzdm].ToString() == e)
                    return dt[i, jgzdm].ToString();
            }
            return "";
        }
        //判断用户权限
        public static void checkright(string _qxm)
        {
            _qxm = "|" + _qxm.ToLower() + "$";
            try
            {
                if (HttpContext.Current.Session["yhqx"].ToString().IndexOf(_qxm) < 0)
                {
                    System.Web.HttpContext.Current.Response.Write("<script>alert('Sorry，你没有该操作权限！');window.location.href='main.aspx';</script>");
                    HttpContext.Current.Response.End();
                }
            }
            catch
            {
                // System.Web.HttpContext.Current.Response.Write("<script>alert('时间超时！或者你没有登陆！请重新登陆！');parent.window.location.href='login.aspx'</script>");
                System.Web.HttpContext.Current.Response.Write("<script>parent.window.location.href='login.aspx'</script>");
                HttpContext.Current.Response.End();
            }
        }
        public static void checkright()
        {
            string _qxm = "";
            if (HttpContext.Current.Request.QueryString["qxm"] != null)
                _qxm = HttpContext.Current.Request.QueryString["qxm"].ToString();
            _qxm = "|" + _qxm + "$";
            try
            {
                if (HttpContext.Current.Session["yhqx"].ToString().IndexOf(_qxm) < 0)
                {
                    System.Web.HttpContext.Current.Response.Write("<script>alert('Sorry，你没有该操作权限！');window.location.href='main.aspx';</script>");
                    HttpContext.Current.Response.End();
                }
            }
            catch
            {
                System.Web.HttpContext.Current.Response.Write("<script>parent.window.location.href='login.aspx'</script>");
                HttpContext.Current.Response.End();
            }
        }
        //判断用户操作权限
        public static bool checkczqx(string _qxm, int _jb)
        {
            try
            {
                string[,] _yhqxl = (string[,])HttpContext.Current.Session["yhqxl"];
                if (Convert.ToInt32(inc.findstr(_yhqxl, 0, 1, _qxm)) >= _jb)
                    return true;
                else
                    return false;

            }
            catch
            {
                return false;
            }
        }




        //取得时间+随机数的文件名
        public static string getname()
        {
            Random ran = new Random();
            string _str = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ran.Next(9999).ToString();
            return _str;
        }

        //取得以月为单位的文件夹名
        public static string getymname()
        {
            string _str = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString();
            return _str;
        }

        //从文件路径中取得文件全名
        public static string getfilename(string _filepath)
        {
            int _i = _filepath.LastIndexOf("\\");
            string _temp = _filepath;
            if (_i > -1)
                _temp = _filepath.Substring(_i);
            return _temp;

        }
        //从文件路径中取得文件路径
        public static string getfilepath(string _filepath)
        {
            int _i = _filepath.LastIndexOf("\\");
            string _temp = "";
            if (_i > -1)
                _temp = _filepath.Substring(0, _i + 1) + "\\";
            return _temp;

        }
        //从文件路径中取得文件后缀名
        public static string getfiletype(string _filepath)
        {
            int _i = _filepath.LastIndexOf("\\");
            string _temp = _filepath;
            if (_i > -1)
                _temp = _filepath.Substring(_i);


            _i = _temp.LastIndexOf(".");
            string _ftype = "";
            if (_i > -1)
                _ftype = _temp.Substring(_i + 1);

            return _ftype;
        }

        //判断文件夹是否存在，如不存在则建立文件夹
        public static bool checkfolder(string _str)
        {
            string _folderpath = inc.getfilepath(_str);
            if (Directory.Exists(HttpContext.Current.Server.MapPath(_folderpath)))
                return true;
            else
            {
                try
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(_folderpath));
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }




        //删除文件
        public static bool delfile(string _filepath)
        {
            if (_filepath.Trim().Length == 0)
                return true;
            if (File.Exists(HttpContext.Current.Server.MapPath(_filepath)))
            {
                try
                {
                    File.Delete(HttpContext.Current.Server.MapPath(_filepath));
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        //删除信息中的上传文件
        public static bool deluploadfiles(string _files)
        {
            if (_files.Trim().Length > 0)
            {
                string[] _filelist = _files.Split(',');
                for (int i = 0; i < _filelist.Length; i++)
                {
                    inc.delfile("include//editor//uploadfile//" + _filelist[i]);
                }
            }

            return true;
        }


        //取得当前页页面名
        public static string getNowPageName()
        {
            string _path = HttpContext.Current.Request.Url.ToString();
            int i = 0;
            i = _path.LastIndexOf("/");
            if (i > -1)
            {
                _path = _path.Substring(i + 1);
            }
            return _path;
        }


        //取得IP
        public static string GetIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            return result;
        }

        //截取部分字符串
        public static string GetString(string str, int count)
        {
            if (str.Length > count)
                return str.Substring(0, count);
            return str;
        }

        public static string GetStringS(string str, int count)
        {
            if (str.Length > count)
                return str.Substring(0, count) + ". . . . . .";
            return str;
        }
        //取得管理系统登陆尝试次数
        public static int GetSystemTestTimes()
        {
            try
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["systemtesttimes"].ToString());
            }
            catch
            {
                return 5;
            }
        }


        //_______________________________________________________________________
        //DataList绑定**************************************************************
        //public static void DataListBind(string sql, DataList dl)
        //{
        //    DBHelper dc = new DBHelper();
        //    dl.DataSource = dc.DataList(sql);


        //    dl.DataBind();
        //}
        //_______________________________________________________________________

        //DropDownList绑定**************************************************************
        //public static void DropDownListBind(DropDownList dl, string sql, string textField, string valueField)
        //{
        //    DBHelper dc = new DBHelper();
        //    dl.DataSource = dc.DataList(sql);
        //    dl.DataTextField = textField;
        //    dl.DataValueField = valueField;
        //    dl.DataBind();
        //}
        //_______________________________________________________________________


        //取得页面传递参数**************************************************************
        public static string GetQueryString(string _name)
        {
            string _value = "";
            if (HttpContext.Current.Request.QueryString[_name] != null)
                _value = HttpContext.Current.Request.QueryString[_name].ToString();
            return _value;
        }
        public static string GetQueryString(string _name, StringType _type)
        {
            string _value = "";
            if (HttpContext.Current.Request.QueryString[_name] != null)
                _value = HttpContext.Current.Request.QueryString[_name].ToString();
            if (_type == StringType.String)
            {
                if (!inc.checkstring(_value))
                    _value = "";
            }
            if (_type == StringType.Num)
            {
                if (!inc.IsNumeric(_value))
                    _value = "0";
            }
            return _value;
        }

        /// <summary>
        /// 获取post提交的form参数
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public static string getFormPar(string _name)
        {
            string _value = "";
            if (HttpContext.Current.Request.Form[_name] != null)
                _value = HttpContext.Current.Request.Form[_name];
            return _value;
        }
        //_______________________________________________________________________


        //分页函数
        public static string showpagebar(int num, int pagecount, int page)
        {
            string str = "<div id='pagebar'>";
            str = str + "共 " + num.ToString() + " 条信息，共 " + pagecount.ToString() + " 页";
            str = str + "<select name='page' id='page' onchange='javascript:getpage();'>";
            for (int i = 1; i <= pagecount; i++)
            {
                str = str + "<option value='" + i.ToString() + "'";
                if (page == i)
                    str = str + " selected='selected'";
                str = str + " >" + i.ToString() + "/" + pagecount.ToString() + "</option>";
            }
            str = str + "</select></div>";
            return str;
        }

        //过滤HTML代码
        public static string filterHtml(string html)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" no[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>]+\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记 
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性 
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件 
            html = regex4.Replace(html, ""); //过滤iframe 
            html = regex5.Replace(html, ""); //过滤frameset 
            html = regex6.Replace(html, ""); //过滤frameset 
            html = regex7.Replace(html, ""); //过滤frameset 
            html = regex8.Replace(html, ""); //过滤frameset 
            html = regex9.Replace(html, "");
            html = html.Replace(" ", "");
            html = html.Replace("</strong>", "");
            html = html.Replace("<strong>", "");
            return html;
        }

        ////取得站型
        //public static string getContractType(int _st)
        //{
        //    DBHelper dc = new DBHelper();
        //    return dc.ExecuteOneResult("select typename from ContractType where id=" + _st.ToString() + "");
        //}

        ////取得站型
        //public static string getSiteType(int _st)
        //{
        //    DBHelper dc = new DBHelper();
        //    return dc.ExecuteOneResult("select typename from SiteType where id=" + _st.ToString() + "");
        //}
        ////取得税金承担方式
        //public static string getInvoice(int _st)
        //{
        //    DBHelper dc = new DBHelper();
        //    return dc.ExecuteOneResult("select typename from InvoiceType where typevalue=" + _st.ToString() + "");
        //}

        ////取得合同档案文件存路径
        //public static string getContractFile(string _fn, int _t)
        //{
        //    if (_t == 0)
        //        return "~/" + ConfigurationManager.AppSettings["sitefilepath"].ToString() + "//" + _fn;
        //    else
        //        return "~/" + ConfigurationManager.AppSettings["elsefilepath"].ToString() + "//" + _fn;
        //}

        ////取得每月使用小时数
        //public static double getUseTime(int i)
        //{
        //    string str = ConfigurationManager.AppSettings["usetime"].ToString();
        //    string[] obj = str.Split(',');
        //    if (i > 12 || i < 1)
        //        i = 1;
        //    return Convert.ToDouble(obj[i - 1]);
        //}
        ////取得每月天数
        //public static int getdays(int m)
        //{
        //    switch (m)
        //    {
        //        case 2:
        //            return 28;
        //            break;
        //        case 4:
        //        case 6:
        //        case 9:
        //        case 11:
        //            return 30;
        //            break;
        //        case 1:
        //        case 3:
        //        case 5:
        //        case 7:
        //        case 8:
        //        case 10:
        //        case 12:
        //            return 31;
        //            break;
        //        default:
        //            return 0;
        //            break;
        //    }
        //}


        ////取得预警值
        //public static double getPreviseValue()
        //{
        //    try
        //    {
        //        return Convert.ToDouble(ConfigurationManager.AppSettings["previsevalue"].ToString());
        //    }
        //    catch { return 0.1; }
        //}

        //取得Excel上传文件路径
        public static string getexcelsavepath()
        {

            return ConfigurationManager.AppSettings["excelsavepath"].ToString() + "//";

        }

        ////审核完成标识
        //public static int getLastCheckLevel()
        //{
        //    return 3;
        //}

        ////基站类缴费记录审核级别
        //public static void BindSiteCheckLevel(DropDownList dl, string _sl)
        //{
        //    dl.Items.Add(new ListItem("所有", "-1"));
        //    dl.Items.Add(new ListItem("未审核", "0"));
        //    dl.Items.Add(new ListItem("分部领导审核", "1"));
        //    dl.Items.Add(new ListItem("运维审核", "2"));

        //    dl.Items.Add(new ListItem("财务审核", "3"));
        //    try { dl.SelectedValue = _sl; }
        //    catch { }
        //}

        ////办公经营类缴费记录审核级别
        //public static void BindElseCheckLevel(DropDownList dl, string _sl)
        //{
        //    dl.Items.Add(new ListItem("所有", "-1"));
        //    dl.Items.Add(new ListItem("未审核", "0"));
        //    dl.Items.Add(new ListItem("分部经理审核", "1"));
        //    dl.Items.Add(new ListItem("综合部审核", "2"));

        //    dl.Items.Add(new ListItem("财务审核", "3"));
        //    try { dl.SelectedValue = _sl; }
        //    catch { }
        //}

        ////计算时间间隔
        //public static int DateDiff(string _s, DateTime _d1, DateTime _d2)
        //{
        //    switch (_s)
        //    {
        //        case "m":
        //            return (_d2.Year - _d1.Year) * 12 + _d2.Month - _d1.Month;
        //            break;
        //        case "y":
        //            return _d2.Year - _d1.Year;
        //            break;
        //        case "d":
        //            return ((TimeSpan)_d2.Subtract(_d1)).Days;
        //            break;
        //        default:
        //            return 0;
        //            break;
        //    }
        //}

        /*
        //取得邮件发送SMTP服务器
        public static string getsmtp()
        {
            return ConfigurationManager.AppSettings["smtp"].ToString();
        }
        //取得发送邮件名
        public static string getemail()
        {
            return ConfigurationManager.AppSettings["email"].ToString() ;
        }
        //取得发送邮件用户名
        public static string getemailusername()
        {
            return ConfigurationManager.AppSettings["emailusername"].ToString();
        }
        //取得发送邮件密码
        public static string getemailpassword()
        {
            return ConfigurationManager.AppSettings["emailpassword"].ToString();
        }*/


        // 判断两个时间的差异 songxb 20090423
        public static int TDateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            //string dateDiff = null;

            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            //dateDiff = ts.Days.ToString() + "天"
            //    + ts.Hours.ToString() + "小时"
            //    + ts.Minutes.ToString() + "分钟"
            //    + ts.Seconds.ToString() + "秒";

            return ts.Days;
        }

        // 通过页面导出EXCEL   songxb 2009-4-14
        public static void CreateExcel(DataTable ds, string FileName)
        {
            HttpResponse resp;
            resp = HttpContext.Current.Response;
            resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            resp.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
            string colHeaders = "", ls_item = "";

            //定义表对象与行对象，同时用DataSet对其值进行初始化 
            DataTable dt = ds;//ds.Tables[0];
            DataRow[] myRow = dt.Select();//可以类似dt.Select("id>10")之形式达到数据筛选目的
            int i = 0;
            int cl = dt.Columns.Count;


            //取得数据表各列标题，各标题之间以\t分割，最后一个列标题后加回车符 
            for (i = 0; i < cl; i++)
            {
                if (i == (cl - 1))//最后一列，加\n
                {
                    colHeaders += dt.Columns[i].Caption.ToString() + "\n";
                }
                else
                {
                    colHeaders += dt.Columns[i].Caption.ToString() + "\t";
                }

            }
            resp.Write(colHeaders);
            //向HTTP输出流中写入取得的数据信息 

            //逐行处理数据   
            foreach (DataRow row in myRow)
            {
                //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据     
                for (i = 0; i < cl; i++)
                {
                    if (i == (cl - 1))//最后一列，加\n
                    {
                        ls_item += row[i].ToString().Trim().Replace(' ', '|') + "\n";
                    }
                    else
                    {
                        ls_item += row[i].ToString().Trim().Replace(' ', '|') + "\t";
                    }

                }
                resp.Write(ls_item);
                ls_item = "";

            }
            resp.End();
        }

        // 通过控件成EXCEL文件  2009-04-29
        public static void ToExcel(Control ctl, string FileName)
        {
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + "" + FileName);
            ctl.Page.EnableViewState = false;
            System.IO.StringWriter tw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            ctl.RenderControl(hw);
            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.End();
        }

        //合并单元格
        public static void GroupRows(GridView gv, int cellNum)
        {
            int i = 0, rowSpanNum = 1;
            while (i < gv.Rows.Count - 1)
            {
                GridViewRow gvr = gv.Rows[i];
                for (++i; i < gv.Rows.Count; i++)
                {
                    GridViewRow gvrNext = gv.Rows[i];
                    if (gvr.Cells[cellNum].Text == gvrNext.Cells[cellNum].Text)
                    {
                        gvrNext.Cells[cellNum].Visible = false;
                        rowSpanNum++;
                    }
                    else
                    {
                        gvr.Cells[cellNum].RowSpan = rowSpanNum;
                        rowSpanNum = 1;
                        break;
                    }

                    if (i == gv.Rows.Count - 1)
                    {
                        gvr.Cells[cellNum].RowSpan = rowSpanNum;
                    }
                }
            }
        }


        public static bool checkIsInt(string key)
        {
            bool j = true;
            int i;
            try
            {
                i = Convert.ToInt32(key);
            }
            catch { j = false; }
            return j;
        }
        /// <summary>
        /// 返回当前应用程序的根路径
        /// </summary>
        /// <returns></returns>
        public static string getApplicationPath()
        {
            string str = HttpContext.Current.Request.ApplicationPath.ToString();
            if (str == "/")
                return "";
            else
                return str;
        }
    }
}
