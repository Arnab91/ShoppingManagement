using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManagement.UI.DTO
{
    public class InventoryDTO
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please Enter Product Name")]
        public string ProductName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Manufacturer")]
        public string Manufacturer { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Quantity")]
        public int Quantity { get; set; }
    }
}
