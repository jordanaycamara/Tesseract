using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Tesseract.Data;
using Tesseract.Database.Commands.Finances.Translators;
using Tesseract.Database.Enums;
using Tesseract.Database.Models;

namespace Tesseract.Tests.Database.Commands.Finances.Translators
{
    public class CostReportTranslatorTests
    {
        private CostReportTranslator _translator;
        private List<Employee> _expectedEmployees;
        private List<Benefit> _expectedBenefits;
        private List<Discount> _expectedDiscounts;

        [SetUp]
        public void Setup()
        {
            _expectedEmployees = EmployeeData.GetEmployees();
            _expectedBenefits = BenefitData.GetBenefits();
            _expectedDiscounts = DiscountData.GetDiscounts();
            _translator = new CostReportTranslator();
        }

        [TestCase(ReportTypeEnum.Yearly, 1)]
        [TestCase(ReportTypeEnum.Monthly, 12)]
        [TestCase(ReportTypeEnum.PayPeriod, 26)]
        public void TestReports(ReportTypeEnum type, decimal factor)
        {
            var result = _translator.ToViewModel((int)type, _expectedEmployees, _expectedBenefits, _expectedDiscounts);

            Assert.NotNull(result);

            Assert.AreEqual(_expectedEmployees.Count, result.Costs.Count);

            var employeeDeduction =
                _expectedBenefits.SingleOrDefault(x => x.BenefitType == BenefitTypeEnum.EmployeeBenefit);
            var dependentDeduction =
                _expectedBenefits.SingleOrDefault(x => x.BenefitType == BenefitTypeEnum.DependentBenefit);
            var compensation =
                _expectedBenefits.SingleOrDefault(x => x.BenefitType == BenefitTypeEnum.EmployeeCompensation);

            var totalCost = 0.0m;
            var expectedCompensation = (compensation.Amount * 26) / factor;

            for (var i = 0; i < _expectedEmployees.Count; i++)
            {
                var expectedEmp = _expectedEmployees[i];
                var actualEmp = result.Costs[i];

                var totalDeduction = 0.0m;

                var expectedName = $"{expectedEmp.FirstName} {expectedEmp.LastName}";
                Assert.AreEqual(expectedName, actualEmp.Name);
                Assert.AreEqual(expectedEmp.Dependents.Count(), actualEmp.Dependents.Count);

                Assert.AreEqual(Math.Round(employeeDeduction.Amount / factor, 2), Math.Round(actualEmp.DeductionAmount, 2));

                totalDeduction += actualEmp.DeductionAmount;

                for (var j = 0; j < expectedEmp.Dependents.Count(); j++)
                {
                    var expectedDep = expectedEmp.Dependents.ToList()[j];
                    var actualDep = actualEmp.Dependents[j];
                    var expectedDepName = $"{expectedDep.FirstName} {expectedDep.LastName}";

                    Assert.AreEqual(expectedDepName, actualDep.Name);
                    Assert.AreEqual(dependentDeduction.Amount / factor, actualDep.DeductionAmount);

                    totalDeduction += actualDep.DeductionAmount;
                }

                var expectedTotalCost = expectedCompensation - totalDeduction;
                totalCost += expectedTotalCost;
                Assert.AreEqual(expectedTotalCost, actualEmp.TotalCost);
            }

            Assert.AreEqual(expectedCompensation, result.EmployeeCompensation);
            Assert.AreEqual(Math.Round(totalCost, 2), Math.Round(result.TotalCost, 2));
        }

    }
}
