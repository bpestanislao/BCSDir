using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCS.Directory.APP.Models;
using BCS.Directory.APP.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BCS.Directory.APP.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetUserRoleId()
        {
            var userRole = HttpContext.Session.GetObject<ApplicationUser>("UserSession");
            return Json(new { userRoleId = userRole.UserRoleId });
        }
    }
}