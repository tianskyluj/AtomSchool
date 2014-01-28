using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface IUserInfoManager : IGenericManager<UserInfo>
    {
        IList<UserInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort);

        /// <summary>
        /// 根据用户名读取用户实例
        /// </summary>
        /// <param name="account">用户名</param>
        /// <returns></returns>
        UserInfo Get(string account);

        /// <summary>
        /// 根据用户名和密码读取用户实例
        /// </summary>
        /// <param name="account">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        UserInfo Get(string account, string password);

        /// <summary>
        /// 更新用户实例的密码
        /// </summary>
        /// <param name="entity">用户实例</param>
        /// <param name="password">密码</param>
        void Update(UserInfo entity, string password);

        /// <summary>
        /// 从session中获取登录用户资料
        /// </summary>
        /// <returns></returns>
        UserInfo GetUserSession();

        /// <summary>
        /// 从session中获取登录用户资料
        /// </summary>
        /// <returns></returns>
        void SetUserSession(UserInfo user);

        /// <summary>
        /// 用户登录操作
        /// </summary>
        /// <returns></returns>
        bool DoLogOn(UserInfo user);

        /// <summary>
        /// 判断是否登录
        /// </summary>
        /// <returns></returns>
        bool IfLogOn();

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        void LogOut();

        /// <summary>
        /// 获取当前用户头像
        /// </summary>
        /// <returns></returns>
        string GetUserAvatar();

        /// <summary>
        /// 获取指定用户头像
        /// </summary>
        /// <returns></returns>
        string GetUserAvatar(string userId);

        /// <summary>
        /// 获取指定用户头像
        /// </summary>
        /// <returns></returns>
        void UploadAvatar(string avatar);

        /// <summary>
        /// 判断提交的密码是否是当前用户的密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        bool IsCorrectPassword(string password);
    }
}
