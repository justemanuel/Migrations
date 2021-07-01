using System;
using System.Collections.Generic;

#nullable disable

namespace Migrations.Web.Models.NorthwindDB.Entities
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
