using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models;
using System.Linq;
using Tesseract.Database.Repositories;

namespace Tesseract.Database.Commands
{
    public interface IGetEmployeeListQuery
    {
        List<Employee> GetEmployeesList();
    }

    public class GetEmployeeListQuery : IGetEmployeeListQuery
    {
        private readonly IEmployeeRepository _repo;

        public GetEmployeeListQuery(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public List<Employee> GetEmployeesList()
        {
            return _repo.GetEmployees();
        }
    }
}
