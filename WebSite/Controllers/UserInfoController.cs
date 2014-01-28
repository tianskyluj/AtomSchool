using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace WebSite.Controllers
{
    public class UserInfoController : Controller
    {
        public IUserInfoManager UserInfoManager { get; set; }
        //
        // GET: /UserInfo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadAllByPage(int page, int rows, string order, string sort)
        {
            long total = 0;
            var list = this.UserInfoManager.LoadAllByPage(out total, page, rows, order, sort);

            var result = new { total = total, rows = list };

            return Json(result);
        }

        public ActionResult Exist(string account)
        {
            var result = this.UserInfoManager.Get(account) != null;
            return Content(result.ToString());
        }

        public ActionResult Save(UserInfo entity)
        {
            if (entity.ID == Guid.Empty)
            {
                entity.ID = Guid.NewGuid();
                entity.CreateTime = DateTime.Now;

                this.UserInfoManager.Save(entity);
            }
            else
            {
                var user = this.UserInfoManager.Get(entity.ID);
                user.Name = entity.Name;
                user.IsEnabled = entity.IsEnabled;
                this.UserInfoManager.Update(user);
            }

            return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        public ActionResult View(Guid? id)
        {
            UserInfo entity = null;
            if (id != null)
            {
                entity = this.UserInfoManager.Get(id.Value);
            }
            entity = entity ?? new UserInfo
            {
                Account = string.Empty,
                Name = string.Empty,
            };

            this.ViewData["entity"] = entity;
            return View();
        }

        public ActionResult Delete(IList<Guid> idList)
        {
            this.UserInfoManager.Delete(idList.Cast<object>().ToList());
            return Json(new { IsSuccess = true, Message = "删除成功" });
        }
    }
}
