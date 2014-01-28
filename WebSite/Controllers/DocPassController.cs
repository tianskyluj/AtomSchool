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
    public class DocPassController : Controller
    {
        public IDocPassManager DocPassManager { get; set; }
        public IDocReceiveUserRelationManager DocReceiveUserRelationManager { get; set; }
        public IUserInfoManager UserInfoManager { set; get; }
        public IUploadFileManager UploadFileManager { get; set; }

        //
        // GET: /SystemModel/

        [AtomAuthAttribute(RightName = "查看", PageURL = "/DocPass/NewPass")]
        public ActionResult NewPass()
        {
            ViewData["UserInfo"] = UserInfoManager.LoadAll();
            return View("NewPass");
        }

        [AtomAuthAttribute(RightName = "查看", PageURL = "/DocPass/MyDoc")]
        public ActionResult MyDoc()
        {
            Guid userId = UserInfoManager.GetUserSession().ID;
            ViewData["MyDoc"] = DocPassManager.LoadAll().Where(f => f.SendUser.ID == userId);
            ViewData["ReceiveUserRelation"] = DocReceiveUserRelationManager.LoadAll().Where(f => f.DocPass.SendUser.ID == userId);
            return View("MyDoc");
        }

        [AtomAuthAttribute(RightName = "查看", PageURL = "/DocPass/MyPass")]
        public ActionResult MyPass()
        {
            Guid userId = UserInfoManager.GetUserSession().ID;
            ViewData["ReceiveUserRelation"] = DocReceiveUserRelationManager.LoadAll().Where(f => f.ReceiveUser.ID == userId);
            return View("MyPass");
        }

        /// <summary>
        /// 保存或者更新系统模块v
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AtomAuthAttribute(RightName = "添加", PageURL = "/DocPass/NewPass")]
        public ActionResult SavePass(DocPass docPass, string receiveUsers, string uploadString)
        {
            if (docPass.ID == new Guid())
                docPass.ID = Guid.NewGuid();
            docPass.CreateTime = DateTime.Now;
            docPass.SendUser = UserInfoManager.GetUserSession();
            DocPassManager.SaveOrUpdate(docPass);

            // 初始化邮件和收件人的关系
            DocReceiveUserRelationManager.InitDocPassReceiveUserRelation(docPass);

            string[] receiveStrs = receiveUsers.Trim(',').Split(',');
            for (int i = 0; i < receiveStrs.Length; i++)
            {
                Guid reveiveID = new Guid(receiveStrs[i].ToString());
                DocReceiveUserRelation entity = new DocReceiveUserRelation();
                entity.ID = Guid.NewGuid();
                entity.ReceiveUser = UserInfoManager.Get(reveiveID);
                entity.DocPass = docPass;
                entity.State = 0;
                entity.IsRead = false;
                entity.IsReadStateName = "未阅读";
                entity.ReadTime = DateTime.Now;
                if (entity.ReceiveUser == null)
                {}
                DocReceiveUserRelationManager.Save(entity);
            }

            #region 设置上传附件的BaseID
            if (uploadString.Trim().Length > 0)
            {
                // 设置附件的BaseId 
                string[] uploadIDs = uploadString.Trim(',').Split(',');
                for (int i = 0; i < uploadIDs.Length; i++)
                {
                    Guid uploadID = new Guid(uploadIDs[i].ToString());
                    UploadFile uploadFile = UploadFileManager.Get(uploadID);
                    uploadFile.BaseID = docPass.ID;
                    UploadFileManager.Update(uploadFile);
                }
            }
            #endregion

            return Content("1");
        }

        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteTask(Task task)
        {
            //CityManager.Delete(city.ID);
            
            return Content("1");
        }

        /// <summary>
        /// 修改公文传阅，返回待修改公文传阅的相关数据
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AtomAuthAttribute(RightName = "添加", PageURL = "/DocPass/MyDoc")]
        public ActionResult UpdateDocPass(DocPass docPass)
        {
            return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet<DocPass>(DocPassManager.LoadAll().FirstOrDefault(f => f.ID == docPass.ID)));
        }
    }
}
