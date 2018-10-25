using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using Tesseract.Database.Commands;
using Tesseract.Database.Repositories;

namespace Tesseract.Tests.Database.Commands
{
    public class DeleteEmployeeCommandTests
    {
        private DeleteEmployeeCommand _command;
        private Mock<IEmployeeRepository> _employeeRepo;

        [SetUp]
        public void Setup()
        {
            _employeeRepo = new Mock<IEmployeeRepository>();
            _employeeRepo.Setup(x => x.DeleteEmployee(It.IsAny<Guid>()));

            _command = new DeleteEmployeeCommand(_employeeRepo.Object);
        }

        [Test]
        public void TestDeleteEmployeeCommand()
        {
            _command.DeleteEmployee(Guid.NewGuid());

            _employeeRepo.Verify(x => x.DeleteEmployee(It.IsAny<Guid>()), Times.Once);
        }
    }
}
