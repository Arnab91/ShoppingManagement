using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManagement.UI.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please Enter Customer Name")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "Please Enter Customer Email Address")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        public string EmailId { get; set; } = string.Empty;
        [Display(Name = "Mobile No")]
        [Required(ErrorMessage = "Please Enter Customer Phone No")]
        public long MobileNo { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;
    }
}
