using System.Collections.Generic;
namespace MasGlobal.Repository.Entities
{
    public interface IEmployeeDAO
    {
       List<Employee> GetEmployees();
    }
}
