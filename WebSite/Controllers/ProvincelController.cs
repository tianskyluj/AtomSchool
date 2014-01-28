using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace WebSite.Controllers
{
    public class ProvinceController : Controller
    {
        public IProvinceManager ProvinceManager { get; set; }

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
        public ActionResult SaveProvince(Province province)
        {
            if (province.ID == new Guid())
                province.ID = Guid.NewGuid();
            ProvinceManager.SaveOrUpdate(province);

            return Content("1");
        }

        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteProvince(Province province)
        {
            ProvinceManager.Delete(province.ID);
            
            return Content("1");
        }

        /// <summary>
        /// 修改模块，返回待修改模块的相关数据
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateProvince(Province province)
        {
            return Content(Atom.Common.JsonHelper.GetJson<Province>(ProvinceManager.LoadAll().FirstOrDefault(f=>f.ID==province.ID)));
        }
    }
}
