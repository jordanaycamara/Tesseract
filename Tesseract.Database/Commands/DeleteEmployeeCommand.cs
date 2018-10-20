using System;
using System.Collections.Generic;
using System.Text;

namespace Tesseract.Database.Commands
{
    public interface IDeleteEmployeeCommand
    {
        void DeleteEmployee(Guid id);
    }
    public class DeleteEmployeeCommand : IDeleteEmployeeCommand
    {
        public void DeleteEmployee(Guid id)
        {

        }
    }
}
