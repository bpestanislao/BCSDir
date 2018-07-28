using BCS.Directory.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCS.Directory.DAO.Repositories
{
    public interface IEmployeeRepository
     : IGenericRepository<Employee, int>
    {
    }
}
