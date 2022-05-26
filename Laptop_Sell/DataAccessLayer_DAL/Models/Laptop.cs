using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL.Models
{
    public class Laptop
    {
        public int Id { get; set; }
        [Required]
        public string ItemTitle { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Series { get; set; }
        [Required]
        public string ScreenSize { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Ram { get; set; }
        [Required]
        public string CPUSpeed { get; set; }
        [Required]
        public string HardDisk { get; set; }

        public List<Orders> Orders { get; set; }
    }
}
