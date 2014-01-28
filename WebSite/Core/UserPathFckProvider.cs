using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MvcFckEditor.Components;

namespace WebSite.Core
{
    /// <summary>
    /// MvcFckEditor的用户文件上传路径
    /// </summary>
    public class UserPathFckProvider : FckProvider
    {
        public override string GetUserFilesPath()
        {
            var path = "/UserFiles/";
            string userPath = null;
            HttpContext context = HttpContext.Current;
            if (context.User != null && context.User.Identity != null 
                && context.User.Identity.IsAuthenticated)
            {
                userPath = path + context.User.Identity.Name;
            }
            else
            {
                userPath = path + "Anonymous";
            }

            //string serverPath = context.Server.MapPath("~" + userPath);
            //if (!System.IO.Directory.Exists(serverPath))
            //{
            //    System.IO.Directory.CreateDirectory(serverPath);
            //}

            return userPath;
        }
    }
}