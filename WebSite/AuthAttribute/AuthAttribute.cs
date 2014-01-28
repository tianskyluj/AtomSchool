using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Spring.Context;
using Spring.Context.Support;
using Service;
using Domain;
using System.Collections;

namespace WebSite.AuthAttribute
{
    /// <summary>
    /// 权限验证
    /// </summary>
    public class AtomAuthAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 权限类型
        /// </summary>
        public string RightName { get; set; }

        /// <summary>
        /// 哪个页面的权限
        /// </summary>
        public string PageURL { get; set; }

        /// <summary>
        /// 验证权限（action执行前会先执行这里）
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            IUserInfoManager UserInfoManager = (IUserInfoManager)cxt.GetObject("Manager.UserInfo");
            IRoleUserManager RoleUserManager = (IRoleUserManager)cxt.GetObject("Manager.RoleUser");
            IRoleRightsManager RoleRightsManager = (IRoleRightsManager)cxt.GetObject("Manager.RoleRights");

            IList<RoleRights> roleRightsList = RoleRightsManager.LoadAll().Where(f => f.SystemModel.Url == PageURL && f.Rights.RightName == RightName).ToList();
            IList<RoleUser> roleUserList = RoleUserManager.LoadAll().Where(f=>f.User.ID == UserInfoManager.GetUserSession().ID).ToList();
            List<Guid> rightsRole = new List<Guid>();
            List<Guid> userRole = new List<Guid>();
            for (int i = 0; i < roleRightsList.Count(); i++)
            {
                rightsRole.Add(roleRightsList[i].Role.ID);
            }
            for (int i = 0; i < roleUserList.Count;i++ )
            {
                userRole.Add(roleUserList[i].Role.ID);
            }
            bool isHaveRights = rightsRole.Intersect(userRole).Count() > 0;

            if (!isHaveRights)
            {
                ContentResult Content = new ContentResult();
                Content.Content = string.Format("<script type='text/javascript'>showError('您没有权限进行该操作！');</script>");
                filterContext.Result = Content;
            }
        }
    }
}