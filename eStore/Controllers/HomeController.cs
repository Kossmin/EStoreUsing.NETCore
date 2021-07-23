using DataAccess.Repository;
using eStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IProductRepository ProductRepository = new ProductRepository();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            var list = ProductRepository.GetProducts().ToList();
            return View(new ProductListModel
            {
                Products=list
            });
        }

        [HttpPost]
        public IActionResult Index(string productname)
        {
            if (productname == null)
            {
                return Index();
            }
            else
            {
                var products = ProductRepository.GetProductByName(productname).ToList();
                return View(new ProductListModel
                {
                    Products = products
                });
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
