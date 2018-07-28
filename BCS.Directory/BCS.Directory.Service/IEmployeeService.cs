using BCS.Directory.CORE.Entity;
using System;
using System.Collections.Generic;

namespace BCS.Directory.Service
{
    public interface IEmployeeService
    {
        int AddEmployee(Employee employee);
        int UpdateEmployee(Employee employee);
        int DeleteEmployee(Employee employee);
        List<Employee> GetAllActiveEmployees();

        Employee GetEmployeeById(int id);

        string TestEmployee(int id);
    }
}
