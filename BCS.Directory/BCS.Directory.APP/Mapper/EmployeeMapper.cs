using BCS.Directory.APP.Models.ViewModels;
using BCS.Directory.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCS.Directory.APP.Mapper
{
    public static class EmployeeMapper
    {
        public static Employee Convert(EmployeeViewModel employeeViewModel)
        {
            return new Employee{
                 Age = employeeViewModel.Age,
                 Address = employeeViewModel.Address,
                 Birthdate = employeeViewModel.Birthdate,
                 CivilStatus = employeeViewModel.CivilStatus,
                 Country = employeeViewModel.Country,
                 FirstName = employeeViewModel.FirstName,
                 Gender = employeeViewModel.Gender,
                 HobbiesAndInterest = employeeViewModel.HobbiesAndInterest,
                 LanguagesSpoken = employeeViewModel.LanguagesSpoken,
                 LastName = employeeViewModel.LastName,
                 PhoneNumber = employeeViewModel.PhoneNumber,
                 State = employeeViewModel.State,
                 UserType = employeeViewModel.UserType
            };
        }
    }
}
