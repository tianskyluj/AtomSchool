using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace WebSite.Controllers
{
    public class RegionController : Controller
    {
        public IRegionManager RegionManager { get; set; }
        public ICityManager CityManager { get; set; }
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
        public ActionResult SaveRegion(Region region,Guid provinceId,Guid cityId)
        {
            if (region.ID == new Guid())
                region.ID = Guid.NewGuid();
            region.Province = ProvinceManager.Get(provinceId);
            region.City = CityManager.Get(cityId);
            RegionManager.SaveOrUpdate(region);

            return Content("1");
        }

        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteRegion(Region region)
        {
            RegionManager.Delete(region.ID);
            
            return Content("1");
        }

        /// <summary>
        /// 修改模块，返回待修改模块的相关数据
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateRegion(Region region)
        {
            return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet<Region>(RegionManager.LoadAll().FirstOrDefault(f => f.ID == region.ID)));
        }
    }
}
