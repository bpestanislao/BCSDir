﻿using BCS.Directory.CORE.Entity;
using BCS.Directory.DAO;
using BCS.Directory.DAO.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BCS.Directory.Service
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        IUnitOfWork _unitOfWork;
        public EmployeeService(IEmployeeRepository employeeRepository
                              , IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public int AddEmployee(Employee employee)
        {
            employee.IsActive = true;
            _employeeRepository.Insert(employee);
            _unitOfWork.Save();
            return employee.Id;
        }

        public int DeleteEmployee(Employee employee)
        {
            employee.IsActive = false;
            _unitOfWork.Context.Attach(employee);
            _unitOfWork.Context.Entry(employee).Property(x => x.IsActive).IsModified = true;
            _employeeRepository.Update(employee);
            _unitOfWork.Save();
            return employee.Id;
        }

        public List<Employee> GetAllActiveEmployees()
        {
            return _employeeRepository.Get(x => x.IsActive == true);
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public string TestEmployee(int id)
        {
            return "It's working!!";
        }

        public int UpdateEmployee(Employee employee)
        {
            _unitOfWork.Context.Attach(employee);
            _unitOfWork.Context.Entry(employee).Property(x => x.Birthdate).IsModified = true;
            _unitOfWork.Context.Entry(employee).Property(x => x.Age).IsModified = true;
            _unitOfWork.Context.Entry(employee).Property(x => x.HobbiesAndInterest).IsModified = true;
            _unitOfWork.Context.Entry(employee).Property(x => x.CivilStatus).IsModified = true;
            _unitOfWork.Context.Entry(employee).Property(x => x.Gender).IsModified = true;
            _unitOfWork.Context.Entry(employee).Property(x => x.Address).IsModified = true;
            _unitOfWork.Context.Entry(employee).Property(x => x.Country).IsModified = true;
            _unitOfWork.Context.Entry(employee).Property(x => x.State).IsModified = true;
            _unitOfWork.Context.Entry(employee).Property(x => x.FirstName).IsModified = true;
            _unitOfWork.Context.Entry(employee).Property(x => x.LastName).IsModified = true;
            _unitOfWork.Context.Entry(employee).Property(x => x.LanguagesSpoken).IsModified = true;
            _unitOfWork.Context.Entry(employee).Property(x => x.PhoneNumber).IsModified = true;
            _unitOfWork.Context.Entry(employee).Property(x => x.UserType).IsModified = true;
            _employeeRepository.Update(employee);
            _unitOfWork.Save();
            return employee.Id;
        }
    }
}
