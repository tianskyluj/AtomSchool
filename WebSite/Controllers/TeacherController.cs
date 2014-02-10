using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace WebSite.Controllers
{
    public class TeacherController : Controller
    {
        public ITeacherManager TeacherManager { get; set; }
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
        public ActionResult SaveTeacher(Teacher teacher,string subjectStr)
        {
            if (teacher.ID == new Guid())
                teacher.ID = Guid.NewGuid();
            teacher.Telephone = "";
            teacher.Subject = SubjectManager.Get(new Guid(subjectStr));
            TeacherManager.SaveOrUpdate(teacher);

            return Content("1");
        }

        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteTeacher(Teacher teacher)
        {
            TeacherManager.Delete(teacher.ID);
            
            return Content("1");
        }

        /// <summary>
        /// 修改模块，返回待修改模块的相关数据
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateTeacher(Teacher teacher)
        {
            return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet<Teacher>(TeacherManager.LoadAll().FirstOrDefault(f => f.ID == teacher.ID)));
        }
    }
}
