using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Tesseract.Database.Commands.Finances;
using Tesseract.Database.Models;
using Tesseract.Service.Cost;

namespace Tesseract.Tests.Service
{
    public class CostControllerTests
    {
        private CostController _controller;
        private Mock<ICalculateCostsQuery> _mockQuery;

        [SetUp]
        public void Setup()
        {
            _mockQuery = new Mock<ICalculateCostsQuery>();
            _mockQuery.Setup(x => x.CalculateCosts(It.IsAny<int>())).Returns(new CostReportViewModel());
            _controller = new CostController(_mockQuery.Object);
        }

        [Test]
        public void TestCalculateCosts()
        {
            var result = _controller.Get(1);

            Assert.NotNull(result);
            Assert.NotNull(result.Value);

            _mockQuery.Verify(x => x.CalculateCosts(It.IsAny<int>()), Times.Once);
        }
    }
}
