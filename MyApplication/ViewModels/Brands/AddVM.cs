using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyApplication.ViewModels.Brands
{
    public class AddVM
    {

        [DisplayName("Brand name: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string BrandName { get; set; }

        [DisplayName("Phone number: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string PhoneNumber { get; set; }

        [DisplayName("Email Address: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string EmailAddress { get; set; }

        [DisplayName("Discount percent: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public double DiscountPercent { get; set; }

        [DisplayName("Allows returns : ")]
        [Required(ErrorMessage = "This field is Required!")]
        public bool AllowsReturns { get; set; }

        [Display(Name = "Registered on")]
        [Required(ErrorMessage = "This field is Required!")]
        public DateTime RegisteredOn { get; set; }
    }
}
