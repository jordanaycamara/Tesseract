using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models;
using System.Linq;

namespace Tesseract.Database.Repositories
{
    public interface IFinanceRepository
    {
        List<Deduction> GetDeductions();
        List<Discount> GetDiscounts();
    }

    public class FinanceRepository : IFinanceRepository
    {
        private readonly ISessionFactory _sessionFactory;

        public FinanceRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public List<Deduction> GetDeductions()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var result = session.QueryOver<Deduction>().List<Deduction>();
                return result.ToList();
            }
        }

        public List<Discount> GetDiscounts()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var result = session.QueryOver<Discount>().List<Discount>();
                return result.ToList();
            }
        }
    }
}
