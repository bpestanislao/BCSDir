using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BCS.Directory.CORE.Entity;
using BCS.Directory.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpGet("GetCoutries")]
        public List<Country> GetCoutries()
        {
            List<Country> countries = new List<Country>();
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync("https://restcountries.eu/rest/v2/all").Result;
                var convertedData = JsonConvert.DeserializeObject<List<RootObject>>(response);
                foreach (var item in convertedData)
                {
                    countries.Add(new Country() {
                        CountryCode = item.alpha2Code,
                        CountryName = item.name,
                        State = item.capital,
                    });
                }               
            }
            return countries;
        }

        // GET api/Employee/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _employeeService.TestEmployee(id);
        }

        [HttpPost("SaveEmployee")]
        public int SaveEmployee([FromBody]Employee employee)
        {
            return _employeeService.AddEmployee(employee);
        }


        [HttpGet("GetAllActiveEmployees")]
        public List<Employee> GetAllActiveEmployees()
        {
            return _employeeService.GetAllActiveEmployees();
        }
    }


}