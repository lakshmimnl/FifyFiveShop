using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FifyFiveShop.Pages.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SKU { get; set; }

        [Required]
        public double UnitPrice { get; set; }

    }
}
