using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface IEmailReceiveUserRelationManager : IGenericManager<EmailReceiveUserRelation>
    {
        /// <summary>
        /// 根据email实例初始化收件人关联关系
        /// </summary>
        /// <param name="email">邮件实例</param>
        void InitEmailReceiveUserRelation(Email email);

        /// <summary>
        /// 根据邮件ID返回收件人用户ID集合
        /// </summary>
        /// <param name="userID"></param>
        List<Guid> GetReceiveUserWithEmailID(Email email);

         /// <summary>
        /// 根据邮件删除该邮件的所有收件人关联关系
        /// </summary>
        /// <param name="userEntity"></param>
        void DeleteWithEmail(Email email);
    }
}
