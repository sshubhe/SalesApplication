using System;
using System.ComponentModel.DataAnnotations;

namespace Sales.Entities
{
    public class Countries
    {
        [Key]
        public string Country { get; set; }
    }
}
