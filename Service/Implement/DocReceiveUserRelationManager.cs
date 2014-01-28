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
    public class DocReceiveUserRelationManager : GenericManagerBase<DocReceiveUserRelation>, IDocReceiveUserRelationManager
    {
        /// <summary>
        /// 根据task实例初始化收件人关联关系
        /// </summary>
        /// <param name="email">邮件实例</param>
        public void InitDocPassReceiveUserRelation(DocPass docPass)
        {
            List<DocReceiveUserRelation> DocReceiveUserList = base.LoadAll().Where(f => f.DocPass == docPass).ToList();
            for (int i = 0; i < DocReceiveUserList.Count; i++)
            {
                base.Delete(DocReceiveUserList[i].ID);
            }
        }

        /// <summary>
        /// 根据任务ID返回用户集合
        /// </summary>
        /// <param name="userID"></param>
        public List<Guid> GetReceiveUserWithDocPassID(DocPass docPass)
        {
            List<DocReceiveUserRelation> DocReceiveUserList = base.LoadAll().Where(f => f.DocPass.ID == docPass.ID).ToList();
            List<Guid> receiveList = new List<Guid>();
            for (int i = 0; i < DocReceiveUserList.Count; i++)
            {
                receiveList.Add(DocReceiveUserList[i].ReceiveUser.ID);
            }
            return receiveList;
        }

        /// <summary>
        /// 根据用户删除该用户的所有角色关联关系
        /// </summary>
        /// <param name="userEntity"></param>
        public void DeleteWithDocPass(DocPass docPass)
        {
            List<DocReceiveUserRelation> DocReceiveUserList = base.LoadAll().Where(f => f.DocPass.ID == docPass.ID).ToList();
            for (int i = 0; i < DocReceiveUserList.Count; i++)
            {
                base.Delete(DocReceiveUserList[i].ID);
            }
        }
    }
}
