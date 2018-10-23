using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Enums;

namespace Tesseract.Database.Models.Cost
{
    public class DiscountViewModel
    {
        public string Name { get; set; }
        public DiscountTypeEnum Type { get; set; }
        public decimal Percentage { get; set; }
    }
}
