using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace WebSite.Controllers
{
    public class DepartmentController : Controller
    {
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
        public ActionResult SaveDepartment(Department department)
        {
            if (department.ID == new Guid())
                department.ID = Guid.NewGuid();
            DepartmentManager.SaveOrUpdate(department);

            return Content("1");
        }

        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteDepartment(Department department)
        {
            DepartmentManager.Delete(department.ID);
            
            return Content("1");
        }

        /// <summary>
        /// 修改模块，返回待修改模块的相关数据
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateDepartment(Department department)
        {
            return Content(Atom.Common.JsonHelper.GetJson<Department>(DepartmentManager.LoadAll().FirstOrDefault(f => f.ID == department.ID)));
        }
    }
}
