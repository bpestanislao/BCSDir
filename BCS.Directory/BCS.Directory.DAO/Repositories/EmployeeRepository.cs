using BCS.Directory.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCS.Directory.DAO.Repositories
{
    public class EmployeeRepository
   : GenericRepository<Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork unitOfWork)
             : base(unitOfWork)
        {
        }      
    }
}
