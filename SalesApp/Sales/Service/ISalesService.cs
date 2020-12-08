using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sales.Entities;

namespace Sales.Service
{
    public interface ISalesService
    {
        public ActionResult<IEnumerable<SalesRecord>>  GetSalesData(String country);
        public ActionResult<IEnumerable<SalesRecord>>  GetSales();
    }
}
