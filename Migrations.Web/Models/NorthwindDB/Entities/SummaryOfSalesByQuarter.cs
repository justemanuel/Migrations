using System;
using System.Collections.Generic;

#nullable disable

namespace Migrations.Web.Models.NorthwindDB.Entities
{
    public partial class SummaryOfSalesByQuarter
    {
        public DateTime? ShippedDate { get; set; }
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
