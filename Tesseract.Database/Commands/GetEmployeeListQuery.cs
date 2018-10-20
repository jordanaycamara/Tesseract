using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models;
using System.Linq;

namespace Tesseract.Database.Commands
{
    public interface IGetEmployeeListQuery
    {
        List<Employee> GetEmployeesList();
    }

    public class GetEmployeeListQuery : IGetEmployeeListQuery
    {
        private readonly ISessionFactory _sessionFactory;

        public GetEmployeeListQuery(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public List<Employee> GetEmployeesList()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var result = session.QueryOver<Employee>().List<Employee>();
                return result.ToList();
            }
        }
    }
}
