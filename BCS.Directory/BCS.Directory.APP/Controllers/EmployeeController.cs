using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BCS.Directory.APP.APIService;
using BCS.Directory.APP.Mapper;
using BCS.Directory.APP.Models.ViewModels;
using BCS.Directory.CORE.Entity;
using BCS.Directory.Service;
using Microsoft.AspNetCore.Mvc;

namespace BCS.Directory.APP.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService _employeeService;
        IBCSDirectoryService _bCSDirectoryService;
        public EmployeeController(IEmployeeService employeeService,
                                IBCSDirectoryService bCSDirectoryService)
        {
            _employeeService = employeeService;
            _bCSDirectoryService = bCSDirectoryService;
        }
        public IActionResult Index()
        {
            var response = _bCSDirectoryService.GetCountry();            
            @ViewBag.Countries = CountryMapper.Convert(response);
            return View();
        }



        public JsonResult AddEmployee([FromBody]EmployeeViewModel vm)
        {
            var map = EmployeeMapper.Convert(vm);
            var response = _bCSDirectoryService.AddEmployee(map);
            return Json(new { data = response });
        }

        public JsonResult EditEmployee([FromBody]EmployeeViewModel vm)
        {
            var map = EmployeeMapper.Convert(vm);
            var id = _employeeService.UpdateEmployee(map);
            return Json(new { data = id });
        }

        public JsonResult GetActiveEmployees()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57110/api/Employee/");
                var responseTask = client.GetAsync("GetAllActiveEmployees");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Employee>>();
                    readTask.Wait();
                    var map = EmployeeMapper.Convert(readTask.Result);
                }
            }
            return Json(new { data = "" });
        }


        public JsonResult GetAllSaveActiveEmployees()
        {
            try
            {
                var response = _employeeService.GetAllActiveEmployees();
                var data = EmployeeMapper.Convert(response);
                return Json(new { data = data });
            }
            catch (Exception e)
            {
                return Json(new { IsSuccess = false });
            }
        }

        public JsonResult GetEmployeeById(int id)
        {
            try
            {
                var response = _employeeService.GetEmployeeById(id);
                var mapData = EmployeeMapper.Convert(response);
                return Json(new { data = mapData });
            }
            catch (Exception e)
            {
                return Json(new { IsSuccess = false });
            }
        }

        public JsonResult DeleteEmployeeById(int id)
        {
            try
            {
                var response = _employeeService.DeleteEmployee(new Employee() { Id = id });
                return Json(new { data = response });
            }
            catch (Exception e)
            {
                return Json(new { IsSuccess = false });
            }
        }

    }
}