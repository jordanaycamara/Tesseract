using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models.Cost;

namespace Tesseract.Database.Models
{
    public class CostReportViewModel
    {
        public List<CostViewModel> Costs { get; set; }
        public decimal PeriodCost { get; set; }
        public decimal MonthlyCost { get; set; }
        public decimal AnnualCost { get; set; }

        public CostReportViewModel()
        {
            Costs = new List<CostViewModel>();
        }
    }
}
