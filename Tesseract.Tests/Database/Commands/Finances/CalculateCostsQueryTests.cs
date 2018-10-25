using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using Tesseract.Database.Commands.Finances;
using Tesseract.Database.Commands.Finances.Translators;
using Tesseract.Database.Models;
using Tesseract.Database.Repositories;

namespace Tesseract.Tests.Database.Commands.Finances
{
    public class CalculateCostsQueryTests
    {
        private CalculateCostsQuery _query;
        private Mock<IEmployeeRepository> _employeeRepo;
        private Mock<IFinanceRepository> _financeRepo;
        private Mock<ICostReportTranslator> _translator;

        [SetUp]
        public void Setup()
        {
            _employeeRepo = new Mock<IEmployeeRepository>();
            _financeRepo = new Mock<IFinanceRepository>();
            _translator = new Mock<ICostReportTranslator>();

            _employeeRepo.Setup(x => x.GetEmployees()).Returns(new List<Employee>());
            _financeRepo.Setup(x => x.GetBenefits()).Returns(new List<Benefit>());
            _financeRepo.Setup(x => x.GetDiscounts()).Returns(new List<Discount>());

            _translator.Setup(x => x.ToViewModel(It.IsAny<int>(), It.IsAny<List<Employee>>(), It.IsAny<List<Benefit>>(),
                It.IsAny<List<Discount>>())).Returns(new CostReportViewModel());

            _query = new CalculateCostsQuery(_employeeRepo.Object, _financeRepo.Object, _translator.Object);
        }

        [Test]
        public void TestCalculateCosts()
        {
            var result = _query.CalculateCosts(1);

            Assert.NotNull(result);

            _employeeRepo.Verify(x => x.GetEmployees(), Times.Once);
            _financeRepo.Verify(x => x.GetBenefits(), Times.Once);
            _financeRepo.Verify(x => x.GetDiscounts(), Times.Once);
        }
    }
}
