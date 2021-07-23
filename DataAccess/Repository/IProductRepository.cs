using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<ProductObject> GetProducts();
        ProductObject GetProductById(int productId);
        List<ProductObject> GetProductByName(string productname);
        List<ProductObject> GetProductByPrice(decimal minPrice, decimal maxPrice);
        List<ProductObject> GetProductsByUnitInStock(int quantity);
        void AddNew(ProductObject product);
        void Delete(int productId);
        void Update(ProductObject product);
    }
}
