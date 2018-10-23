using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Mappings.Base;
using Tesseract.Database.Models;

namespace Tesseract.Database.Mappings
{
    public class EmployeeMap : IdentifiableMap<Employee>
    {
        public EmployeeMap()
        {
            Schema(SchemaConstants.Company);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            HasMany(x => x.Dependents).KeyColumn("EmployeeId").Cascade.All().Not.LazyLoad();
        }
    }
}
