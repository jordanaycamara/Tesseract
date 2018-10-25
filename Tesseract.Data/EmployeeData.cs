using System;
using System.Collections.Generic;
using System.Text;
using Tesseract.Database.Models;

namespace Tesseract.Data
{
    public static class EmployeeData
    {
        public static List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee
                {
                    FirstName = "Jordan",
                    LastName = "Camara",
                    Dependents = new List<Dependent>
                    {
                        new Dependent
                        {
                            FirstName = "Ethan",
                            LastName = "Camara"
                        },
                        new Dependent
                        {
                            FirstName = "Xayah",
                            LastName = "Camara"
                        }
                    }
                }
            };
        }
    }
}
