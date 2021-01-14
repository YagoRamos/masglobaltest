using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using MasGlobalWebSite.Business;
using System;

namespace MasGlobalWebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet("{id}")]
        public IActionResult GetEployees(string id)
        {
            try
            {
                return this.Ok(this.employeeBusiness.GetEmployees(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
