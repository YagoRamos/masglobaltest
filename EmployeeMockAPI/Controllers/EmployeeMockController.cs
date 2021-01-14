using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMockAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeMockAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeMockController : ControllerBase
    {
        private readonly ILogger<EmployeeMockController> _logger;

        public EmployeeMockController(ILogger<EmployeeMockController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<EmployeeModel> Get()
        {
            return DataAccess.GetAllEmployees();
        }
    }
}
