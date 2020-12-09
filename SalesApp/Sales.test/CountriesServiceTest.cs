using System;
using Sales.Entities;
using Xunit;
using Sales.Service;
using Sales.Data;

namespace Sales.test
{
    public class CountriesServiceTest
    {
        private readonly DataContext _context;

        [Fact]
        public void TestGetCountriesData()
        {
            var countryService = new Service.CountryService(_context);
            Assert.NotEmpty(countryService.GetCountriesData().Value);
        }

    }
}
