using ProjectApi.Repositories;
using ProjectApi.CommConstants;
using ProjectApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        public BrandsController()
        {
        }

        [HttpPost]
        public IActionResult CreateBrand(CreateBrandRequest request)
        {
            try
            {
                // Save to database
                BrandsRepository brandsRepo = new BrandsRepository();
                Brand brand = new Brand(request.BrandName, request.PhoneNumber, request.EmailAddress, request.DiscountPercent, request.AllowsReturns, request.RegisteredOn);
                brandsRepo.Save(brand);

                // Generate response
                var response = GenerateResponse(brand);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An error occurred while processing your request.", details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBrand(int id)
        {
            try
            {
                // Retrieve from database
                BrandsRepository repo = new BrandsRepository();
                Brand brand = repo.GetAll(n => n.Id == id).Find(i => i.Id == id);

                if (brand == null)
                {
                    return NotFound();
                }

                // Generate response
                var response = GenerateResponse(brand);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An error occurred while processing your request.", details = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAllBrands()
        {
            try
            {
                BrandsRepository brandsRepo = new BrandsRepository();
                OrdersRepository ordersRepo = new OrdersRepository();
                List<Brand> allBrands = brandsRepo.GetAll(i => true);
                List<Order> allOrders = ordersRepo.GetAll(i => true);

                foreach (var brand in allBrands)
                {
                    int currentCount = 0;
                    foreach (var order in allOrders)
                    {
                        if (order.Brand_ID == brand.Id)
                        {
                            currentCount++;
                        }
                    }

                    brand.TotalOrders = currentCount;
                }

                var response = allBrands.Select(brand => GenerateResponse(brand)).ToList();
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An error occurred while processing your request.", details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBrand(int id, UpdateBrandRequest request)
        {
            try
            {
                BrandsRepository repo = new BrandsRepository();

                // Find the existing brand object
                var existingBrand = repo.GetAll(n => n.Id == id).Find(i => i.Id == id);
                if (existingBrand == null)
                {
                    return NotFound();
                }

                // Update the existing brand object
                existingBrand.BrandName = request.BrandName;
                existingBrand.PhoneNumber = request.PhoneNumber;
                existingBrand.EmailAddress = request.EmailAddress;
                existingBrand.DiscountPercent = request.DiscountPercent;
                existingBrand.AllowsReturns = request.AllowsReturns;
                existingBrand.RegisteredOn = request.RegisteredOn;

                // Save changes to the database
                repo.Save(existingBrand);
                return new JsonResult(Ok());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An error occurred while processing your request.", details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBrand(int id)
        {
            try
            {
                BrandsRepository repo = new BrandsRepository();

                Brand brand = repo.GetAll(n => n.Id == id).Find(i => i.Id == id);

                if (brand == null)
                {
                    return NotFound();
                }

                repo.Delete(brand);
                return new JsonResult(Ok());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An error occurred while processing your request.", details = ex.Message });
            }
        }

        [HttpGet("search/{searchWord}")]
        public IActionResult SearchBrandsByName(string searchWord)
        {
            try
            {
                BrandsRepository repo = new BrandsRepository();
                List<Brand> brandsSearchResult = repo.GetAll(n => n.BrandName.ToUpper().Replace(" ", "").Contains(searchWord.ToUpper()));

                var response = brandsSearchResult.Select(brand => GenerateResponse(brand)).ToList();
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An error occurred while processing your request.", details = ex.Message });
            }
        }

        private BrandResponse GenerateResponse(Brand brand)
        {
            var response = new BrandResponse
            {
                Id = brand.Id,
                BrandName = brand.BrandName,
                PhoneNumber = brand.PhoneNumber,
                EmailAddress = brand.EmailAddress,
                DiscountPercent = brand.DiscountPercent,
                AllowsReturns = brand.AllowsReturns,
                RegisteredOn = brand.RegisteredOn,
            };

            return response;
        }
    }
}