namespace MyApplication.Services
{
    public class BrandsService : BaseService
    {
        public static BrandsService Instance { get; } = new BrandsService();

        public BrandsService() : base("Brands")
        {

        }
    }
}
