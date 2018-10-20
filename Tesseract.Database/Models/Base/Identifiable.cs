
using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models.Interfaces;

namespace Tesseract.Database.Models.Base
{
    public class Identifiable : IIdentifiable
    {
        public virtual Guid Id { get; set; }
    }
}
