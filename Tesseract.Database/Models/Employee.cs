using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models.Base;

namespace Tesseract.Database.Models
{
    public class Employee : Person
    {
        public virtual IEnumerable<Dependent> Dependents { get; set; }
    }
}
