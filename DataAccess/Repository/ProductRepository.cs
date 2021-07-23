using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void AddNew(ProductObject product) => ProductDAO.Instance.Add(product);


        public void Delete(int productId) => ProductDAO.Instance.Delete(productId);


        public ProductObject GetProductById(int productId) => ProductDAO.Instance.GetProductById(productId);


        public List<ProductObject> GetProductByName(string productname) => ProductDAO.Instance.GetProductByName(productname);


        public List<ProductObject> GetProductByPrice(decimal minimumPrice, decimal maximumPrice) => ProductDAO.Instance.GetProductByPrice(minimumPrice, maximumPrice);


        public IEnumerable<ProductObject> GetProducts() => ProductDAO.Instance.GetProducts;


        public List<ProductObject> GetProductsByUnitInStock(int quantity) => ProductDAO.Instance.GetProductByUnitInStock(quantity);


        public void Update(ProductObject product) => ProductDAO.Instance.Update(product);


    }
}
