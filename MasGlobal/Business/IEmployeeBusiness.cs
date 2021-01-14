using System.Collections.Generic;
using MasGlobal.Models;

namespace MasGlobal.Business
{
    public interface IEmployeeBusiness
    {
       List<EmployeeDTO> GetEmployees(string id);
    }
}
