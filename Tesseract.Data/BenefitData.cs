using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Enums;
using Tesseract.Database.Models;

namespace Tesseract.Data
{
    public static class BenefitData
    {
        public static List<Benefit> GetBenefits()
        {
            return new List<Benefit>
            {
                new Benefit
                {
                    BenefitType = BenefitTypeEnum.EmployeeBenefit,
                    Amount = 1000m
                },
                new Benefit
                {
                    BenefitType = BenefitTypeEnum.DependentBenefit,
                    Amount = 500
                },
                new Benefit
                {
                    BenefitType = BenefitTypeEnum.EmployeeCompensation,
                    Amount = 2000
                }
            };
        }
    }
}
