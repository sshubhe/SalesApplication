using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Data;
using Sales.Entities;

namespace Sales.Service
{
    public class SalesService: ISalesService
    {
        private readonly DataContext _context;

        public SalesService(DataContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<SalesRecord>> GetSales()
        {
            return _context.Sales.ToList();
        }

        public ActionResult<IEnumerable<SalesRecord>> GetSalesData(String country)
        {
            List<SalesRecord> output = _context.Sales
                                               .FromSqlRaw("SELECT * FROM Sales s where s.Country = @p0", country)
                                               .ToList();
            return output;
        }
    }
}
