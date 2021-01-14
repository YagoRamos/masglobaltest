﻿using System;
using System.Collections.Generic;
using MasGlobal.Models;
using MasGlobal.Repository.Entities;

namespace MasGlobal.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeDAO employeeDAO;

        public EmployeeBusiness(IEmployeeDAO employeeDAO)
        {
            this.employeeDAO = employeeDAO;
        }

        public List<EmployeeDTO> GetEmployees(string id)
        {
            var employees = this.employeeDAO.GetEmployees();
            List<EmployeeDTO> result;

            if (!Int32.TryParse(id, out int idSingleEmployee))
            {
                throw new Exception("The id that you are trying to find does not exist!");
            };

            if (!String.IsNullOrEmpty(id))
            {
                result = this.MapEmployees(employees.FindAll(x => x.Id == idSingleEmployee));
            }
            else
            {
                result = this.MapEmployees(employees);
            }

            return result;
        }

        private List<EmployeeDTO> MapEmployees(List<Employee> employees)
        {
            List<EmployeeDTO> employeesMaped = new List<EmployeeDTO>();

            foreach(var employee in employees)
            {
                var employeeMaped = new EmployeeDTO
                {
                    Id = employee.Id,
                    ContractTypeName = employee.ContractTypeName,
                    Name = employee.Name,
                    RoleDescription = employee.RoleDescription,
                    RoleName = employee.RoleName,
                    RoleId = employee.RoleId,
                };

                if(employee.ContractTypeName == "Hourly")
                {
                    employeeMaped.AnnualSalary = 120 * employee.HourlySalary * 12;
                }
                else
                {
                    employeeMaped.AnnualSalary = employee.MonthlySalary * 12;
                }

                employeesMaped.Add(employeeMaped);
            }

            return employeesMaped;
        }
    }
}
