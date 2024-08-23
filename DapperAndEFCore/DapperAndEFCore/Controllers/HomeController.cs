using DapperAndEFCore.Models;
using DapperAndEFCore.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace DapperAndEFCore.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = "StandardUser, Admin")]
        public async Task<IActionResult> Index()
        {
            List<Product> products = (List<Product>)await _unitOfWork.Product.GetAll();
            ProductVM productVM = new()
            {
                Products = products,
            };
            return View(productVM);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product product = await _unitOfWork.Product.GetById(id);
            return View(product);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Product prod)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Product.Update(prod);
                return RedirectToAction("Index");
            }
            return View(prod);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("/Home/DeleteProduct", Name = "deleteProduct")]
        public async Task<IActionResult> DeleteProduct(Product prod)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Product.Delete(prod);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(Product prod)
        {
         
            if (ModelState.IsValid)
            {
                await _unitOfWork.Product.Add(prod);
                return RedirectToAction("Index");
            }
            return View(prod);
        }

        [Authorize(Roles = "StandardUser, Admin")]
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
