using System;
using System.Collections.Generic;

#nullable disable

namespace Migrations.Web.Models.NorthwindDB.Entities
{
    public partial class ProductSalesFor1997
    {
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductSales { get; set; }
    }
}
