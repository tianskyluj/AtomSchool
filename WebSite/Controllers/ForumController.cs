using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace WebSite.Controllers
{
    public class ForumController : Controller
    {
        //
        // GET: /Forum/

        public IForumManager ForumManager { get; set; }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult LoadAllByPage(int page, int rows, string order, string sort)
        {
            long total = 0;
            var list = this.ForumManager.LoadAllByPage(out total, page, rows, order, sort).Select(entity => new 
            {
                entity.Name,
                entity.NameEn,
                entity.ID,
                entity.OrderNo,
                entity.IsEnabled
            });

            var result = new { total = total, rows = list.ToList() };

            return Json(result);
        }

        [Authorize]
        public ActionResult Save(Forum entity)
        {
            if (entity.ID == Guid.Empty)
            {
                entity.ID = Guid.NewGuid();

                this.ForumManager.Save(entity);
            }
            else
            {
                var model = this.ForumManager.Get(entity.ID);
                model.Name = entity.Name;
                model.NameEn = entity.NameEn;
                model.OrderNo = entity.OrderNo;
                model.IsEnabled = entity.IsEnabled;
                this.ForumManager.Update(model);
            }

            return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult View(Guid? id)
        {
            Forum entity = null;
            if (id != null)
            {
                entity = this.ForumManager.Get(id.Value);
            }
            entity = entity ?? new Forum
            {
                Name = string.Empty,
                NameEn = string.Empty,
            };

            this.ViewData["entity"] = entity;
            return View();
        }

        [Authorize]
        public ActionResult Delete(IList<Guid> idList)
        {
            this.ForumManager.Delete(idList.Cast<object>().ToList());
            return Json(new { IsSuccess = true, Message = "删除成功" });
        }
    }
}
