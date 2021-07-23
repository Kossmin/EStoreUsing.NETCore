using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetailObject> GetOrderDetails(int OrderId);
        OrderDetailObject GetOrderDetail(int OrderId, int productID);
        void Update(OrderDetailObject orderDetail);
        void Delete(int orderid, int productid);
        void Add(OrderDetailObject orderDetail);
        IEnumerable<OrderDetailObject> GetAllOrderDetailObjects();
    }
}
