using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models;

namespace Tesseract.Database.Commands
{
    public interface ISaveEmployeeCommand
    {
        Employee SaveEmployee(Employee employee);
    }

    public class SaveEmployeeCommand : ISaveEmployeeCommand
    {
        public Employee SaveEmployee(Employee employee)
        {
            return new Employee();
        }
    }
}
