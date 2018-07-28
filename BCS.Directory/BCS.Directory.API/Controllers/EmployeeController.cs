﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCS.Directory.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCS.Directory.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {

        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET api/Employee/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _employeeService.TestEmployee(id);
        }
    }


}