using System;
using System.Collections.Generic;

namespace EmployeeMockAPI.Repository
{
    public static class DataAccess
    {
        public static List<EmployeeModel> GetAllEmployees()
        {
            return new List<EmployeeModel>
            {
                new EmployeeModel
                {
                    Id = 1,
                    ContractTypeName = "Hourly",
                    HourlySalary = 25,
                    MonthlySalary = 0,
                    Name = "John Doe",
                    RoleId = 12,
                    RoleName = "Software Developer",
                    RoleDescription = "Create and manage web applications"
                },
                new EmployeeModel
                {
                    Id = 2,
                    ContractTypeName = "Monthly",
                    HourlySalary = 0,
                    MonthlySalary = 2500,
                    Name = "Jane Doe",
                    RoleId = 11,
                    RoleName = "Ux Researcher",
                    RoleDescription = "Reveals what the consumers need from the business's products by conducting primary research"
                },
                new EmployeeModel
                {
                    Id = 3,
                    ContractTypeName = "Monthly",
                    HourlySalary = 0,
                    MonthlySalary = 2000,
                    Name = "Jack Mockingsong",
                    RoleId = 3,
                    RoleName = "QA Lead",
                    RoleDescription = "Establishes metrics, mentors team members and manages outside resources, as well as developing test programs"
                },
                new EmployeeModel
                {
                    Id = 4,
                    ContractTypeName = "Hourly",
                    HourlySalary = 30,
                    MonthlySalary = 0,
                    Name = "Abby Mockingsong",
                    RoleId = 20,
                    RoleName = "Technical Leader",
                    RoleDescription = "Technical Lead is the one who actually creates a technical vision in order to turn it into reality with the help of the team"
                }
            };
        }
    }
}
