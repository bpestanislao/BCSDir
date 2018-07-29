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
            return new Employee
            {
                Id = employeeViewModel.Id,
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
                Department = employeeViewModel.Department,
                HireDate = employeeViewModel.HireDate,
                EmployeeSettings = new EmployeeSettings
                {
                    EmployeeId = employeeViewModel.Id,
                    IsAddressPrivate = employeeViewModel.EmployeeSettingsViewModel.IsAddressPrivate,
                    IsAgePrivate = employeeViewModel.EmployeeSettingsViewModel.IsAgePrivate,
                    IsBirthDatePrivate = employeeViewModel.EmployeeSettingsViewModel.IsBirthDatePrivate,
                    IsCivilStatusPrivate = employeeViewModel.EmployeeSettingsViewModel.IsCivilStatusPrivate,
                    IsHobbiesAndInterestPrivate = employeeViewModel.EmployeeSettingsViewModel.IsHobbiesAndInterestPrivate,
                    Id = employeeViewModel.EmployeeSettingsViewModel.Id,
                }
            };
        }
        public static List<EmployeeViewModel> Convert(List<Employee> employees)
        {
            List<EmployeeViewModel> mapData = new List<EmployeeViewModel>();
            foreach (var item in employees)
            {
                mapData.Add(new EmployeeViewModel()
                {
                    Id = item.Id,
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
                    Department = item.Department,
                    HireDate = item.HireDate,
                });
            }
            return mapData;
        }

        public static EmployeeViewModel Convert(Employee employee)
        {
            return new EmployeeViewModel()
            {
                Id = employee.Id,
                Age = employee.Age,
                Address = employee.Address,
                Birthdate = employee.Birthdate,
                CivilStatus = employee.CivilStatus,
                Country = employee.Country,
                FirstName = employee.FirstName,
                Gender = employee.Gender,
                HobbiesAndInterest = employee.HobbiesAndInterest,
                LanguagesSpoken = employee.LanguagesSpoken,
                LastName = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                State = employee.State,
                Department = employee.Department,
                HireDate = employee.HireDate,
                EmployeeSettingsViewModel = new EmployeeSettingsViewModel {
                    Id = employee.EmployeeSettings.Id,
                    EmployeeId = employee.EmployeeSettings.EmployeeId,
                    IsHobbiesAndInterestPrivate = employee.EmployeeSettings.IsHobbiesAndInterestPrivate,
                    IsCivilStatusPrivate = employee.EmployeeSettings.IsCivilStatusPrivate,
                    IsBirthDatePrivate = employee.EmployeeSettings.IsBirthDatePrivate,
                    IsAddressPrivate = employee.EmployeeSettings.IsAddressPrivate,
                    IsAgePrivate = employee.EmployeeSettings.IsAgePrivate,
                }
            };
        }
    }
}