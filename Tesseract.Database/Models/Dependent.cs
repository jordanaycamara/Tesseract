using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models.Base;

namespace Tesseract.Database.Models
{
    public class Dependent : Identifiable
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}
