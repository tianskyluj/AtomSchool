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
    public class RoleUserManager : GenericManagerBase<RoleUser>, IRoleUserManager 
    {
        /// <summary>
        /// 初始化角色用户关系
        /// </summary>
        public void InitRoleUserRelateion(UserInfo userEntity)
        {
            List<RoleUser> roleUserList = base.LoadAll().Where(f=>f.User==userEntity).ToList();
            for(int i=0;i<roleUserList.Count;i++)
            {
                base.Delete(roleUserList[i].ID);
            }
        }

        /// <summary>
        /// 根据用户ID返回角色ID集合
        /// </summary>
        /// <param name="userID"></param>
        public List<Guid> GetRolesWithUserID(UserInfo userEntity)
        {
            List<RoleUser> roleUserList = base.LoadAll().Where(f => f.User.ID == userEntity.ID).ToList();
            List<Guid> roleList = new List<Guid>();
            for (int i = 0; i < roleUserList.Count; i++)
            {
                roleList.Add(roleUserList[i].Role.ID);
            }
            return roleList;
        }

        /// <summary>
        /// 根据用户删除该用户的所有角色关联关系
        /// </summary>
        /// <param name="userEntity"></param>
        public void DeleteWithUserInfo(UserInfo userEntity)
        {
            List<RoleUser> roleUserList = base.LoadAll().Where(f => f.User.ID == userEntity.ID).ToList();
            for (int i = 0; i < roleUserList.Count; i++)
            {
                base.Delete(roleUserList[i].ID);
            }
        }
    }
}
