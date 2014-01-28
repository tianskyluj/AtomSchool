using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace WebSite.Controllers
{
    public class ArticleController : Controller
    {
        public IArticleManager ArticleManager { get; set; }

        public ICategoryManager CategoryManager { get; set; }

        public IForumManager ForumManager { get; set; }

        //
        // GET: /Article/

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Admin(Guid id)
        {
            this.ViewData["entity"] = this.CategoryManager.Get(id);
            return View();
        }

        [Authorize]
        public ActionResult LoadAllByPage(Guid categoryId, int page, int rows, string order, string sort)
        {
            long total = 0;
            var list = this.ArticleManager.LoadAllByPage(out total, categoryId, page, rows, order, sort).Select(entity => new
            {
                entity.Name,
                entity.NameEn,
                entity.ID,
                entity.CreateDate,
                entity.UpdateDate,
                entity.IsEnabled,
                entity.IsFirst,
                entity.ViewCount,
                entity.From,
                CategoryId = entity.Category.ID,
                CategoryName = entity.Category.Name
            });

            var result = new { total = total, rows = list.ToList() };

            return Json(result);
        }

        [Authorize]
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Save(Article entity, Guid categoryId)
        {
            var category = this.CategoryManager.Get(categoryId);
            if (category == null)
            {
                return Json(new
                {
                    IsSuccess = false,
                    Message = "未选择分类，保存失败！"
                }, "text/html", JsonRequestBehavior.AllowGet);
            }

            if (entity.ID == Guid.Empty)
            {
                entity.ID = Guid.NewGuid();
                entity.CreateDate = DateTime.Now;
                entity.UpdateDate = DateTime.Now;
                entity.From = "本站";
                entity.Category = category;
                this.ArticleManager.Save(entity);
            }
            else
            {
                var model = this.ArticleManager.Get(entity.ID);
                model.Name = entity.Name;
                model.NameEn = entity.NameEn;
                model.UpdateDate = DateTime.Now;
                model.IsEnabled = entity.IsEnabled;
                model.Keyword = entity.Keyword;
                model.KeywordEn = entity.KeywordEn;
                model.Content = entity.Content;
                model.ContentEn = entity.ContentEn;
                model.Description = entity.Description;
                model.DescriptionEn = entity.DescriptionEn;
                model.IsFirst = entity.IsFirst;
                model.From = entity.From;
                entity.Category = category;
                this.ArticleManager.Update(model);
            }

            return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult View(Guid? id, Guid categoryId)
        {
            var category = this.CategoryManager.Get(categoryId);
            this.ViewData["Category"] = category;

            Article entity = null;
            if (id != null)
            {
                entity = this.ArticleManager.Get(id.Value);
            }
            entity = entity ?? new Article
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
            this.ArticleManager.Delete(idList.Cast<object>().ToList());
            return Json(new { IsSuccess = true, Message = "删除成功" });
        }

        public ActionResult Get(Guid id)
        {
            var entity = this.ArticleManager.Get(id);
            if (entity == null)
            {
                return Redirect(this.Request.UrlReferrer.ToString());
            }

            var list = this.ForumManager.LoadAllEnable();
            var categoryList = this.CategoryManager.LoadAllEnable(entity.Category.Forum.ID);

            this.ViewData["entity"] = entity;
            this.ViewData["ForumList"] = list;
            this.ViewData["CategoryList"] = categoryList;

            this.ArticleManager.ViewsAdd(id);

            return this.View();
        }
    }
}
