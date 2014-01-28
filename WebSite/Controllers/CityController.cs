using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace WebSite.Controllers
{
    public class CityController : Controller
    {
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
        public ActionResult SaveCity(City city,Guid provinceId)
        {
            if (city.ID == new Guid())
                city.ID = Guid.NewGuid();
            city.Province = ProvinceManager.Get(provinceId);
            CityManager.SaveOrUpdate(city);

            return Content("1");
        }

        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteCity(City city)
        {
            CityManager.Delete(city.ID);
            
            return Content("1");
        }

        /// <summary>
        /// 修改模块，返回待修改模块的相关数据
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateCity(City city)
        {
            return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet<City>(CityManager.LoadAll().FirstOrDefault(f => f.ID == city.ID)));
        }
    }
}
