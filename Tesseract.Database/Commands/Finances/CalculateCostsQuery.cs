using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Commands.Finances.Translators;
using Tesseract.Database.Models;
using Tesseract.Database.Repositories;

namespace Tesseract.Database.Commands.Finances
{
    public interface ICalculateCostsQuery
    {
        CostReportViewModel CalculateCosts();
    }

    public class CalculateCostsQuery : ICalculateCostsQuery
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IFinanceRepository _financeRepo;
        private readonly ICostReportTranslator _translator;

        public CalculateCostsQuery(
            IEmployeeRepository employeeRepo,
            IFinanceRepository financeRepo,
            ICostReportTranslator translator)
        {
            _employeeRepo = employeeRepo;
            _financeRepo = financeRepo;
            _translator = translator;
        }

        public CostReportViewModel CalculateCosts()
        {
            var employees = _employeeRepo.GetEmployees();
            var benefits = _financeRepo.GetBenefits();
            var discounts = _financeRepo.GetDiscounts();

            var result = _translator.ToViewModel(employees, benefits, discounts);
            return result;
        }
    }
}
