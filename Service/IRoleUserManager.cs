using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface IRoleUserManager : IGenericManager<RoleUser>
    {
        /// <summary>
        /// 初始化角色用户关系
        /// </summary>
        void InitRoleUserRelateion(UserInfo userEntity);

        /// <summary>
        /// 根据用户ID返回角色ID集合
        /// </summary>
        /// <param name="userID"></param>
        List<Guid> GetRolesWithUserID(UserInfo userEntity);

        /// <summary>
        /// 根据用户删除该用户的所有角色关联关系
        /// </summary>
        /// <param name="userEntity"></param>
        void DeleteWithUserInfo(UserInfo userEntity);
    }
}
