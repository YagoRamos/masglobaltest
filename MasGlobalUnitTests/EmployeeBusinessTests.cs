using System;
using System.Collections.Generic;
using MasGlobalWebSite.Business;
using MasGlobalWebSite.Repository;
using MasGlobalWebSite.Repository.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MasGlobalUnitTests
{
    [TestClass]
    public class EmployeeBusinessTests
    {
        private Mock<IEmployeeDAO> employeeDaoMock;
        private EmployeeBusiness employeeBusiness;
        private List<Employee> employeeDataDummy = new List<Employee>
        {
            new Employee
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
            new Employee
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
            new Employee
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
            new Employee
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

        [TestInitialize]
        public void Init()
        {
            this.employeeDaoMock = new Mock<IEmployeeDAO>();
            this.employeeBusiness = new EmployeeBusiness(employeeDaoMock.Object);
        }

        [TestMethod]
        public void GetSingleEmployeeTest()
        {
            string employeeId = "1";
            employeeDaoMock.Setup(x => x.GetEmployees()).Returns(employeeDataDummy);
            var result = employeeBusiness.GetEmployees(employeeId);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            //The Annual Salary shoudl be 120 * 25 * 12
            Assert.IsTrue(result.Find(x => x.Id == 1).AnnualSalary == 36000);
        }

        [TestMethod]
        public void GetAllEmployeesTest()
        {
            string employeeId = "";
            employeeDaoMock.Setup(x => x.GetEmployees()).Returns(employeeDataDummy);
            var result = employeeBusiness.GetEmployees(employeeId);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 1);
            //The Annual Salary shoudl be 120 * 25 * 12
            Assert.IsTrue(result.Find(x => x.Id == 1).AnnualSalary == 36000);
            //The Annual Salary shoudl be 2500 * 12
            Assert.IsTrue(result.Find(x => x.Id == 2).AnnualSalary == 30000);
            //The Annual Salary shoudl be 2000 * 12
            Assert.IsTrue(result.Find(x => x.Id == 3).AnnualSalary == 24000);
            //The Annual Salary shoudl be 120 * 30 * 12
            Assert.IsTrue(result.Find(x => x.Id == 4).AnnualSalary == 43200);

        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void GetEmployeesErrorTest()
        {
            string employeeId = "incorrectID";
            employeeDaoMock.Setup(x => x.GetEmployees()).Returns(employeeDataDummy);
            var result = employeeBusiness.GetEmployees(employeeId);
        }
    }
}
