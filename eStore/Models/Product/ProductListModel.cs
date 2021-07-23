using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Models
{
    public class ProductListModel
    {
        public List<ProductObject> Products;
        public string ProductName;
        public ProductObject _productObject;
    }
}
