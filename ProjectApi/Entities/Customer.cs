using System.ComponentModel.DataAnnotations;

namespace ProjectApi.Entities
{
    public class Customer : BaseEntity
    {
        public Customer(string firstName, string userName, string address, double balance, bool discountAccount, DateTime registeredOn)
        {
            FirstName = firstName;
            UserName = userName;
            Address = address;
            Balance = balance;
            DiscountAccount = discountAccount;
            RegisteredOn = registeredOn;
        }
        public Customer()
        {
            
        }

        [Display(Name = "First Name")]
        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "User Name")]
        [StringLength(50)]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "Address")]
        [StringLength(100)]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Balance")]
        [Required]
        public double Balance { get; set; }

        [Display(Name = "Discount Account")]
        public bool DiscountAccount { get; set; }

        [Display(Name = "Registered on")]
        [Required]
        public DateTime RegisteredOn { get; set; }

        public int TotalOrders { get; set; }
    }
}
