using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Enums;
using Tesseract.Database.Mappings.Base;
using Tesseract.Database.Models;

namespace Tesseract.Database.Mappings
{
    public class DeductionMap : IdentifiableMap<Deduction>
    {
        public DeductionMap()
        {
            Schema(SchemaConstants.Finances);

            Map(x => x.DeductionType).CustomType<DeductionTypeEnum>();
            Map(x => x.Amount);
        }
    }
}
