using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models;

namespace Tesseract.Database.Commands.Finances.Translators
{
    public interface ICostReportTranslator
    {
        CostReportViewModel ToViewModel(List<Employee> employees, List<Deduction> deductions, List<Discount> discounts);
    }
    public class CostReportTranslator : ICostReportTranslator
    {
        public CostReportViewModel ToViewModel(List<Employee> employees, List<Deduction> deductions, List<Discount> discounts)
        {
            var viewModel = new CostReportViewModel();

            return viewModel;
        }
    }
}
