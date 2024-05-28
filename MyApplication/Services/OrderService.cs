namespace MyApplication.Services
{
    public class OrderService : BaseService
    {
        public static OrderService Instance { get; } = new OrderService();

        public OrderService() : base("Orders")
        {

        }
    }
}
