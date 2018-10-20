using System;
using System.Collections.Generic;
using System.Text;

namespace Tesseract.Database.Models
{
    public class CostReportViewModel
    {
        public decimal PeriodCost { get; set; }
        public decimal MonthlyCost { get; set; }
        public decimal AnnualCost { get; set; }
    }
}
