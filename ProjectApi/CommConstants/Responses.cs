using ProjectApi.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectApi.CommConstants
{
    #region Base Response
    public interface IResponse
    {
        bool Successfull { get; }
    }

    public abstract class Response : IResponse
    {
        public Response(bool isSuccessfull)
        {
            Successfull = isSuccessfull;
        }
        public bool Successfull { get; }
    }
    #endregion

    #region Customers Request
    public class CustomerResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string UserName { get; set; }

        public string Address { get; set; }

        public double Balance { get; set; }

        public bool DiscountAccount { get; set; }

        public DateTime RegisteredOn { get; set; }
        public int TotalOrders { get; set; }
    }

    public class BrandResponse
    {
        public int Id { get; set; }

        public string BrandName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public double DiscountPercent { get; set; }

        public bool AllowsReturns { get; set; }

        public DateTime RegisteredOn { get; set; }
    }

    public class OrderResponse
    {
        public int Id { get; set; }

        public string Details { get; set; }

        public double Total { get; set; }

        public bool HasDiscount { get; set; }

        public DateTime PlacedOn { get; set; }

        #region Foreign Keys

        public virtual Customer Customer { get; set; }

        public virtual Brand Brand { get; set; }
        #endregion
    }
    #endregion
}
