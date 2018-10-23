using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models.Base;

namespace Tesseract.Database.Models
{
    public class Dependent : Person
    {
        public virtual Guid? EmployeeId { get; set; }
    }
}
