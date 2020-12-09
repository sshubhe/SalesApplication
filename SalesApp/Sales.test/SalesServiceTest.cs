using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Sales.Controllers;
using Sales.Data;
using Sales.Entities;
using Xunit;

namespace Sales.test
{
    public class SalesServiceTest
    {

        private DataContext _context;

        [Fact]
        public void TestGetSalesCount()
        {
            ConnectToDb();

            var salesService = new Service.SalesService(_context);
            Assert.NotEmpty(salesService.GetSales().Value);

        }


        public void ConnectToDb() {

            _context = new DataContext();
        }

    }
}
