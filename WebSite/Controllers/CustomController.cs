using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;
using WebSite.AuthAttribute;

namespace WebSite.Controllers
{
    public class CustomController : Controller
    {
        public ICustomManager CustomManager { get; set; }
        public ICustomTypeManager CustomTypeManager { get; set; }
        public IUserInfoManager UserInfoManager { get; set; }
        public ICustomMaintainManager CustomMaintainManager { get; set; }
        public IMaintainMethodManager MaintainMethodManager { get; set; }
        public IMaintainTypeManager MaintainTypeManager { get; set; }
        //
        // GET: /SystemModel/


        [AtomAuthAttribute(RightName = "查看", PageURL = "/Custom/NewCustom")]
        public ActionResult NewCustom()
        {
            if (Request.QueryString["ID"] != null)
            {
                ViewData["CustomID"] = Request.QueryString["ID"].ToString();
                ViewData["Title"] = "修改客户信息";
            }
            else
            {
                ViewData["CustomID"] = "";
                ViewData["Title"] = "添加客户信息";
            }

            ViewData["CustomType"] = CustomTypeManager.LoadAll();
            return View("NewCustom");
        }

        [AtomAuthAttribute(RightName = "查看", PageURL = "/Custom/CustomList")]
        public ActionResult CustomList()
        {
            ViewData["Custom"] = CustomManager.LoadAll();
            return View("CustomList");
        }

        [AtomAuthAttribute(RightName = "查看", PageURL = "/Custom/CustomBirthday")]
        public ActionResult CustomBirthday()
        {
            ViewData["Custom"] = CustomManager.LoadAll().Where(f=>f.Birthday.Month == DateTime.Now.Month);
            return View("CustomBirthday");
        }

        [AtomAuthAttribute(RightName = "查看", PageURL = "/Custom/NewActive")]
        public ActionResult NewActive()
        {
            ViewData["MaintainMethod"] = MaintainMethodManager.LoadAll();
            ViewData["MaintainType"] = MaintainTypeManager.LoadAll();
            ViewData["Custom"] = CustomManager.LoadAll();
            return View("NewActive");
        }

        [AtomAuthAttribute(RightName = "查看", PageURL = "/Custom/ActiveSummary")]
        public ActionResult ActiveSummary()
        {
            ViewData["CustomMaintain"] = CustomMaintainManager.LoadAll();
            return View("ActiveSummary");
        }

        [AtomAuthAttribute(RightName = "查看", PageURL = "/Custom/ActiveWarnning")]
        public ActionResult ActiveWarnning()
        {
            ViewData["CustomMaintain"] = CustomMaintainManager.LoadAll();
            return View("ActiveWarnning");
        }


        /// <summary>
        /// 保存或者更新系统模块v
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AtomAuthAttribute(RightName = "添加", PageURL = "/Custom/NewCustom")]
        public ActionResult SaveCustom(Custom custom,string customType)
        {
            #region 保存申请
            if (custom.ID == new Guid())
            {
                custom.ID = Guid.NewGuid();
                custom.CustomType = CustomTypeManager.Get(new Guid(customType));
                custom.CreateUser = UserInfoManager.GetUserSession();
                custom.CreateTime = DateTime.Now;
                CustomManager.SaveOrUpdate(custom);
            }
            else
            {
                Custom entity = CustomManager.Get(custom.ID);
                entity.CustomType = CustomTypeManager.Get(new Guid(customType));
                entity.Birthday = custom.Birthday;
                entity.Name = custom.Name;
                entity.Remark = custom.Remark;
                CustomManager.SaveOrUpdate(entity);
            }


            
            #endregion
            
            return Content("1");
        }

        /// <summary>
        /// 保存或者更新系客户维护数据
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        /// 
        [AtomAuthAttribute(RightName = "添加", PageURL = "/Custom/NewActive")]
        [HttpPost]
        public ActionResult SaveMaintain(CustomMaintain customMaintain,
                                         String maintainMethod,
                                         String maintainType,
                                         String custom)
        {
            #region 保存申请
            if (customMaintain.ID == new Guid())
                customMaintain.ID = Guid.NewGuid();
            customMaintain.MaintainMethod = MaintainMethodManager.Get(new Guid(maintainMethod));
            customMaintain.MaintainType = MaintainTypeManager.Get(new Guid(maintainType));
            customMaintain.Custom = CustomManager.Get(new Guid(custom));
            customMaintain.MaintainUser = UserInfoManager.GetUserSession();
            customMaintain.CreateUser = UserInfoManager.GetUserSession();
            customMaintain.CreateTime = DateTime.Now;
            CustomMaintainManager.SaveOrUpdate(customMaintain);
            #endregion

            return Content("1");
        }

        /// <summary>
        /// 删除客户信息
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AtomAuthAttribute(RightName = "删除", PageURL = "/Custom/CustomList")]
        public ActionResult DeleteCustom(Custom custom)
        {
            CustomMaintainManager.DeleteMaintainWithCustom(custom);
            CustomManager.Delete(custom.ID);
            return Content("1");
        }

        /// <summary>
        /// 修改模块，返回待修改模块的相关数据
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AtomAuthAttribute(RightName = "查看", PageURL = "/Custom/CustomList")]
        public ActionResult Update(Custom custom)
        {
            return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet<Custom>(CustomManager.Load(custom.ID)));
        }

        /// <summary>
        /// 修改模块，返回待修改模块的相关数据
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AtomAuthAttribute(RightName = "查看", PageURL = "/Custom/ActiveSummary")]
        public ActionResult GetCustomMaintainDetal(CustomMaintain customMaintain)
        {
            return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet<CustomMaintain>(CustomMaintainManager.Load(customMaintain.ID)));
        }
    }
}
