using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tesseract.Database.Commands.Finances;
using Tesseract.Database.Models;

namespace Tesseract.Service.Cost
{
    [Route("api/v1/[controller]")]
    public class CostController : ControllerBase
    {
        private readonly ICalculateCostsQuery _calculateQuery;

        public CostController(ICalculateCostsQuery calculateQuery)
        {
            _calculateQuery = calculateQuery;
        }

        [HttpGet("{type:int}")]
        public ActionResult<CostReportViewModel> Get(int type)
        {
            return _calculateQuery.CalculateCosts(type);
        }
    }
}