using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        // public Customer Customers { get; set; }
        public int LaptopId { get; set; }
        public Laptop Laptops { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
