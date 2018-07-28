using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public JsonResult AddEmployee([FromBody]EmployeeViewModel vm)
        {
            var map = EmployeeMapper.Convert(vm);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57110/api/Employee/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Employee>("SaveEmployee", map);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return Json(new { data = map });
                }
            }
            return Json(new { data = map });
        }

        public JsonResult GetActiveEmployees()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57110/api/Employee/");
                //HTTP GET
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

    }
}