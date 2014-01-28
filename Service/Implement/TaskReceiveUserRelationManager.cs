using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using System.IO;
using Atom.Common.Sys;
using System.Web;

namespace Service.Implement
{
    public class TaskReceiveUserRelationManager : GenericManagerBase<TaskReceiveUserRelation>, ITaskReceiveUserRelationManager
    {
        /// <summary>
        /// 根据task实例初始化收件人关联关系
        /// </summary>
        /// <param name="email">邮件实例</param>
        public void InitTaskReceiveUserRelation(Task task)
        {
            List<TaskReceiveUserRelation> TaxkReceiveUserList = base.LoadAll().Where(f => f.Task == task).ToList();
            for (int i = 0; i < TaxkReceiveUserList.Count; i++)
            {
                base.Delete(TaxkReceiveUserList[i].ID);
            }
        }

        /// <summary>
        /// 根据任务ID返回用户集合
        /// </summary>
        /// <param name="userID"></param>
        public List<Guid> GetReceiveUserWithTaskID(Task task)
        {
            List<TaskReceiveUserRelation> TaskReceiveUserList = base.LoadAll().Where(f => f.Task.ID == task.ID).ToList();
            List<Guid> receiveList = new List<Guid>();
            for (int i = 0; i < TaskReceiveUserList.Count; i++)
            {
                receiveList.Add(TaskReceiveUserList[i].ReceiveUser.ID);
            }
            return receiveList;
        }

        /// <summary>
        /// 根据用户删除该用户的所有角色关联关系
        /// </summary>
        /// <param name="userEntity"></param>
        public void DeleteWithTask(Task task)
        {
            List<TaskReceiveUserRelation> TaskReceiveUserList = base.LoadAll().Where(f => f.Task.ID == task.ID).ToList();
            for (int i = 0; i < TaskReceiveUserList.Count; i++)
            {
                base.Delete(TaskReceiveUserList[i].ID);
            }
        }
    }
}
