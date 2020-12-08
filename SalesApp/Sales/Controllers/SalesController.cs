using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Data;
using Sales.Entities;
using Sales.Service;

namespace Sales.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly SalesService _salesService;

        public SalesController(DataContext context)
        {
            _salesService = new SalesService(context);
        }

        [HttpGet]
        public ActionResult<IEnumerable<SalesRecord>> GetSales() => _salesService.GetSales();


        [HttpGet]
        [Route("{country}")]
        public ActionResult<IEnumerable<SalesRecord>> GetSalesForCountry(string country)
        {
            return _salesService.GetSalesData(country);
        }

    }
}