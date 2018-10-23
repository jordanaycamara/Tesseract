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
        CostReportViewModel ToViewModel(List<Employee> employees, List<Benefit> benefits, List<Discount> discounts);
    }
    public class CostReportTranslator : ICostReportTranslator
    {
        public CostReportViewModel ToViewModel(List<Employee> employees, List<Benefit> benefits, List<Discount> discounts)
        {
            var viewModel = new CostReportViewModel();

            var employeeCompensation = benefits.SingleOrDefault(x => x.BenefitType == BenefitTypeEnum.EmployeeCompensation);
            var employeeBenefit = benefits.SingleOrDefault(x => x.BenefitType == BenefitTypeEnum.EmployeeBenefit);
            var dependentBenefit = benefits.SingleOrDefault(x => x.BenefitType == BenefitTypeEnum.DependentBenefit);
            var aTeamDiscount = discounts.SingleOrDefault(x => x.DiscountType == DiscountTypeEnum.ATeam);

            var total = 0.0m;

            foreach (var employee in employees)
            {
                var empCost = new CostViewModel();
                var totalDeduction = 0.0m;
                var empDeduction = employeeBenefit.Amount;

                ApplyATeamDiscount(ref empDeduction, ref empCost, employee, aTeamDiscount);

                empCost.Name = $"{employee.FirstName} {employee.LastName}";
                empCost.Amount = empDeduction;
                viewModel.Costs.Add(empCost);

                totalDeduction += empDeduction;

                foreach (var dependent in employee.Dependents)
                {
                    var depCost = new CostViewModel();
                    
                    var depDeduction = dependentBenefit.Amount;
                    ApplyATeamDiscount(ref depDeduction, ref depCost, dependent, aTeamDiscount);

                    depCost.Name = $"{dependent.FirstName} {dependent.LastName}";
                    depCost.Amount = depDeduction;
                    empCost.Dependents.Add(depCost);
                    totalDeduction += depDeduction;
                }

                // if value is negative, then there would be no cost to the employer
                total += Math.Max(employeeCompensation.Amount - totalDeduction, 0);
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

                var discountValue = discount.Percentage;
                var costDiscount = new DiscountViewModel
                {
                    Name = discount.DiscountType.ToString(),
                    Type = discount.DiscountType,
                    Percentage = discountValue
                };
                cost.Discounts.Add(costDiscount);

                value -= value * discountValue;
            }
        }
    }
}
