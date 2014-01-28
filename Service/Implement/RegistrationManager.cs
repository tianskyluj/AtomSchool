using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service.Implement
{
    public class RegistrationManager : GenericManagerBase<Registration>, IRegistrationManager
    {
        /// <summary>
        /// 返回某天的签到信息
        /// </summary>
        public Registration GetDayRegistration(Guid userId, int year, int month, int day)
        {
            return  ((Dao.IRegistrationRepository)(this.CurrentRepository)).GetNowdysData(userId, year, month, day);
        }

        /// <summary>
        /// 添加一条新的签到信息
        /// </summary>
        public void AddRegistration(Guid userId)
        {
            Registration RegistrationObj = new Registration();
            RegistrationObj.ID = Guid.NewGuid();
            RegistrationObj.UserId = userId;
            RegistrationObj.UserName = "";
            RegistrationObj.RegistrationStartTime = DateTime.Now;
            RegistrationObj.RegistrationEndTime = DateTime.Now;
            RegistrationObj.WorkTimeSpan = 0;
            base.Save(RegistrationObj);
        }

        /// <summary>
        /// 修改某条签到信息
        /// </summary>
        public void UpdateRegistration(Registration RegistrationObj)
        {
            RegistrationObj.RegistrationEndTime = DateTime.Now;
            RegistrationObj.WorkTimeSpan = ((TimeSpan)(RegistrationObj.RegistrationEndTime - RegistrationObj.RegistrationStartTime)).TotalMinutes / 60;
            base.Update(RegistrationObj);
        }
    }
}
