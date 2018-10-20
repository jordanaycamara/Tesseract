using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Repositories;

namespace Tesseract.Database.Commands
{
    public interface IDeleteEmployeeCommand
    {
        void DeleteEmployee(Guid id);
    }
    public class DeleteEmployeeCommand : IDeleteEmployeeCommand
    {
        private readonly IEmployeeRepository _repo;

        public DeleteEmployeeCommand(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public void DeleteEmployee(Guid id)
        {
            _repo.DeleteEmployee(id);
        }
    }
}
