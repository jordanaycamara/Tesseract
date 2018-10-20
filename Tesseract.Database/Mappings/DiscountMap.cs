using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Enums;
using Tesseract.Database.Mappings.Base;
using Tesseract.Database.Models;

namespace Tesseract.Database.Mappings
{
    public class DiscountMap : IdentifiableMap<Discount>
    {
        public DiscountMap()
        {
            Schema(SchemaConstants.Finances);

            Map(x => x.DiscountType).Column("DiscountTypeId").CustomType<DiscountTypeEnum>();
            Map(x => x.Percentage).Nullable();
            Map(x => x.Amount).Nullable();
        }
    }
}
