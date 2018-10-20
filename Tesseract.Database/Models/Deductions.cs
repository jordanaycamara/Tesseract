using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Enums;
using Tesseract.Database.Models.Base;

namespace Tesseract.Database.Models
{
    public class Deductions : Identifiable
    {
        public virtual DeductionTypeEnum  DeductionType { get; set; }
        public virtual decimal Amount { get; set; }
    }
}
