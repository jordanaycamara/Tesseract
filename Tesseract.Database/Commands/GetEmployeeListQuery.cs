using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models;

namespace Tesseract.Database.Commands
{
    public interface IGetEmployeeListQuery
    {
        List<Employee> GetEmployeesList();
    }

    public class GetEmployeeListQuery : IGetEmployeeListQuery
    {
        public List<Employee> GetEmployeesList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    FirstName = "Courtney",
                    LastName = "I Love You"
                }
            };
        }
    }
}
