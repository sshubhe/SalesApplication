using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Data;
using Sales.Entities;

namespace Sales.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<SalesRecord>> GetSales() => _context.Sales.ToList();

        [HttpGet]
        public ActionResult<IEnumerable<Countries>> GetCountries() => _context.CountriesData.FromSqlRaw("SELECT distinct cd.country FROM CountriesData cd").ToList();


    }
}