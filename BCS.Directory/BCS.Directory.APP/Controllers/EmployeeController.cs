using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCS.Directory.APP.Mapper;
using BCS.Directory.APP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BCS.Directory.APP.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult AddEmployee([FromBody]EmployeeViewModel vm)
        {
            var map = EmployeeMapper.Convert(vm);
            //if (vm != null)
            //{
            //    var oldSession = HttpContext.Session.GetObject<List<CustomerTransactionViewModel>>("AllAddOrderSession");
            //    var response = ViewControllerModelExtensions.AddNewOrder(oldSession, vm, OrderProductSession());
            //    HttpContext.Session.SetObject("AllAddOrderSession", response);
            //}
            return Json(new { data = map });
        }
    }
}