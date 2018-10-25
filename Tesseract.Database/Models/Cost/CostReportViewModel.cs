using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models.Cost;

namespace Tesseract.Database.Models
{
    public class CostReportViewModel
    {
        public decimal EmployeeCompensation { get; set; }
        public List<CostViewModel> Costs { get; set; }
        public decimal TotalCost { get; set; }

        public CostReportViewModel()
        {
            Costs = new List<CostViewModel>();
        }
    }
}
