using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Mappings.Base;
using Tesseract.Database.Models;

namespace Tesseract.Database.Mappings
{
    public class DependentMap : IdentifiableMap<Dependent>
    {
        public DependentMap()
        {
            Schema(SchemaConstants.Company);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            References(x => x.Employee, "EmployeeId").Cascade.None();
        }
    }
}
