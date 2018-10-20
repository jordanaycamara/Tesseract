using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models;

namespace Tesseract.Database.Commands
{
    public interface IGetEmployeeQuery
    {
        Employee GetEmployee(Guid id);
    }

    public class GetEmployeeQuery : IGetEmployeeQuery
    {
        public Employee GetEmployee(Guid id)
        {
            return new Employee();
        }
    }
}
