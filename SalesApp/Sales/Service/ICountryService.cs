using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sales.Entities;

namespace Sales.Service
{
    public interface ICountryService
    {
        public ActionResult<IEnumerable<Countries>> GetCountriesData();
    }
}
