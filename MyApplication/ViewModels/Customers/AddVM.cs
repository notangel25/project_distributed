using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyApplication.ViewModels.Customers
{
    public class AddVM
    {
        [DisplayName("First Name: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string FirstName { get; set; }

        [DisplayName("User Name: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string UserName { get; set; }

        [DisplayName("Address: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Address { get; set; }

        [DisplayName("Balance: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public double Balance { get; set; }

        [DisplayName("Discount Account: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public bool DiscountAccount { get; set; }
    }
}
