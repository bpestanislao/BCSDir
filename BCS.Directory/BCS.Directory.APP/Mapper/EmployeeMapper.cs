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
                 UserType = employeeViewModel.UserType,
                 Department = employeeViewModel.Department,
                 HireDate = employeeViewModel.HireDate,
            };
        }
        public static List<EmployeeViewModel> Convert(List<Employee> employees)
        {
            List<EmployeeViewModel> mapData = new List<EmployeeViewModel>();
            foreach (var item in employees)
            {
                mapData.Add(new EmployeeViewModel() {
                    Age = item.Age,
                    Address = item.Address,
                    Birthdate = item.Birthdate,
                    CivilStatus = item.CivilStatus,
                    Country = item.Country,
                    FirstName = item.FirstName,
                    Gender = item.Gender,
                    HobbiesAndInterest = item.HobbiesAndInterest,
                    LanguagesSpoken = item.LanguagesSpoken,
                    LastName = item.LastName,
                    PhoneNumber = item.PhoneNumber,
                    State = item.State,
                    UserType = item.UserType,
                    Department = item.Department,
                    HireDate = item.HireDate,
                });
            }
            return mapData;
        }

    }
}
