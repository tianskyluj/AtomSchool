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
    public class TaskController : Controller
    {
        public ITaskManager TaskManager { get; set; }
        public ITaskStateManager TaskStateManager { get; set; }
        public ITaskLevelManager TaskLevelManager { get; set; }
        public ITaskReceiveUserRelationManager TaskReceiveUserRelationManager { get; set; }
        public IUserInfoManager UserInfoManager { get; set; }

        //
        // GET: /SystemModel/

        [AtomAuthAttribute(RightName = "查看", PageURL = "/Task/NewTask")]
        public ActionResult NewTask()
        {
            ViewData["UserInfo"] = UserInfoManager.LoadAll();
            ViewData["TaskLevel"] = TaskLevelManager.LoadAll(); 
            return View("NewTask");
        }

        [AtomAuthAttribute(RightName = "查看", PageURL = "/Task/MyTask")]
        public ActionResult MyTask()
        {
            ViewData["TaskReceiveUserRelation"] = TaskReceiveUserRelationManager.LoadAll().Where(f => f.ReceiveUser.ID == UserInfoManager.GetUserSession().ID);
            ViewData["TaskState"] = TaskStateManager.LoadAll();
            return View("MyTask");
        }

        [AtomAuthAttribute(RightName = "查看", PageURL = "/Task/AssignedTask")]
        public ActionResult AssignedTask()
        {
            ViewData["Task"] = TaskManager.LoadAll().Where(f=>f.SendUser.ID == UserInfoManager.GetUserSession().ID);
            ViewData["TaskReceiveUserRelation"] = TaskReceiveUserRelationManager.LoadAll();
            ViewData["TaskState"] = TaskStateManager.LoadAll();
            return View("AssignedTask");
        }

        /// <summary>
        /// 保存或者更新系统模块v
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AtomAuthAttribute(RightName = "添加", PageURL = "/Task/NewTask")]
        public ActionResult SaveTask(Task task,string taskLevel, string receiveUsers)
        {
            if (task.ID == new Guid())
                task.ID = Guid.NewGuid();
            task.TaskLevel = TaskLevelManager.Get(new Guid(taskLevel));
            task.CreateTime = DateTime.Now;
            task.SendTime = DateTime.Now;
            task.SendUser = UserInfoManager.GetUserSession();
            TaskManager.SaveOrUpdate(task);

            // 初始化邮件和收件人的关系
            TaskReceiveUserRelationManager.InitTaskReceiveUserRelation(task);

            string[] receiveStrs = receiveUsers.Trim(',').Split(',');
            for (int i = 0; i < receiveStrs.Length; i++)
            {
                Guid reveiveID = new Guid(receiveStrs[i].ToString());
                TaskReceiveUserRelation entity = new TaskReceiveUserRelation();
                entity.ID = Guid.NewGuid();
                entity.ReceiveUser = UserInfoManager.Get(reveiveID);
                entity.Task = task;
                entity.TaskState = TaskStateManager.LoadAll().FirstOrDefault(f=>f.OrderIndex == 0);
                entity.FinishTime = DateTime.Now;
                if (entity.ReceiveUser == null)
                {}
                TaskReceiveUserRelationManager.Save(entity);
            }

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
        /// 修改模块，返回待修改模块的相关数据
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateTask(Task task)
        {
            //return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet<City>(CityManager.LoadAll().FirstOrDefault(f => f.ID == city.ID)));
            return Content("1");
        }

        /// <summary>
        /// 修改模块，返回待修改模块的相关数据
        /// </summary>
        /// <param name="globalModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AtomAuthAttribute(RightName = "查看", PageURL = "/Task/AssignedTask")]
        public ActionResult GetTaskState(TaskReceiveUserRelation taskRelation)
        {
            return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet<TaskReceiveUserRelation>(TaskReceiveUserRelationManager.LoadAll().FirstOrDefault(f => f.ID == taskRelation.ID)));
        }

        /// <summary>
        /// 更新任务状态
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        [AtomAuthAttribute(RightName = "修改", PageURL = "/Task/MyTask")]
        public ActionResult UpdateState(TaskReceiveUserRelation taskRelateion, string TaskStateStr)
        {
            TaskReceiveUserRelation entity = TaskReceiveUserRelationManager.Get(taskRelateion.ID);
            entity.TaskState = TaskStateManager.Get(new Guid(TaskStateStr));
            if (entity.TaskState.StateName == "已完成")
                entity.TaskPercentage = 100;
            else
                entity.TaskPercentage = taskRelateion.TaskPercentage;
            
            entity.FinishTime = DateTime.Now;
            TaskReceiveUserRelationManager.Update(entity);
            
            return Content("1");
        }

        /// <summary>
        /// 根据任务ID获取任务接收人的完成状态信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetTaskStateWithTask(Task task)
        {
            IList<TaskReceiveUserRelation> taskReceiveList = TaskReceiveUserRelationManager.LoadAll().Where(f=>f.Task.ID == task.ID).ToList();
            return Content(Atom.Common.JsonHelper.GenerateStringByJsonDotNet(taskReceiveList));
        }
    }
}
