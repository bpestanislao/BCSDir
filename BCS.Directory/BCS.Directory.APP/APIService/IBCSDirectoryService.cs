using BCS.Directory.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCS.Directory.APP.APIService
{
    public interface IBCSDirectoryService
    {
        APIResponse AddEmployee(Employee employee);
        List<Country> GetCountry();
    }
}
