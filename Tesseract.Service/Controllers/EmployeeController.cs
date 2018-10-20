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

        public EmployeeController(
            IGetEmployeeQuery getEmployeeCommand,
            IGetEmployeeListQuery getEmployeeListCommand)
        {
            _getEmployeeQuery = getEmployeeCommand;
            _getEmployeeListQuery = getEmployeeListCommand;
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
        public void Post([FromBody] Employee value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
