using BCS.Directory.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCS.Directory.DAO.Repositories
{
    public class EmployeeSettingsRepository
    : GenericRepository<EmployeeSettings, int>, IEmployeeSettingsRepository
    {
        public EmployeeSettingsRepository(IUnitOfWork unitOfWork)
             : base(unitOfWork)
        {
        }
    }
}
