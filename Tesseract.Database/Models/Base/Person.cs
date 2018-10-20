using System;
using System.Collections.Generic;
using System.Text;

namespace Tesseract.Database.Models.Base
{
    public class Person : Identifiable
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}
