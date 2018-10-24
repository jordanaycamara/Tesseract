using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models;
using System.Linq;
using Tesseract.Database.Enums;
using Tesseract.Database.Models.Base;
using Tesseract.Database.Models.Cost;
using System.ComponentModel;

namespace Tesseract.Database.Commands.Finances.Translators
{
    public interface ICostReportTranslator
    {
        CostReportViewModel ToViewModel(int type, List<Employee> employees, List<Benefit> benefits, List<Discount> discounts);
    }
    public class CostReportTranslator : ICostReportTranslator
    {
        public CostReportViewModel ToViewModel(int type, List<Employee> employees, List<Benefit> benefits, List<Discount> discounts)
        {
            var viewModel = new CostReportViewModel();

            var employeeCompensation = benefits.SingleOrDefault(x => x.BenefitType == BenefitTypeEnum.EmployeeCompensation);
            var employeeBenefit = benefits.SingleOrDefault(x => x.BenefitType == BenefitTypeEnum.EmployeeBenefit);
            var dependentBenefit = benefits.SingleOrDefault(x => x.BenefitType == BenefitTypeEnum.DependentBenefit);
            var aTeamDiscount = discounts.SingleOrDefault(x => x.DiscountType == DiscountTypeEnum.ATeam);

            var total = 0.0m;

            var reportType = (ReportTypeEnum) type;

            var factor = 1;

            switch (reportType)
            {
                case ReportTypeEnum.Yearly:
                    factor = 1;
                    break;
                case ReportTypeEnum.Monthly:
                    factor = 12;
                    break;
                case ReportTypeEnum.PayPeriod:
                    factor = 26;
                    break;
                default:
                    break;
            }

            var yearlyCompensation = (employeeCompensation.Amount * 26) / factor;
            viewModel.EmployeeCompensation = yearlyCompensation;

            foreach (var employee in employees)
            {
                var empCost = new CostViewModel();
                var totalDeduction = 0.0m;
                var empDeduction = employeeBenefit.Amount / factor;

                empCost.DeductionAmount = empDeduction;
                ApplyATeamDiscount(ref empDeduction, ref empCost, employee, aTeamDiscount);
                empCost.Name = $"{employee.FirstName} {employee.LastName}";
                viewModel.Costs.Add(empCost);

                totalDeduction += empDeduction;

                foreach (var dependent in employee.Dependents)
                {
                    var depCost = new CostViewModel();
                    
                    var depDeduction = dependentBenefit.Amount / factor;
                    depCost.DeductionAmount = depDeduction;

                    ApplyATeamDiscount(ref depDeduction, ref depCost, dependent, aTeamDiscount);
                    depCost.Name = $"{dependent.FirstName} {dependent.LastName}";
                    empCost.Dependents.Add(depCost);
                    totalDeduction += depDeduction;
                }

                empCost.TotalDeduction = totalDeduction;

                var totalCost = yearlyCompensation - totalDeduction;
                empCost.TotalCost = totalCost;

                total += totalCost;
            };

            viewModel.PeriodCost = Math.Round(total / 26, 2);
            viewModel.MonthlyCost = Math.Round(total / 12, 2);
            viewModel.AnnualCost = Math.Round(total);

            return viewModel;
        }

        private void ApplyATeamDiscount(ref decimal value, ref CostViewModel cost, Person person, Discount discount)
        {
            if (person.FirstName.StartsWith('A'))
            {
                var discountAmount = value * discount.Percentage;
                var costDiscount = new DiscountViewModel
                {
                    Name = "A-Team",
                    Type = discount.DiscountType,
                    Amount = discountAmount
                };
                cost.Discounts.Add(costDiscount);

                value -= discountAmount;
            }
        }
    }
}
