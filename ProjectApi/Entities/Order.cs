using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectApi.Entities
{
    public class Order : BaseEntity
    {
        public Order(string details, double total, bool hasDiscount, DateTime placedOn, int customer_ID, int brand_ID)
        {
            Details = details;
            Total = total;
            HasDiscount = hasDiscount;
            PlacedOn = placedOn;
            Customer_ID = customer_ID;
            Brand_ID = brand_ID;
        }

        public Order()
        {
            
        }

        public string Details { get; set; }

        public double Total { get; set; }

        public bool HasDiscount { get; set; }

        public DateTime PlacedOn { get; set; }

        #region Foreign Keys
        public int Customer_ID { get; set; }

        public int Brand_ID { get; set; }

        [ForeignKey("Customer_ID")]
        public virtual Customer? Customer { get; set; }

        [ForeignKey("Brand_ID")]
        public virtual Brand? Brand { get; set; }
        #endregion
    }
}
