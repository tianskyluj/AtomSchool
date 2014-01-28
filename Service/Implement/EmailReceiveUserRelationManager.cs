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
    public class EmailReceiveUserRelationManager : GenericManagerBase<EmailReceiveUserRelation>, IEmailReceiveUserRelationManager
    {
        /// <summary>
        /// 根据email实例初始化收件人关联关系
        /// </summary>
        /// <param name="email">邮件实例</param>
        public void InitEmailReceiveUserRelation(Email email)
        {
            List<EmailReceiveUserRelation> EmailReceiveUserList = base.LoadAll().Where(f => f.Email == email).ToList();
            for (int i = 0; i < EmailReceiveUserList.Count; i++)
            {
                base.Delete(EmailReceiveUserList[i].ID);
            }
        }

        /// <summary>
        /// 根据用户ID返回角色ID集合
        /// </summary>
        /// <param name="userID"></param>
        public List<Guid> GetReceiveUserWithEmailID(Email email)
        {
            List<EmailReceiveUserRelation> EmailReceiveUserList = base.LoadAll().Where(f => f.Email.ID == email.ID).ToList();
            List<Guid> receiveList = new List<Guid>();
            for (int i = 0; i < EmailReceiveUserList.Count; i++)
            {
                receiveList.Add(EmailReceiveUserList[i].ReceiveUser.ID);
            }
            return receiveList;
        }

        /// <summary>
        /// 根据用户删除该用户的所有角色关联关系
        /// </summary>
        /// <param name="userEntity"></param>
        public void DeleteWithEmail(Email email)
        {
            List<EmailReceiveUserRelation> EmailReceiveUserList = base.LoadAll().Where(f => f.Email.ID == email.ID).ToList();
            for (int i = 0; i < EmailReceiveUserList.Count; i++)
            {
                base.Delete(EmailReceiveUserList[i].ID);
            }
        }
    }
}
