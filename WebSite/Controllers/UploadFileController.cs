using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace WebSite.Controllers
{
    public class UploadFileController : Controller
    {
        public IUploadFileManager UploadFileManager { get; set; }
        public IUserInfoManager UserInfoManager { get; set; }
        public IDocReceiveUserRelationManager DocReceiveUserRelationManager { get; set; }

        //
        // GET: /SystemModel/


        public ActionResult PDFView()
        {
            
            string baseID = Request.QueryString["baseId"];
            ViewData["PDFs"] = UploadFileManager.LoadAll().Where(f => f.BaseID == new Guid(baseID));

            #region 更新公文传递状态
            DocReceiveUserRelation docUser = DocReceiveUserRelationManager.LoadAll().FirstOrDefault(f => f.DocPass.ID == new Guid(baseID) && f.ReceiveUser.ID==UserInfoManager.GetUserSession().ID);
            docUser.IsRead = true;
            docUser.IsReadStateName = "已阅读";
            DocReceiveUserRelationManager.Update(docUser);
            #endregion

            return View("PDFView");
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(UploadFile uploadFile)
        {
            UploadFileManager.Delete(uploadFile.ID);
            
            return Content("1");
        }
        /// <summary>
        /// 根据baseID返回附件实例类
        /// </summary>
        /// <param name="baseID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetFileWithBaseID(string baseID)
        {
            IList<UploadFile> fileList = UploadFileManager.LoadAll().Where(f=>f.BaseID==new Guid(baseID)).ToList();
            return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet<IList<UploadFile>>(fileList));
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <returns></returns>

        public ActionResult DownLoadFile(string ID)
        {
            Guid uploadID = new Guid(ID);
            UploadFile uploadFile = UploadFileManager.Get(uploadID);
            var path = Server.MapPath(uploadFile.FileURL);
            return File(path, "application/x-zip-compressed", Url.Encode(uploadFile.FileName));
        }

        /// <summary>
        /// 上传附件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase qqfile)
        {
            //return Json(new { success = true });
            UploadFile uploadFile = UploadFileManager.UploadFile(qqfile, UserInfoManager.GetUserSession());
            //return Json(new { success = true });
            return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet<UploadFile>(uploadFile));
        }
    }
}
