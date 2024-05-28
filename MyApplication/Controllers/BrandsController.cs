using MyApplication.Models;
using MyApplication.ViewModels.Brands;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using MyApplication.Services;
using ProjectApi.CommConstants;
using ProjectApi.Entities;


namespace MyApplication.Controllers
{
    public class BrandsController : Controller
    {
        private readonly ILogger<BrandsController> _logger;

        public BrandsController(ILogger<BrandsController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await BrandsService.Instance.GetAllAsync<List<BrandResponse>>();

                if (response == null)
                    return BadRequest("Couldn't load brands. Responce message from the server is null");

                IndexVM vm = new IndexVM();
                var allBrands = response.Select(BrandResponse => new Brand()
                {
                    Id = BrandResponse.Id,
                    BrandName = BrandResponse.BrandName,
                    PhoneNumber = BrandResponse.PhoneNumber,
                    EmailAddress = BrandResponse.EmailAddress,
                    DiscountPercent = BrandResponse.DiscountPercent,
                    AllowsReturns = BrandResponse.AllowsReturns,
                    RegisteredOn = BrandResponse.RegisteredOn,
                }).ToList();

                vm.Brands = allBrands;
                return View(vm);
            }
            catch (HttpRequestException httpRequestException)
            {
                Console.WriteLine(httpRequestException);
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new { error = "External service is unavailable. Please try again later.", details = httpRequestException.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An unexpected error occurred. Please try again later.", details = ex.Message });
            }
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddVM addVM)
        {
            try
            {
                var response = await BrandsService.Instance.PostAsync<BrandResponse>(new CreateBrandRequest(addVM.BrandName, addVM.PhoneNumber, addVM.EmailAddress, addVM.DiscountPercent, addVM.AllowsReturns, DateTime.Now));

                if (response == null)
                    return BadRequest("Couldn't add brand. Responce message from the server is null");    

                return RedirectToAction("Index");
            }
            catch (HttpRequestException httpRequestException)
            {
                Console.WriteLine(httpRequestException);
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new { error = "External service is unavailable. Please try again later.", details = httpRequestException.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An unexpected error occurred. Please try again later.", details = ex.Message });
            }
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await BrandsService.Instance.GetAsync<BrandResponse>(id.ToString());

            Brand brand = new Brand()
            {
                Id = response.Id,
                BrandName = response.BrandName,
                PhoneNumber = response.PhoneNumber,
                EmailAddress = response.EmailAddress,
                DiscountPercent = response.DiscountPercent,
                AllowsReturns = response.AllowsReturns,
                RegisteredOn = response.RegisteredOn
            };
            EditVM vm = new EditVM();
            vm.Brand = brand;

            return View(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditVM vm)
        {
            try
            {
                var response = await BrandsService.Instance.PutAsync<OkResult>(vm.Brand.Id, new UpdateBrandRequest(vm.Brand.Id, vm.Brand.BrandName, vm.Brand.PhoneNumber, vm.Brand.EmailAddress, vm.Brand.DiscountPercent, vm.Brand.AllowsReturns, vm.Brand.RegisteredOn));

                if (response == null)
                    return BadRequest("Couldn't edit brand. Responce message from the server is null");

                return RedirectToAction("Index");
            }
            catch (HttpRequestException httpRequestException)
            {
                Console.WriteLine(httpRequestException);
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new { error = "External service is unavailable. Please try again later.", details = httpRequestException.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An unexpected error occurred. Please try again later.", details = ex.Message });
            }
        }


        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await BrandsService.Instance.DeleteAsync<OkResult>(id.ToString());

                if (response == null)
                    return BadRequest("Couldn't edit brand. Responce message from the server is null");

                return RedirectToAction("Index");
            }
            catch (HttpRequestException httpRequestException)
            {
                Console.WriteLine(httpRequestException);
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new { error = "External service is unavailable. Please try again later.", details = httpRequestException.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An unexpected error occurred. Please try again later.", details = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Search(string brandName)
        {
            try
            {
                var responseList = await BrandsService.Instance.GetSearchAsync<List<BrandResponse>>(brandName);

                if (responseList == null)
                    return BadRequest("Couldn't add Brand. Responce message from the server is null");

                SearchVM vm = new SearchVM();
                var BrandList = responseList.Select(response => new Brand()
                {
                    Id = response.Id,
                    BrandName = response.BrandName,
                    PhoneNumber = response.PhoneNumber,
                    EmailAddress = response.EmailAddress,
                    DiscountPercent = response.DiscountPercent,
                    AllowsReturns = response.AllowsReturns,
                    RegisteredOn = response.RegisteredOn,
                }).ToList();

                vm.Brands = BrandList;
                return View(vm);
            }
            catch (HttpRequestException httpRequestException)
            {
                Console.WriteLine(httpRequestException);
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new { error = "External service is unavailable. Please try again later.", details = httpRequestException.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An unexpected error occurred. Please try again later.", details = ex.Message });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
