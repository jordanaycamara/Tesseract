using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Enums;
using Tesseract.Database.Mappings.Base;
using Tesseract.Database.Models;

namespace Tesseract.Database.Mappings
{
    public class BenefitMap : IdentifiableMap<Benefit>
    {
        public BenefitMap()
        {
            Schema(SchemaConstants.Finances);

            Map(x => x.BenefitType).Column("BenefitTypeId").CustomType<BenefitTypeEnum>();
            Map(x => x.Amount);
        }
    }
}
