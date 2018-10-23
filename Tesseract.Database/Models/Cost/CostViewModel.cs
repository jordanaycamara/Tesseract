using System;
using System.Collections.Generic;
using System.Text;

namespace Tesseract.Database.Models.Cost
{
    public class CostViewModel
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public List<CostViewModel> Dependents { get; set; }
        public List<DiscountViewModel> Discounts { get; set; }

        public CostViewModel()
        {
            Dependents = new List<CostViewModel>();
            Discounts = new List<DiscountViewModel>();
        }
    }
}
