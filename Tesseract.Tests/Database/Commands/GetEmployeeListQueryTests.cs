using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using Tesseract.Database.Commands;
using Tesseract.Database.Models;
using Tesseract.Database.Repositories;

namespace Tesseract.Tests.Database.Commands
{
    public class GetEmployeeListQueryTests
    {
        private GetEmployeeListQuery _query;
        private Mock<IEmployeeRepository> _employeeRepo;

        [SetUp]
        public void Setup()
        {
            _employeeRepo = new Mock<IEmployeeRepository>();
            _employeeRepo.Setup(x => x.GetEmployees()).Returns(new List<Employee>());

            _query = new GetEmployeeListQuery(_employeeRepo.Object);
        }

        [Test]
        public void TestGetEmployeeList()
        {
            var result = _query.GetEmployeesList();

            Assert.NotNull(result);
            _employeeRepo.Verify(x => x.GetEmployees(), Times.Once);
        }
    }
}
