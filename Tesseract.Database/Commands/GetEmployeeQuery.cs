using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models;
using Tesseract.Database.Repositories;

namespace Tesseract.Database.Commands
{
    public interface IGetEmployeeQuery
    {
        Employee GetEmployee(Guid id);
    }

    public class GetEmployeeQuery : IGetEmployeeQuery
    {
        private readonly IEmployeeRepository _repo;

        public GetEmployeeQuery(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        public Employee GetEmployee(Guid id)
        {
            return _repo.GetEmployeeById(id);
        }
    }
}
