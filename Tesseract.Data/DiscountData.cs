using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Enums;
using Tesseract.Database.Models;

namespace Tesseract.Data
{
    public static class DiscountData
    {
        public static List<Discount> GetDiscounts()
        {
            return new List<Discount>
            {
                new Discount
                {
                    Percentage = 0.10m,
                    DiscountType = DiscountTypeEnum.ATeam
                }
            };
        }
    }
}
