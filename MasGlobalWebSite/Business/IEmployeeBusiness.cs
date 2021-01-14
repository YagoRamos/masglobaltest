using System.Collections.Generic;
using MasGlobalWebSite.Models;

namespace MasGlobalWebSite.Business
{
    public interface IEmployeeBusiness
    {
       List<EmployeeDTO> GetEmployees(string id);
    }
}
