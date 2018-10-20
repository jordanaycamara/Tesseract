using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Commands.Finances;
using Tesseract.Database.Commands.Finances.Translators;
using Tesseract.Database.Repositories;

namespace Tesseract.DI
{
    public class FinanceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSingleton<ICalculateCostsQuery, CalculateCostsQuery>();
            services.AddSingleton<IFinanceRepository, FinanceRepository>();
            services.AddSingleton<ICostReportTranslator, CostReportTranslator>();
        }
    }
}
