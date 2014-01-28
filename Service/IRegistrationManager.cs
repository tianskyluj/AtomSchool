using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface IRegistrationManager : IGenericManager<Registration>
    {
        /// <summary>
        /// 返回某天的签到信息
        /// </summary>
        Registration GetDayRegistration(Guid userId, int year, int month, int day);

        /// <summary>
        /// 添加签到信息
        /// </summary>
        /// <param name="userId"></param>
        void AddRegistration(Guid userId);

        /// <summary>
        /// 修改签到信息
        /// </summary>
        /// <param name="RegistrationObj"></param>
        void UpdateRegistration(Registration RegistrationObj);
    }
}
