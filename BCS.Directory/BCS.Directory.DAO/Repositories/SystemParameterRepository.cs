using BCS.Directory.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCS.Directory.DAO.Repositories
{
    public class SystemParameterRepository
   : GenericRepository<SystemParameter, int>, ISystemParameterRepository
    {
        public SystemParameterRepository(IUnitOfWork unitOfWork)
             : base(unitOfWork)
        {
        }
    }
}
