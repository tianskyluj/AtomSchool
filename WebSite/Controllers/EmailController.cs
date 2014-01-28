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
    public class EmailController : Controller
    {
        public IEmailManager EmailManager { get; set; }
        public IUserInfoManager UserInfoManager { get; set; }
        public IEmailReceiveUserRelationManager EmailReceiveUserRelationManager { get; set; }
        public IUploadFileManager UploadFileManager { get; set; }

        //
        // GET: /SystemModel/
        [AtomAuthAttribute(RightName = "查看", PageURL = "/Email/NewEmail")]
        public ActionResult NewEmail(string replyEmailID)
        {
            ViewData["UserInfo"] = UserInfoManager.LoadAll();
            return View();
        }

        [AtomAuthAttribute(RightName = "查看", PageURL = "/Email/Inbox")]
        public ActionResult Inbox()
        {
            ViewData["UserInfo"] = UserInfoManager.LoadAll();
            ViewData["EmailReceiveUserRelation"] = EmailReceiveUserRelationManager.LoadAll().Where(f=>f.ReceiveUser.ID == UserInfoManager.GetUserSession().ID);
            return View("Inbox");
        }

        [AtomAuthAttribute(RightName = "查看", PageURL = "/Email/Sentbox")]
        public ActionResult Sentbox()
        {
            ViewData["UserInfo"] = UserInfoManager.LoadAll();
            ViewData["EmailReceiveUserRelation"] = EmailReceiveUserRelationManager.LoadAll().Where(f => f.Email.SendUser.ID == UserInfoManager.GetUserSession().ID);
            ViewData["Email"] = EmailManager.LoadAll().Where(f => f.SendUser.ID == UserInfoManager.GetUserSession().ID);
            return View("Sentbox");
        }

        /// <summary>
        /// 保存或者更新系统模块v
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AtomAuthAttribute(RightName = "添加", PageURL = "/Email/NewEmail")]
        public ActionResult SaveEmail(Email email, string receiveUsers, string uploadString)
        {
            if (email.ID == new Guid())
                email.ID = Guid.NewGuid();
            email.CreateTime = DateTime.Now;
            email.SendTime = DateTime.Now;
            email.SendUser = UserInfoManager.GetUserSession();
            EmailManager.SaveOrUpdate(email);

            // 初始化邮件和收件人的关系
            EmailReceiveUserRelationManager.InitEmailReceiveUserRelation(email);

            string[] receiveStrs = receiveUsers.Trim(',').Split(',');
            for (int i = 0; i < receiveStrs.Length; i++)
            {
                Guid reveiveID = new Guid(receiveStrs[i].ToString());
                EmailReceiveUserRelation entity = new EmailReceiveUserRelation();
                entity.ID = Guid.NewGuid();
                entity.ReceiveUser = UserInfoManager.Get(reveiveID);
                entity.Email = email;
                entity.IsDeleteFromInBox = false;
                entity.IsRead = false;
                entity.IsReadStateName = "未读邮件";
                if (entity.ReceiveUser == null)
                {}
                EmailReceiveUserRelationManager.Save(entity);
            }
            if (uploadString.Trim().Length > 0)
            {
                // 设置附件的BaseId 
                string[] uploadIDs = uploadString.Trim(',').Split(',');
                for (int i = 0; i < uploadIDs.Length; i++)
                {
                    Guid uploadID = new Guid(uploadIDs[i].ToString());
                    UploadFile uploadFile = UploadFileManager.Get(uploadID);
                    uploadFile.BaseID = email.ID;
                    UploadFileManager.Update(uploadFile);
                }
            }

            return Content("1");
        }

        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AtomAuthAttribute(RightName = "删除", PageURL = "/Email/Inbox")]
        public ActionResult DeleteEmail(Email email)
        {
            //CityManager.Delete(city.ID);
            
            return Content("1");
        }

        /// <summary>
        /// 修改模块，返回待修改模块的相关数据
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AtomAuthAttribute(RightName = "查看", PageURL = "/Email/Inbox")]
        public ActionResult UpdateEmail(Email email)
        {
            Email entity = EmailManager.LoadAll().FirstOrDefault(f => f.ID == email.ID);
            EmailReceiveUserRelation emailReceiveRelation = EmailReceiveUserRelationManager.LoadAll().FirstOrDefault(f=>f.Email.ID==email.ID && f.ReceiveUser.ID == UserInfoManager.GetUserSession().ID);
            if (emailReceiveRelation != null)
            {
                emailReceiveRelation.IsRead = true;
                emailReceiveRelation.IsReadStateName = "已经阅读";
                EmailReceiveUserRelationManager.Update(emailReceiveRelation);
            }
            return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet<Email>(entity));
        }

        /// <summary>
        /// 修改模块，返回待修改模块的相关数据
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetReveiveUser(Email email)
        {
            IList<EmailReceiveUserRelation> listEmailReveive =  EmailReceiveUserRelationManager.LoadAll().Where(f=>f.Email.ID==email.ID).ToList();
            return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet(listEmailReveive));
        }
    }
}
