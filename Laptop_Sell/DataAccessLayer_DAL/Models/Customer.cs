using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Shipping Address")]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
