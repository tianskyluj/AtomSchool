using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace WebSite.Controllers
{
    public class RightsController : Controller
    {
        public IRightsManager RightsManager { get; set; }
        public IRoleRightsManager RoleRightsManager { get; set; }
        public IUserInfoManager UserInfoManager { get; set; }
        public IRoleManager RoleManager { get; set; }
        public ISystemModelManager SystemModelManager { get; set; }

        //
        // GET: /SystemModel/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 保存或者更新系统模块v
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveRights(string modelID,string rightsSTR,string roleID)
        {
            // 删除该角色的该model全部权限
            IList<RoleRights> roleRightList = RoleRightsManager.LoadAll().Where(f=>f.Role.ID == new Guid(roleID) && f.SystemModel.ID==new Guid(modelID)).ToList();
            for (int i = 0; i < roleRightList.Count; i++)
            {
                RoleRightsManager.Delete(roleRightList[i].ID);
            }
            // 添加权限
            string[] rightsList = rightsSTR.Trim(',').Split(',');
            for (int i = 0; i < rightsList.Length; i++)
            {
                if (rightsList[i].ToString() != "")
                {
                    RoleRights entity = new RoleRights();
                    entity.ID = Guid.NewGuid();
                    entity.Rights = RightsManager.Get(new Guid(rightsList[i].ToString()));
                    entity.Role = RoleManager.Get(new Guid(roleID.Trim()));
                    entity.SystemModel = SystemModelManager.Get(new Guid(modelID));
                    RoleRightsManager.Save(entity);
                }
            }

            return Content("1");
        }

        /// <summary>
        /// 根据用户所选角色ID显示页面权限
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetRghtWithRoleID(Role role)
        {
            return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet<IList<RoleRights>>(RoleRightsManager.LoadAll().Where(f => f.Role.ID == role.ID).ToList()));
        }
    }
}
