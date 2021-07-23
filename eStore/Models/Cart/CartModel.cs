using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Models
{
    public class CartModel
    {
        public List<OrderObject> Orders { get; set; }
        public List<OrderDetailObject> OrderDetails { get; set; }
    }
}
