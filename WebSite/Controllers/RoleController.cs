using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace WebSite.Controllers
{
    public class RoleController : Controller
    {
        public IRoleManager RoleManager { get; set; }
        public IDepartmentManager DepartmentManager { get; set; }

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
        public ActionResult SaveRole(Role role, Guid departmentId)
        {
            if (role.ID == new Guid())
                role.ID = Guid.NewGuid();
            role.Department = DepartmentManager.Get(departmentId);
            RoleManager.SaveOrUpdate(role);

            return Content("1");
        }

        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteRole(Role role)
        {
            RoleManager.Delete(role.ID);
            
            return Content("1");
        }

        /// <summary>
        /// 修改模块，返回待修改模块的相关数据
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateRole(Role role)
        {
            return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet<Role>(RoleManager.LoadAll().FirstOrDefault(f => f.ID == role.ID)));
        }
    }
}
