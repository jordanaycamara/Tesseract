using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models.Base;
using Tesseract.Database.Enums;

namespace Tesseract.Database.Models
{
    public class Discount : Identifiable
    {
        public virtual DiscountTypeEnum DiscountType { get; set; }
        public virtual decimal Percentage { get; set; }
    }
}
