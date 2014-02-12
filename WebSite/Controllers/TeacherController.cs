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
        public IUserInfoManager UserInfoManager { get; set; }
        public IRoleManager RoleManager { get; set; }
        public IRoleUserManager RoleUserManager { get; set; }

        //
        // GET: /SystemModel/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 保存或者更新教师信息
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveTeacher(Teacher teacher,string subjectStr)
        {
            if ((TeacherManager.LoadAll().Where(f=>f.UserName == teacher.UserName)).Count() > 0)
            {
                return Content("该登陆名已经存在，请更改登陆名称");
            }

            if (teacher.ID == new Guid())
                teacher.ID = Guid.NewGuid();
            teacher.Telephone = "";
            teacher.Subject = SubjectManager.Get(new Guid(subjectStr));
            TeacherManager.SaveOrUpdate(teacher);

            // 把教师添加到登陆账户中去
            UserInfo userInfoEntity = new UserInfo();
            userInfoEntity.Account = teacher.UserName;
            userInfoEntity.Name = teacher.Name;
            userInfoEntity.ID = Guid.NewGuid();
            userInfoEntity.CreateTime = DateTime.Now;
            userInfoEntity.UpdateTime = DateTime.Now;
            userInfoEntity.IsEnabled = true;
            userInfoEntity.IsAdmin = true;
            UserInfoManager.Save(userInfoEntity);

            // 添加新用户的角色为教师
            RoleUser roleUserEntity = new RoleUser();
            roleUserEntity.ID = Guid.NewGuid();
            roleUserEntity.Role = RoleManager.LoadAll().First(f=>f.RoleName == "教师");
            roleUserEntity.User = userInfoEntity;
            RoleUserManager.Save(roleUserEntity);

            return Content("1");
        }

        /// <summary>
        /// 删除教师
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
        /// 修改教师信息，返回待修改教师的相关数据
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
