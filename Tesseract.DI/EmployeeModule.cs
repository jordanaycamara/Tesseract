using Tesseract.Database.Commands;
using Microsoft.Extensions.DependencyInjection;
using Tesseract.Database.Repositories;

namespace Tesseract.DI
{
    public class EmployeeModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSingleton<IGetEmployeeQuery, GetEmployeeQuery>();
            services.AddSingleton<IGetEmployeeListQuery, GetEmployeeListQuery>();
            services.AddSingleton<ISaveEmployeeCommand, SaveEmployeeCommand>();
            services.AddSingleton<IDeleteEmployeeCommand, DeleteEmployeeCommand>();
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
