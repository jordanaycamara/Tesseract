using Tesseract.Database.Commands;
using Microsoft.Extensions.DependencyInjection;

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
        }
    }
}
