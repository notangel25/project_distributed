namespace ProjectApi.CommConstants
{
    #region Customers Request
    public class CreateCustomerRequest : DataRequest
    {
        public CreateCustomerRequest(string firstName, string userName, string address, double balance, bool discountAccount, DateTime registeredOn) 
            : base()
        {
            FirstName = firstName;
            UserName = userName;
            Address = address;
            Balance = balance;
            DiscountAccount = discountAccount;
            RegisteredOn = registeredOn;
        }
        public string FirstName { get; }
        public string UserName { get; }
        public string Address { get; }
        public double Balance { get; }
        public bool DiscountAccount { get; }
        public DateTime RegisteredOn { get; }
    }

    public class UpdateCustomerRequest : DataRequest
    {
        public UpdateCustomerRequest(int id ,string firstName, string userName, string address, double balance, bool discountAccount, DateTime registeredOn)
            : base()
        {
            Id = id;
            FirstName = firstName;
            UserName = userName;
            Address = address;
            Balance = balance;
            DiscountAccount = discountAccount;
            RegisteredOn = registeredOn;
        }
        public int Id { get; }
        public string FirstName { get; }
        public string UserName { get; }
        public string Address { get; }
        public double Balance { get; }
        public bool DiscountAccount { get; }
        public DateTime RegisteredOn { get; }
    }
    #endregion

    #region Brand Request
    public class CreateBrandRequest : DataRequest
    {
        public CreateBrandRequest(string brandName, string phoneNumber, string emailAddress, double discountPercent, bool allowsReturns, DateTime registeredOn)
            : base()
        {
            BrandName = brandName;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            DiscountPercent = discountPercent;
            AllowsReturns = allowsReturns;
            RegisteredOn = registeredOn;
        }
        public string BrandName { get; }
        public string PhoneNumber { get; }
        public string EmailAddress { get; }
        public double DiscountPercent { get; }
        public bool AllowsReturns { get; }
        public DateTime RegisteredOn { get; }
    }

    public class UpdateBrandRequest : DataRequest
    {
        public UpdateBrandRequest(int id, string brandName, string phoneNumber, string emailAddress, double discountPercent, bool allowsReturns, DateTime registeredOn)
            : base()
        {
            Id = id;
            BrandName = brandName;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            DiscountPercent = discountPercent;
            AllowsReturns = allowsReturns;
            RegisteredOn = registeredOn;
        }
        public int Id { get; }
        public string BrandName { get; }
        public string PhoneNumber { get; }
        public string EmailAddress { get; }
        public double DiscountPercent { get; }
        public bool AllowsReturns { get; }
        public DateTime RegisteredOn { get; }
    }
    #endregion

    #region Order Request
    public class CreateOrderRequest : DataRequest
    {
        public CreateOrderRequest(string details, double total, bool hasDiscount, DateTime placedOn, int customer_ID, int brand_ID)
            : base()
        {
            Details = details;
            Total = total;
            HasDiscount = hasDiscount;
            PlacedOn = placedOn;
            Customer_ID = customer_ID;
            Brand_ID = brand_ID;
        }
        public string Details { get; set; }
        public double Total { get; set; }
        public bool HasDiscount { get; set; }
        public DateTime PlacedOn { get; set; }
        public int Customer_ID { get; set; }
        public int Brand_ID { get; set; }
    }

    public class UpdateOrderRequest : DataRequest
    {
        public UpdateOrderRequest(int id, string details, double total, bool hasDiscount, DateTime placedOn, int customer_ID, int brand_ID)
            : base()
        {
            Id = id;
            Details = details;
            Total = total;
            HasDiscount = hasDiscount;
            PlacedOn = placedOn;
            Customer_ID = customer_ID;
            Brand_ID = brand_ID;
        }

        public int Id { get; set; }
        public string Details { get; set; }
        public double Total { get; set; }
        public bool HasDiscount { get; set; }
        public DateTime PlacedOn { get; set; }
        public int Customer_ID { get; set; }
        public int Brand_ID { get; set; }
    }
    #endregion
}
