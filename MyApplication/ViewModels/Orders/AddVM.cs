using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ProjectApi.Entities;

namespace MyApplication.ViewModels.Orders
{
    public class AddVM
    {

        public AddVM()
        {
            Customers = new List<Customer>();
            Brands = new List<Brand>();
        }

        [DisplayName("Details: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Details { get; set; }

        [DisplayName("Total (BGN): ")]
        [Required(ErrorMessage = "This field is Required!")]
        public double Total { get; set; }

        [DisplayName("Has discount: ")]
        public bool HasDiscount { get; set; }

        [DisplayName("Customer: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public int Customer_ID { get; set; }

        public List<Customer> Customers { get; set; }

        [DisplayName("Brand: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public int Brand_ID { get; set; }

        public List<Brand> Brands { get; set; }
    }
}
