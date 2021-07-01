using System.Collections.Generic;

namespace Migrations.Web.Models.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
