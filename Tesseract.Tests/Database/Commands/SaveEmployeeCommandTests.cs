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
    public class SaveEmployeeCommandTests
    {
        private SaveEmployeeCommand _command;
        private Mock<IEmployeeRepository> _employeeRepo;

        [SetUp]
        public void Setup()
        {
            _employeeRepo = new Mock<IEmployeeRepository>();
            _employeeRepo.Setup(x => x.SaveEmployee(It.IsAny<Employee>())).Returns(new Employee());

            _command = new SaveEmployeeCommand(_employeeRepo.Object);
        }

        [Test]
        public void TestSaveEmployee()
        {
            var result = _command.SaveEmployee(new Employee());

            Assert.NotNull(result);

            _employeeRepo.Verify(x => x.SaveEmployee(It.IsAny<Employee>()), Times.Once);
        }
    }
}
