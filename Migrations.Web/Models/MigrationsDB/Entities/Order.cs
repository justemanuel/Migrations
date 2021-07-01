using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Migrations.Web.Models.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Description { get; set; }
        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
