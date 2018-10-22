using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Automapping;
using Tesseract.Database.Mappings;
using Tesseract.Database.Models;

namespace Tesseract.DI
{
    public class DatabaseModule
    {
        public void Load(IServiceCollection services, string connectionString)
        {
            services.AddSingleton(GetSessionFactory(connectionString));
        }

        private ISessionFactory GetSessionFactory(string connectionString)
        {
            return Fluently.Configure().Database(
                MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql())
                .Mappings(m =>
                {
                    m.FluentMappings
                        .AddFromAssemblyOf<EmployeeMap>();
                }).BuildSessionFactory();
        }
    }
}
