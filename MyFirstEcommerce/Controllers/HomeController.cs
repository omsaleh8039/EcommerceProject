using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstEcommerce.Data;
using MyFirstEcommerce.Models;
using MyFirstEcommerce.ViewModel;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MyFirstEcommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EcommerceContext _context;

        public HomeController(ILogger<HomeController> logger,EcommerceContext context)
        {
            _logger = logger;
           _context = context;
        }

        public async Task<List<Product>> GetPage(IQueryable<Product> result,int pagenumber)
        {
            const int pagesize= 2;
            decimal rowCount = await _context.products.CountAsync();
            var pageCount = Math.Ceiling(rowCount / pagesize);
            if(pagenumber>pageCount)
            {
                pagenumber = 1;
            }
            pagenumber = pagenumber <= 0 ? 1 : pagenumber;
            int skipCount = (pagenumber - 1) * pagesize;
            var pageData = await result.Skip(skipCount).Take(pagesize).ToListAsync();

            ViewBag.CurrentPage = pagenumber;
            ViewBag.PageCount = pageCount;
            return pageData;
        }
        public IActionResult Index()
        {
            var model = new IndexVM
            {
                Categories = _context.Categories.ToList(),
                Products = _context.products.Take(6).ToList()
            };
            return View(model);
        }

        public async Task<IActionResult> Product(int page=1)//*****
        {
            var products = _context.products;
            var model = await GetPage(products, page);
            return View(model);
        }
        [HttpPost]
        public IActionResult SearchProduct(string NamePro)//*****
        {
            var products = _context.products.Where(p=>p.ProName==NamePro).ToList();
            return View(products);
        }

        public IActionResult ProductCtegory(int id)//*****
        {
            var products = _context.products.Where(c=>c.CatId==id).ToList();
            return View(products);
        }
        public IActionResult Contact()//*****
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact model)//*****
        {
            if(ModelState.IsValid)
            {
                _context.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult ProductDetails(int? id)//*****
        {
            var product = _context.products.Include(x => x.Category).FirstOrDefault(p => p.ProId==id);
            return View(product);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}