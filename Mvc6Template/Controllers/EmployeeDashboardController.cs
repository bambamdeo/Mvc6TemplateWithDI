using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace ASP.NET_MVC_61.Controllers
{
    [Authorize(Roles = Enums.ConstUserRoles.Employee)]
    public class EmployeeDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }




    }
}
