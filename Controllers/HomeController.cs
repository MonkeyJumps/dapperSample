using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DapperWebApp.Models;
using DataLayer.BusinessLogic;

namespace DapperWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeProcessor _employeeProcessor;

        public HomeController(ILogger<HomeController> logger, IEmployeeProcessor employeeProcessor)
        {
            _logger = logger;
            _employeeProcessor = employeeProcessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult ViewEmployees()
        {
            ViewBag.Message = "Employees List";
            var data = _employeeProcessor.LoadEmployees();
            List<EmployeeModel> employees = new List<EmployeeModel>();
            foreach(var row in data)
            {
                employees.Add(new EmployeeModel
                {
                    EmployeeId = row.EmployeeId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress,
                    ConfirmEmail = row.EmailAddress
                });
            }
            return View(employees);
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(EmployeeModel model)
        {

            if(ModelState.IsValid)
            {

                int recordsCreated = _employeeProcessor.CreateEmployee(model.EmployeeId,model.FirstName,
                    model.LastName, model.EmailAddress);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
