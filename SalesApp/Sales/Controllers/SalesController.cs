using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Data;
using Sales.Entities;

namespace Sales.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly DataContext _context;

        public SalesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SalesRecord>> GetSales() => _context.Sales.ToList();



        //[HttpGet]
        //public Object GetYears() {
        //    return _context.YearsData.ToList();
        //}


        [HttpGet]
        [Route("{country}")]
        public ActionResult<IEnumerable<SalesRecord>> GetStates(string country)
        {
            return _context.Sales.FromSqlRaw("SELECT distinct * FROM Sales s")
            .ToList(); ;
        }

    }
}