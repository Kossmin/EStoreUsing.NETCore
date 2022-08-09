using BusinessObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class ProductDAO
    {
        DBContext fStoreContext = new DBContext();

        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();



        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }


        public List<ProductObject> GetProducts => fStoreContext.Products.ToList();

        public List<ProductObject> GetProductByName(string name)
        {
            List<ProductObject> products = (from a in fStoreContext.Products.ToList() where a.ProductName.ToUpper().Contains(name.ToUpper()) select a).ToList<ProductObject>();
            return products;
        }

        public List<ProductObject> GetProductByPrice(decimal minPrice, decimal maxPrice)
        {
            List<ProductObject> products = (from a in fStoreContext.Products.ToList() where (a.UnitPrice > minPrice && a.UnitPrice < maxPrice) select a).ToList<ProductObject>();
            return products;
        }

        public List<ProductObject> GetProductByUnitInStock(int quantity)
        {
            List<ProductObject> products = (from a in fStoreContext.Products.ToList() where a.UnitInStock <= quantity select a).ToList<ProductObject>();
            return products;
        }

        public ProductObject GetProductById(int productId)
        {
            ProductObject pro = fStoreContext.Products.SingleOrDefault<ProductObject>(p => p.ProductId == productId);
            return pro;
        }

        public void Add(ProductObject product)
        {
             if (GetProductById(product.ProductId) == null)
                {
                    fStoreContext.Products.AddAsync(product);
                    fStoreContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Try another id");
                }
            
        }

        public void Delete(int productId)
        {
            if (GetProductById(productId) != null)
            {
                fStoreContext.Remove(fStoreContext.Products.FirstOrDefault<ProductObject>(p => p.ProductId == productId));
                fStoreContext.SaveChanges();
            }
            else
            {
                throw new Exception("Invalid ID");
            }
        }

        public void Update(ProductObject product)
        {
            ProductObject pro = GetProductById(product.ProductId);
            if (pro != null)
            {
                pro.CategoryId = product.CategoryId;
                pro.ProductName = product.ProductName;
                pro.UnitInStock = product.UnitInStock;
                pro.UnitPrice = product.UnitPrice;
                pro.Weight = product.Weight;
                pro.CoverImgUrl = product.CoverImgUrl;
                fStoreContext.SaveChanges();
            }
            else
            {
                throw new Exception("Product does not exitst");
            }
        }

    }
}
