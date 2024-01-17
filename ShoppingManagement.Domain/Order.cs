using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManagement.Domain
{
    [Table("CleanArchitechture_Orders")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        [NotMapped]
        public string CustomerName { get; set; } = string.Empty;
        public int ProductId { get; set; }
        [NotMapped]
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
