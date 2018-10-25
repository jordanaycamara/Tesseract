using System;
using Moq;
using NUnit.Framework;
using Tesseract.Database.Commands;
using Tesseract.Database.Models;
using Tesseract.Database.Repositories;

namespace Tesseract.Tests.Database.Commands
{
    public class GetEmployeeQueryTests
    {
        private GetEmployeeQuery _query;
        private Mock<IEmployeeRepository> _employeeRepo;

        [SetUp]
        public void Setup()
        {
            _employeeRepo = new Mock<IEmployeeRepository>();
            _employeeRepo.Setup(x => x.GetEmployeeById(It.IsAny<Guid>())).Returns(new Employee());

            _query = new GetEmployeeQuery(_employeeRepo.Object);
        }

        [Test]
        public void TestGetEmployee()
        {
            var result = _query.GetEmployee(Guid.NewGuid());

            Assert.NotNull(result);

            _employeeRepo.Verify(x => x.GetEmployeeById(It.IsAny<Guid>()), Times.Once);
        }
    }
}
