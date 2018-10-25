using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using Tesseract.Database.Commands;
using Tesseract.Database.Models;
using Tesseract.Service.Controllers;

namespace Tesseract.Tests.Service
{
    public class EmployeeControllerTests
    {
        private EmployeeController _controller;
        private Mock<IGetEmployeeQuery> _getEmployeeQuery;
        private Mock<IGetEmployeeListQuery> _getEmployeeListQuery;
        private Mock<ISaveEmployeeCommand> _saveEmployeeCommand;
        private Mock<IDeleteEmployeeCommand> _deleteEmployeeCommand;

        [SetUp]
        public void Setup()
        {
            _getEmployeeQuery = new Mock<IGetEmployeeQuery>();
            _getEmployeeListQuery = new Mock<IGetEmployeeListQuery>();
            _saveEmployeeCommand = new Mock<ISaveEmployeeCommand>();
            _deleteEmployeeCommand = new Mock<IDeleteEmployeeCommand>();

            _getEmployeeQuery.Setup(x => x.GetEmployee(It.IsAny<Guid>())).Returns(new Employee());
            _getEmployeeListQuery.Setup(x => x.GetEmployeesList()).Returns(new List<Employee>());
            _saveEmployeeCommand.Setup(x => x.SaveEmployee(It.IsAny<Employee>())).Returns(new Employee());
            _deleteEmployeeCommand.Setup(x => x.DeleteEmployee(It.IsAny<Guid>()));

            _controller = new EmployeeController(_getEmployeeQuery.Object, _getEmployeeListQuery.Object, _saveEmployeeCommand.Object, _deleteEmployeeCommand.Object);
        }

        [Test]
        public void TestGetEmployee()
        {
            var result = _controller.Get(Guid.NewGuid());

            Assert.NotNull(result);
            Assert.NotNull(result.Value);

            _getEmployeeQuery.Verify(x => x.GetEmployee(It.IsAny<Guid>()), Times.Once);
        }

        [Test]
        public void TestGetEmployeeList()
        {
            var result = _controller.Get();

            Assert.NotNull(result);
            Assert.NotNull(result.Value);

            _getEmployeeListQuery.Verify(x => x.GetEmployeesList(), Times.Once);
        }

        [Test]
        public void TestSaveEmployee()
        {
            var result = _controller.Post(new Employee());

            Assert.NotNull(result);
            Assert.NotNull(result.Value);

            _saveEmployeeCommand.Verify(x => x.SaveEmployee(It.IsAny<Employee>()), Times.Once);
        }

        [Test]
        public void TestDeleteEmployee()
        {
            _controller.Delete(Guid.NewGuid());
            
            _deleteEmployeeCommand.Verify(x => x.DeleteEmployee(It.IsAny<Guid>()), Times.Once);
        }
    }
}
