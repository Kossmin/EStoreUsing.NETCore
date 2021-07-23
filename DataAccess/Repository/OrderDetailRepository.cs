using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void Add(OrderDetailObject orderDetail) => OrderDetailDAO.Instance.Insert(orderDetail);

        public void Delete(int orderid, int productid) => OrderDetailDAO.Instance.DeleteOrderDetail(orderid, productid);

        public IEnumerable<OrderDetailObject> GetAllOrderDetailObjects() => OrderDetailDAO.Instance.GetAllOrderDetailObjects();

        public OrderDetailObject GetOrderDetail(int OrderId, int productID) => OrderDetailDAO.Instance.GetOrderDetail(OrderId, productID);

        public IEnumerable<OrderDetailObject> GetOrderDetails(int OrderId) => OrderDetailDAO.Instance.GetOrderDetails(OrderId);

        public void Update(OrderDetailObject orderDetail) => OrderDetailDAO.Instance.Update(orderDetail);


    }
}
