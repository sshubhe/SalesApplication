using System;
namespace Sales.Entities
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public float SalesData { get; set; }

    }
}
