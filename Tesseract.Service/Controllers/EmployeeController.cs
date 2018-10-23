using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tesseract.Database.Models;
using Tesseract.Database.Commands;

namespace Tesseract.Service.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IGetEmployeeQuery _getEmployeeQuery;
        private readonly IGetEmployeeListQuery _getEmployeeListQuery;
        private readonly ISaveEmployeeCommand _saveEmployeeCommand;
        private readonly IDeleteEmployeeCommand _deleteEmployeeCommand;

        public EmployeeController(
            IGetEmployeeQuery getEmployeeCommand,
            IGetEmployeeListQuery getEmployeeListCommand,
            ISaveEmployeeCommand saveEmployeeCommand,
            IDeleteEmployeeCommand deleteEmployeeCommand)
        {
            _getEmployeeQuery = getEmployeeCommand;
            _getEmployeeListQuery = getEmployeeListCommand;
            _saveEmployeeCommand = saveEmployeeCommand;
            _deleteEmployeeCommand = deleteEmployeeCommand;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return _getEmployeeListQuery.GetEmployeesList();
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(Guid id)
        {
            return _getEmployeeQuery.GetEmployee(id);
        }

        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
           return _saveEmployeeCommand.SaveEmployee(employee);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _deleteEmployeeCommand.DeleteEmployee(id);
        }
    }
}
