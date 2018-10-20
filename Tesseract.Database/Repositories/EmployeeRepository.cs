using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models;
using System.Linq;

namespace Tesseract.Database.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeById(Guid id);
        Employee SaveEmployee(Employee employee);
        void DeleteEmployee(Guid id);
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISessionFactory _sessionFactory;

        public EmployeeRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public Employee GetEmployeeById(Guid id)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var result = session.Get<Employee>(id);
                return result;
            }
        }

        public List<Employee> GetEmployees()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var result = session.QueryOver<Employee>().List<Employee>();
                return result.ToList();
            }
        }

        public Employee SaveEmployee(Employee employee)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(employee);
                    transaction.Commit();
                    return employee;
                }
            }
        }

        public void DeleteEmployee(Guid id)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var employee = session.Get<Employee>(id);
                    session.Delete(employee);
                    transaction.Commit();
                }
            }
        }
    }
}
