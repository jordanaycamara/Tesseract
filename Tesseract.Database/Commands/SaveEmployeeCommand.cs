using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models;
using Tesseract.Database.Repositories;

namespace Tesseract.Database.Commands
{
    public interface ISaveEmployeeCommand
    {
        Employee SaveEmployee(Employee employee);
    }

    public class SaveEmployeeCommand : ISaveEmployeeCommand
    {
        private readonly IEmployeeRepository _repo;

        public SaveEmployeeCommand(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public Employee SaveEmployee(Employee employee)
        {
            foreach (var dependent in employee.Dependents)
            {
                dependent.Employee = employee;
            }

            return _repo.SaveEmployee(employee);
        }
    }
}
