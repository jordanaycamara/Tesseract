using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Tesseract.Database.Enums
{
    public enum DeductionTypeEnum
    {
        [Description("Employee Benefit")]
        EmployeeBenefit = 1,
        [Description("Dependent Benefit")]
        DependentBenefit
    }
}
