using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using Domain;

namespace Dao.Implement
{
    public class RegistrationRepository : RepositoryBase<Registration>, IRegistrationRepository
    {
        public Registration GetNowdysData(Guid userId, int year, int month, int day)
        {
            return this.LoadAll().FirstOrDefault(f => f.UserId == userId && 
                                                f.RegistrationStartTime.Year==year && 
                                                f.RegistrationStartTime.Month == month && 
                                                f.RegistrationStartTime.Day == day);
        }
    }
}
