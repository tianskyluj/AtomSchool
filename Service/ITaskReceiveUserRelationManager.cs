using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface ITaskReceiveUserRelationManager : IGenericManager<TaskReceiveUserRelation>
    {
        /// <summary>
        /// 根据Task实例初始化收件人关联关系
        /// </summary>
        /// <param name="email">邮件实例</param>
        void InitTaskReceiveUserRelation(Task task);

        /// <summary>
        /// 根据TaskID返回收件人用户ID集合
        /// </summary>
        /// <param name="userID"></param>
        List<Guid> GetReceiveUserWithTaskID(Task task);

         /// <summary>
        /// 根据Task删除该邮件的所有收件人关联关系
        /// </summary>
        /// <param name="userEntity"></param>
        void DeleteWithTask(Task task);
    }
}
