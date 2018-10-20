using System;
using System.Collections.Generic;
using System.Text;

namespace Tesseract.Database.Models.Interfaces
{
    public interface IIdentifiable
    {
        Guid Id { get; set; }
    }
}
