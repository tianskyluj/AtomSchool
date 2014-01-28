using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface IDocReceiveUserRelationManager : IGenericManager<DocReceiveUserRelation>
    {
        /// <summary>
        /// 根据Task实例初始化收件人关联关系
        /// </summary>
        /// <param name="email">邮件实例</param>
        void InitDocPassReceiveUserRelation(DocPass docPass);

        /// <summary>
        /// 根据TaskID返回收件人用户ID集合
        /// </summary>
        /// <param name="userID"></param>
        List<Guid> GetReceiveUserWithDocPassID(DocPass docPass);

        /// <summary>
        /// 根据Task删除该邮件的所有收件人关联关系
        /// </summary>
        /// <param name="userEntity"></param>
        void DeleteWithDocPass(DocPass docPass);
    }
}
