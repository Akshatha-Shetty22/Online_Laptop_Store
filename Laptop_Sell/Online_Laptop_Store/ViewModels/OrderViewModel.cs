using DataAccessLayer_DAL.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Laptop_Store.ViewModels
{
    public class OrderViewModel
    {
        public Laptop LaptopToOrder { get; set; }
        public Customer CustomerDetails { get; set; }
    }
}
