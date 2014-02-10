using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace WebSite.Controllers
{
    public class SystemController : Controller
    {
        public IGlobalSettingManager GlobalSettingManager { get; set; }
        public ISystemModelManager SystemModelManager { get; set; }
        public IProvinceManager ProvinceManager { get; set; }
        public ICityManager CityManager { get; set; }
        public IRegionManager RegionManager { get; set; }
        public IDepartmentManager DepartmentManager { get; set; }
        public IRoleManager RoleManager { get; set; }
        public IUserInfoManager UserInfoManager { get; set; }
        public IRightsManager RightsManager { get; set; }
        public IRoleRightsManager RoleRightsManager { get; set; }
        public ISubjectManager SubjectManager { get; set; }
        public IGradeManager GradeManager { get; set; }
        public ITeacherManager TeacherManager { get; set; }
        public IClassesManager ClassesManager { get; set; }

        //
        // GET: /System/

        public ActionResult Index()
        {
            ViewData["companyName"] = GlobalSettingManager.GetGlobalCache().CompanyName;
            ViewData["isProvince"] = GlobalSettingManager.GetGlobalCache().IsProvince;
            ViewData["isCity"] = GlobalSettingManager.GetGlobalCache().IsCity;
            ViewData["isRegion"] = GlobalSettingManager.GetGlobalCache().IsRegion;
            ViewData["isDepartment"] = GlobalSettingManager.GetGlobalCache().IsDepartment;
            ViewData["SystemModel"] = SystemModelManager.LoadAll();
            ViewData["Province"] = ProvinceManager.LoadAll();
            ViewData["City"] = CityManager.LoadAll();
            ViewData["Region"] = RegionManager.LoadAll();
            ViewData["Department"] = DepartmentManager.LoadAll();
            ViewData["Role"] = RoleManager.LoadAll();
            ViewData["SysUser"] = UserInfoManager.LoadAll();
            ViewData["Rights"] = RightsManager.LoadAll();
            ViewData["Subject"] = SubjectManager.LoadAll();
            ViewData["Grade"] = GradeManager.LoadAll();
            ViewData["Teacher"] = TeacherManager.LoadAll();
            ViewData["Class"] = ClassesManager.LoadAll();
            ViewData["NullGuid"] = new Guid();
            return View();
        }

        /// <summary>
        /// 更新全局变量
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateGolbal(GlobalSetting globalModel)
        {
            GlobalSetting entity = GlobalSettingManager.GetGlobalCache();
            globalModel.ID = entity.ID;
            GlobalSettingManager.SaveOrUpdate(globalModel);
            GlobalSettingManager.SetGlobalCache();

            return Content("1");
        }

       
    }
}
