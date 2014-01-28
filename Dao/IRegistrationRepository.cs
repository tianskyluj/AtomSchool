using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Dao
{
    public interface IRegistrationRepository : IRepository<Registration>
    {
        Registration GetNowdysData(Guid userId, int year, int month, int day);
    }
}
