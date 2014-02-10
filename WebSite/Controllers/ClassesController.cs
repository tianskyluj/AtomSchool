using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace WebSite.Controllers
{
    public class ClassesController : Controller
    {
        public IClassesManager ClassesManager { get; set; }

        //
        // GET: /SystemModel/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 保存或者更新科目
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveClass(Classes classes)
        {
            if (classes.ID == new Guid())
                classes.ID = Guid.NewGuid();
            ClassesManager.SaveOrUpdate(classes);

            return Content("1");
        }

        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteClass(Classes classes)
        {
            ClassesManager.Delete(classes.ID);
            
            return Content("1");
        }

        /// <summary>
        /// 修改模块，返回待修改模块的相关数据
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateClass(Classes classes)
        {
            return Content(Atom.Common.JsonHelper.GetJson<Classes>(ClassesManager.LoadAll().FirstOrDefault(f => f.ID == classes.ID)));
        }
    }
}
