using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models;
using System.Linq;
using Tesseract.Database.Enums;
using Tesseract.Database.Models.Base;

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

            var employeeCompensation = benefits.Where(x => x.BenefitType == BenefitTypeEnum.EmployeeCompensation).SingleOrDefault();
            var employeeBenefit = benefits.Where(x => x.BenefitType == BenefitTypeEnum.EmployeeBenefit).SingleOrDefault();
            var dependentBenefit = benefits.Where(x => x.BenefitType == BenefitTypeEnum.DependentBenefit).SingleOrDefault();
            var aTeamDiscount = discounts.Where(x => x.DiscountType == DiscountTypeEnum.ATeam).SingleOrDefault();

            var total = 0.0m;

            foreach (var employee in employees)
            {
                var totalDeduction = 0.0m;
                var empDeduction = employeeBenefit.Amount;

                ApplyATeamDiscount(ref empDeduction, employee, aTeamDiscount);
                totalDeduction += empDeduction;

                foreach (var dependent in employee.Dependents)
                {
                    var depDeduction = dependentBenefit.Amount;
                    ApplyATeamDiscount(ref depDeduction, dependent, aTeamDiscount);

                    totalDeduction += depDeduction;
                }

                total += employeeCompensation.Amount - totalDeduction;
            };

            viewModel.PeriodCost = Math.Round(total / 26, 2);
            viewModel.MonthlyCost = Math.Round(total / 12, 2);
            viewModel.AnnualCost = Math.Round(total);

            return viewModel;
        }

        private void ApplyATeamDiscount(ref decimal value, Person person, Discount discount)
        {
            if (person.FirstName.StartsWith('A'))
            {
                if (discount.Percentage.HasValue)
                {
                    value -= value * discount.Percentage.Value;
                } else if (discount.Amount.HasValue)
                {
                    value -= discount.Amount.Value;
                }
            }
        }
    }
}
