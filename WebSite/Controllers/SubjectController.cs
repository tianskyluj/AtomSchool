using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace WebSite.Controllers
{
    public class SubjectController : Controller
    {
        public ISubjectManager SubjectManager { get; set; }

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
        public ActionResult SaveSubject(Subject subject)
        {
            if (subject.ID == new Guid())
                subject.ID = Guid.NewGuid();
            SubjectManager.SaveOrUpdate(subject);

            return Content("1");
        }

        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteSubject(Subject subject)
        {
            SubjectManager.Delete(subject.ID);
            
            return Content("1");
        }

        /// <summary>
        /// 修改模块，返回待修改模块的相关数据
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateSubject(Subject subject)
        {
            return Content(Atom.Common.JsonHelper.GetJson<Subject>(SubjectManager.LoadAll().FirstOrDefault(f => f.ID == subject.ID)));
        }
    }
}
