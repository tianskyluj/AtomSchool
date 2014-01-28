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
    public class ApplyController : Controller
    {
        public IApplyManager ApplyManager { get; set; }
        public IApplyTypeManager ApplyTypeManager { get; set; }
        public IRoleManager RoleManager { get; set; }
        public IUserInfoManager UserInfoManager { get; set; }
        public ICheckLogManager CheckLogManager { get; set; }
        public IRoleUserManager RoleUserManager { get; set; }
        public IUploadFileManager UploadFileManager { get; set; }

        //
        // GET: /SystemModel/

        [AtomAuthAttribute(RightName = "查看", PageURL = "/Apply/NewApply")]
        public ActionResult NewApply()
        {
            ViewData["ApplyType"] = ApplyTypeManager.LoadAll();
            ViewData["Role"] = RoleManager.LoadAll();
            return View("NewApply");
        }

        [AtomAuthAttribute(RightName = "查看", PageURL = "/Apply/MyApply")]
        public ActionResult MyApply()
        {
            ViewData["Checked"] = ApplyManager.LoadAll().Where(f => f.SendUser.ID == UserInfoManager.GetUserSession().ID );
            ViewData["CheckLog"] = CheckLogManager.LoadAll().Where(f => f.Apply.SendUser.ID == UserInfoManager.GetUserSession().ID);
            return View("MyApply");
        }

        [AtomAuthAttribute(RightName = "查看", PageURL = "/Apply/MyCheck")]
        public ActionResult MyCheck()
        {
            ViewData["Role"] = RoleManager.LoadAll();
            ViewData["CheckLog"] = CheckLogManager.LoadAll().Where(f => f.UserInfo.ID == UserInfoManager.GetUserSession().ID && f.CheckStep <= f.Apply.CheckStep);
            return View("MyCheck");
        }

        /// <summary>
        /// 保存或者更新系统模块v
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AtomAuthAttribute(RightName = "添加", PageURL = "/Apply/NewApply")]
        public ActionResult SaveApply(Apply apply, string role, string applyType, string uploadString)
        {
            #region 保存申请
            if (apply.ID == new Guid())
                apply.ID = Guid.NewGuid();
            apply.ApplyType = ApplyTypeManager.Get(new Guid(applyType));
            apply.SendUser = UserInfoManager.GetUserSession();
            apply.CreateTime = DateTime.Now;
            apply.CheckState = 0;
            apply.CheckStep = 0;
            apply.CheckStateName = "待审核";
            ApplyManager.SaveOrUpdate(apply);
            #endregion
            
            #region 保存待审核用户的信息
            // 读取需要进行审核角色的用户
            
            IList<RoleUser> roleUser = RoleUserManager.LoadAll().Where(f => f.Role.ID == new Guid(role)).ToList();
            
            Guid roleId = new Guid(role);
            Role checkRole = RoleManager.Get(roleId);
            if (roleUser.Count ==0)
                return Content("-1");
            for (int i = 0; i < roleUser.Count; i++)
            {
                CheckLog checkLog = new CheckLog();
                checkLog.ID = Guid.NewGuid();
                checkLog.Apply = apply;
                checkLog.CheckState = 0;
                checkLog.CheckStep = 0;
                checkLog.CheckTime = DateTime.Now;
                checkLog.CreateTime = DateTime.Now;
                checkLog.Remark = "";
                checkLog.Role = checkRole;
                checkLog.UserInfo = roleUser[i].User;
                CheckLogManager.Save(checkLog);
            }
            #endregion
            #region 设置之前上传附件的BaseID
            if (uploadString.Trim().Length > 0)
            {
                // 设置附件的BaseId 
                string[] uploadIDs = uploadString.Trim(',').Split(',');
                for (int i = 0; i < uploadIDs.Length; i++)
                {
                    Guid uploadID = new Guid(uploadIDs[i].ToString());
                    UploadFile uploadFile = UploadFileManager.Get(uploadID);
                    uploadFile.BaseID = apply.ID;
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
        public ActionResult DeleteApply(Apply apply)
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
        [AtomAuthAttribute(RightName = "查看", PageURL = "/Apply/MyApply")]
        public ActionResult UpdateApply(Apply apply)
        {
            return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet<Apply>(ApplyManager.LoadAll().FirstOrDefault(f => f.ID == apply.ID)));
        }

        /// <summary>
        /// 获取申请接收信息
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateApplyReceiveInfo(Apply apply)
        {
            IList<CheckLog> checkLogList = CheckLogManager.LoadAll().Where(f => f.Apply.ID == apply.ID).ToList();
            return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet(checkLogList));
        }

        /// <summary>
        /// 根据checklog获取申请单信息
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AtomAuthAttribute(RightName = "查看", PageURL = "/Apply/MyCheck")]
        public ActionResult GetApplyDetailWithChecklogID(CheckLog checklog)
        {
            CheckLog checkLog = CheckLogManager.LoadAll().FirstOrDefault(f => f.ID == checklog.ID);
            return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet(checkLog.Apply));
        }

        /// <summary>
        /// 保存审核信息
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AtomAuthAttribute(RightName = "修改", PageURL = "/Apply/MyCheck")]
        public ActionResult UpdateCheckState(CheckLog checklog)
        {
            bool ifAllChecked = true; // 是否同属该角色的所有用户审核完毕

            CheckLog entity = CheckLogManager.Get(checklog.ID);
            entity.CheckState = checklog.CheckState;
            entity.Remark = checklog.Remark;
            entity.CheckTime = DateTime.Now;
            CheckLogManager.Update(entity);
            if (checklog.CheckState == -1)
            {
                entity.Apply.CheckState = -1;
                entity.Apply.CheckStateName = "退回";
            }
            else
            {
                IList<CheckLog> checklogList = CheckLogManager.LoadAll().Where(f=>f.Apply.ID == entity.Apply.ID && f.CheckStep == entity.CheckStep).ToList();
                IList<CheckLog> nextChecklogList = CheckLogManager.LoadAll().Where(f => f.Apply.ID == entity.Apply.ID && f.CheckStep > entity.CheckStep).ToList();
                for (int i = 0; i < checklogList.Count; i++)
                {
                    if (checklogList[i].CheckState != 1)
                        ifAllChecked = false;
                }
                if (ifAllChecked)
                    entity.Apply.CheckStep++;
                // 如果没有下级审核角色，则设置审核单状态为审核完成
                if (nextChecklogList.Count == 0)
                {
                    entity.Apply.CheckState = 1;
                    entity.Apply.CheckStateName = "审核完成";
                }

            }
            ApplyManager.Update(entity.Apply);
            return Content("1");
        }

        /// <summary>
        /// 提交给下级审核
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AtomAuthAttribute(RightName = "修改", PageURL = "/Apply/MyCheck")]
        public ActionResult CommitNextCheck(CheckLog checklog,string RoleID)
        {
            IList<RoleUser> roleUser = RoleUserManager.LoadAll().Where(f => f.Role.ID == new Guid(RoleID)).ToList();
            CheckLog entity = CheckLogManager.Get(checklog.ID);
            IList<CheckLog> checklogList = CheckLogManager.LoadAll().Where(f=>f.Apply.ID==entity.Apply.ID && 
                                                                            f.CheckStep>entity.CheckStep &&
                                                                            f.Role.ID.ToString()==RoleID
                                                                            ).ToList();
            entity.IsRecommit = true;
            CheckLogManager.Update(entity); // 设置已经提交标记
            int step = entity.CheckStep;
            if (checklogList.Count == 0)    // 如果没有提交过该角色，则提交审核到该角色
            {
                for (int i = 0; i < roleUser.Count; i++)
                {
                    CheckLog newEntity = new CheckLog();
                    newEntity.Apply = entity.Apply;
                    newEntity.CheckState = 0;
                    newEntity.CheckStep = step++;
                    newEntity.ID = Guid.NewGuid();
                    newEntity.Role = roleUser[i].Role;
                    newEntity.UserInfo = roleUser[i].User;
                    newEntity.CreateTime = DateTime.Now;
                    newEntity.CheckTime = DateTime.Now;
                    CheckLogManager.Save(newEntity);
                }
            }
            // 申请单状态设置成待审核
            entity.Apply.CheckState = 0;
            entity.Apply.CheckStateName = "待审核";
            ApplyManager.Update(entity.Apply);

            return Content("1");
        }
    }
}
