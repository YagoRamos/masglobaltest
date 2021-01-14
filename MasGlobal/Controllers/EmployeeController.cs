using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using MasGlobal.Business;

namespace MasGlobal.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IEmployeeBusiness employeeBusiness;

        public EmployeeController(ILogger<EmployeeController> logger, IConfiguration configuration, IEmployeeBusiness employeeBusiness)
        {
            _logger = logger;
            _configuration = configuration;
            this.employeeBusiness = employeeBusiness;
        }

        [HttpGet]
        public ActionResult GetEployees(string id)
        {
            return View(this.employeeBusiness.GetEmployees(id));
        }
    }
}
