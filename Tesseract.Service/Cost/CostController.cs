using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tesseract.Database.Models;

namespace Tesseract.Service.Cost
{
    [Route("api/v1/[controller]")]
    public class CostController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return new List<Employee>();
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            return new Employee();
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
