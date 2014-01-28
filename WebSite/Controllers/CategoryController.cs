using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace WebSite.Controllers
{
    public class CategoryController : Controller
    {
        public ICategoryManager CategoryManager { get; set; }

        public IForumManager ForumManager { get; set; }

        public IArticleManager ArticleManager { get; set; }
        //
        // GET: /Category/

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult LoadAllByPage(int page, int rows, string order, string sort)
        {
            long total = 0;
            var list = this.CategoryManager.LoadAllByPage(out total, page, rows, order, sort).Select(entity => new
            {
                entity.Name,
                entity.NameEn,
                entity.ID,
                entity.OrderNo,
                entity.IsEnabled,
                ForumName = entity.Forum.Name,
                ForumId = entity.Forum.ID,
                entity.CategoryType
            });

            var result = new { total = total, rows = list.ToList() };

            return Json(result);
        }

        [Authorize]
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Save(Category entity, Guid forumId)
        {
            var forum = this.ForumManager.Get(forumId);
            if (forum == null)
            {
                return Json(new
                {
                    IsSuccess = false,
                    Message = "未选择版块，保存失败！"
                }, "text/html", JsonRequestBehavior.AllowGet);
            }

            if (entity.ID == Guid.Empty)
            {
                entity.ID = Guid.NewGuid();
                entity.Forum = forum;
                this.CategoryManager.Save(entity);
            }
            else
            {
                var model = this.CategoryManager.Get(entity.ID);
                model.Name = entity.Name;
                model.NameEn = entity.NameEn;
                model.OrderNo = entity.OrderNo;
                model.IsEnabled = entity.IsEnabled;
                model.Keyword = entity.Keyword;
                model.KeywordEn = entity.KeywordEn;
                model.CategoryType = entity.CategoryType;
                model.Content = entity.Content;
                model.ContentEn = entity.ContentEn;
                model.Description = entity.Description;
                model.DescriptionEn = entity.DescriptionEn;
                entity.Forum = forum;
                this.CategoryManager.Update(model);
            }

            return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult View(Guid? id)
        {
            var list = this.ForumManager.LoadAllEnable();
            this.ViewData["ForumList"] = list;

            Category entity = null;
            if (id != null)
            {
                entity = this.CategoryManager.Get(id.Value);
            }
            entity = entity ?? new Category
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
            this.CategoryManager.Delete(idList.Cast<object>().ToList());
            return Json(new { IsSuccess = true, Message = "删除成功" });
        }

        public ActionResult List(Guid forumId, Guid? id)
        {
            var forum = this.ForumManager.Get(forumId);
            if (forum == null)
            {
                return Redirect("/Home/Index/");
            }

            Category entity = null;
            if (id.HasValue && id != Guid.Empty)
            {
                entity = this.CategoryManager.Get(id);
            }
            else
            {
                entity = forum.CategoryList.OrderByDescending(o => o.OrderNo).FirstOrDefault(f => f.IsEnabled);
            }
            if (entity == null)
            {
                return Redirect("/Home/Index/");
            }

            var list = this.ForumManager.LoadAllEnable();
            var categoryList = this.CategoryManager.LoadAllEnable(forum.ID);
            var articleList = this.ArticleManager.LoadAllEnable(entity.ID);

            this.ViewData["entity"] = entity;
            this.ViewData["forum"] = forum;
            this.ViewData["CategoryList"] = categoryList;
            this.ViewData["ArticleList"] = articleList;
            this.ViewData["ForumList"] = list;

            return View();
        }
    }
}
