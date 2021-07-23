using BusinessObject;
using DataAccess.Repository;
using eStore.AzureBlob;
using eStore.Models;
using eStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        IProductRepository _productRepository = new ProductRepository();
        IBlobService _blobService;

        public ProductController(IBlobService blobService)
        {
            _blobService = blobService;
        }

        public IActionResult Index()
        {
            var list = _productRepository.GetProducts().ToList();
            return View(new ProductListModel
            {
                Products = list
            });
        }

        public IActionResult Add()
        {
            return View(new ProductDetailModel
            {
                _productObject = new ProductObject()
            });
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ProductObject _productObject, string returnUrl, IFormFile file)
        {
            returnUrl ??= Url.Action("Index");
            if (ModelState.IsValid)
            {
                if (file == null || file.Length < 1) return View();
                _productRepository.AddNew(_productObject);
                var fileName = _productObject.ProductId + Path.GetExtension(file.FileName);
                await _blobService.UploadBlob(fileName, file, "demodb");
            
                _productObject.CoverImgUrl = "https://mystockdb.blob.core.windows.net/demodb/" + fileName;
                _productRepository.Update(_productObject);
                return Redirect(returnUrl);
            }
            
            return View();
        }

        public IActionResult Detail(int id)
        {
            var product = _productRepository.GetProductById(id);

            return View(new ProductDetailModel
            {
                _productObject = product
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductObject _productObject, string returnUrl, IFormFile file)
        {
            returnUrl ??= Url.Action("Index");
            if (ModelState.IsValid)
            {
                if (file == null || file.Length < 1) return RedirectToAction("Detail");
                var fileName = _productObject.ProductId + Path.GetExtension(file.FileName);
                await _blobService.UploadBlob(fileName, file, "demodb");
                _productObject.CoverImgUrl = "https://mystockdb.blob.core.windows.net/demodb/" + fileName; ;
                _productRepository.Update(_productObject);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Detail");
        }

        
        public IActionResult Delete(int id)
        {
            
            var product = _productRepository.GetProductById(id);
            _productRepository.Delete(product.ProductId);
             string[] words = product.CoverImgUrl.Split("/");
            _blobService.DeleteBlob(words.Last(), "demodb");

            return RedirectToAction("Index");
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
                var products = _productRepository.GetProductByName(productname).ToList();
                return View(new ProductListModel
                {
                    Products = products
                });
            }
        }

        /*
                public IActionResult AddBlob()
                {
                    return View();
                }

                [HttpPost]
                public async Task<IActionResult> AddBlob(IFormFile file)
                {
                    if (file == null || file.Length < 1) return View();
                    var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    var res = await _blobService.UploadBlob(fileName, file, "demodb");
                    if (res)
                    {
                        return RedirectToAction("Index");
                    }
                    return View();
                }
          */
    }
}
