using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sales.Data;
using Sales.Entities;

namespace Sales.Service
{
    public class CountryService : ICountryService
    {
        private readonly DataContext _context;

        public CountryService(DataContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<Countries>> GetCountriesData()
        {
            return _context.CountriesData.ToList();
        }
    }
}
