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
    public class UserInfoManager : GenericManagerBase<UserInfo>, IUserInfoManager
    {
        public IList<UserInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            return ((Dao.IUserInfoRepository)(this.CurrentRepository))
                .LoadAllByPage(out total, page, rows, order, sort).ToList();
        }

        /// <summary>
        /// 判断是否登录
        /// </summary>
        /// <returns></returns>
        public bool IfLogOn()
        {
            if (Atom.Common.DataSession.getSessionValue("userInfo") != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public void LogOut()
        {
            Atom.Common.DataSession.destroySession();
        }

        /// <summary>
        /// 将用户资料存储在session中
        /// </summary>
        /// <param name="user"></param>
        public void SetUserSession(UserInfo user)
        {
            Atom.Common.DataSession.setSession("userInfo", user);
        }

        /// <summary>
        /// 从session中获取登录用户资料
        /// </summary>
        /// <returns></returns>
        public UserInfo GetUserSession()
        {
            return (UserInfo)Atom.Common.DataSession.getSessionValue("userInfo");
        }

        /// <summary>
        /// 检测用户能否登录
        /// </summary>
        /// <returns></returns>
        public bool DoLogOn(UserInfo user)
        {
            UserInfo entity = this.Get(user.Account, user.Password);
            if (entity == null)
                return false;
            else
            {
                this.SetUserSession(entity);
                return true;
            }
        }

        /// <summary>
        /// 获取MD5值
        /// </summary>
        /// <param name="key">加密的字符串</param>
        /// <returns>返回MD5值</returns>
        private string HashCode(string key)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key, "MD5");
        }

        public override object Save(UserInfo entity)
        {
            entity.Password = this.HashCode(entity.Account.ToUpper() + "123456" + entity.CreateTime.ToLongDateString());
            return base.Save(entity);
        }

        public UserInfo Get(string account)
        {
            return ((Dao.IUserInfoRepository)(this.CurrentRepository)).Get(account);
        }

        public UserInfo Get(string account, string password)
        {
            var entity = ((Dao.IUserInfoRepository)(this.CurrentRepository)).Get(account);

            if (entity != null)
            {
                if (entity.Password !=
                        this.HashCode(entity.Account.ToUpper() + password 
                            + entity.CreateTime.ToLongDateString()))
                {
                    return null;
                }
            }

            return entity;
        }

        /// <summary>
        /// 判断提交的密码是否是当前用户的密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsCorrectPassword(string password)
        {
            if (this.GetUserSession().Password == this.HashCode(this.GetUserSession().Account.ToUpper() + password + this.GetUserSession().CreateTime.ToLongDateString()))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="password"></param>
        public void Update(UserInfo entity, string password)
        {
            entity.Password = this.HashCode(entity.Account.ToUpper() + password + entity.CreateTime.ToLongDateString());
            base.Update(entity);
        }

        /// <summary>
        /// 上传用户头像图片
        /// </summary>
        public void UploadAvatar(string avatar)
        {
            string fileUrl = Atom.Common.inc.getApplicationPath() + "/Upload/Avatar/" + this.GetUserSession().ID.ToString() + "_avatar.txt";
            StreamWriter sw;
            sw = File.CreateText(HttpContext.Current.Server.MapPath(fileUrl));
            sw.Write(avatar);
            sw.Close();
            sw.Dispose();
        }

        /// <summary>
        /// 获取当前用户头像
        /// </summary>
        /// <returns></returns>
        public string GetUserAvatar()
        {
            string fileUrl = Atom.Common.inc.getApplicationPath() + "/Upload/Avatar/" + this.GetUserSession().ID.ToString() + "_avatar.txt";
            string avatarString = "";

            StreamReader sr;
            if (System.IO.File.Exists(SysHelper.GetPath(fileUrl)))
            {
                sr = System.IO.File.OpenText(SysHelper.GetPath(fileUrl));
                avatarString = sr.ReadLine();
                sr.Close();
                sr.Dispose();
            }
            if (avatarString == "")
                avatarString = Atom.Common.inc.getApplicationPath() + "/Upload/Avatar/DefaultAvatar.jpg";

            return avatarString;
        }

        /// <summary>
        /// 获取指定用户头像
        /// </summary>
        /// <returns></returns>
        public string GetUserAvatar(string userId)
        {
            string fileUrl = Atom.Common.inc.getApplicationPath() + "/Upload/Avatar/" + userId.Trim() + "_avatar.txt";
            string avatarString = "";

            StreamReader sr;
            if (System.IO.File.Exists(SysHelper.GetPath(fileUrl)))
            {
                sr = System.IO.File.OpenText(SysHelper.GetPath(fileUrl));
                avatarString = sr.ReadLine();
                sr.Close();
                sr.Dispose();
            }

            return avatarString;
        }
    }
}
