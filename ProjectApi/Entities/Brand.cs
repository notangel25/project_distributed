using System.ComponentModel.DataAnnotations;

namespace ProjectApi.Entities
{
    public class Brand: BaseEntity
    {
        public Brand(string brandName, string phoneNumber, string emailAddress, double discountPercent, bool allowsReturns, DateTime registeredOn)
        {
            BrandName = brandName;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            DiscountPercent = discountPercent;
            AllowsReturns = allowsReturns;
            RegisteredOn = registeredOn;
        }

        public Brand()
        {
            
        }

        [Display(Name= "Brand Name")]
        [StringLength(50)]
        [Required]
        public string BrandName { get; set; }

        [Display(Name = "Phone Number")]
        [StringLength(50)]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email adress")]
        [StringLength(100)]
        [Required]
        public string EmailAddress { get; set; }

        [Display(Name = "Discount Percent")]
        [Required]
        public double DiscountPercent { get; set; }

        [Display(Name = "Allows Returns")]
        [Required]
        public bool AllowsReturns { get; set; }

        [Display(Name = "Registered on")]
        [Required]
        public DateTime RegisteredOn { get; set; }

        public int TotalOrders { get; set; }
    }
}
