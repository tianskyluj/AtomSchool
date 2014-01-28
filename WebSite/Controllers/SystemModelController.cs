using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace WebSite.Controllers
{
    public class SystemModelController : Controller
    {
        public ISystemModelManager SystemModelManager { get; set; }

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
        public ActionResult SaveSystemModel(SystemModel systemModel)
        {
            SystemModel modelObj = SystemModelManager.LoadAllByName(systemModel.Name);
            modelObj.Name = systemModel.Name;
            modelObj.Url = systemModel.Url;
            modelObj.ParentId = systemModel.ParentId;
            modelObj.IsEnabled = systemModel.IsEnabled;
            SystemModelManager.SaveOrUpdate(modelObj);

            return Content("1");
        }

        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteSystemModel(SystemModel systemModel)
        {
            SystemModel modelObj = SystemModelManager.LoadAllByName(systemModel.Name);
            SystemModelManager.DeleteAllChildrenModel(modelObj.ID);
            SystemModelManager.Delete(modelObj.ID);

            return Content("1");
        }

        /// <summary>
        /// 修改模块，返回待修改模块的相关数据
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateSystemModel(SystemModel systemModel)
        {
            return Content(Atom.Common.JsonHelper.GetJson<SystemModel>(SystemModelManager.LoadAllByName(systemModel.Name)));
        }
    }
}
