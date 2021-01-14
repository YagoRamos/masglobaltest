using System.Collections.Generic;
using MasGlobalWebSite.Repository.Entities;

namespace MasGlobalWebSite.Repository
{
    public interface IEmployeeDAO
    {
       List<Employee> GetEmployees();
    }
}
