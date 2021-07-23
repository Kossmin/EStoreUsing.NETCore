using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(int orderId) => OrderDAO.Instance.DeleteOrder(orderId);

        public OrderObject GetOrderById(int orderId) => OrderDAO.Instance.GetOrderById(orderId);


        public IEnumerable<OrderObject> GetOrders() => OrderDAO.Instance.GetOrders;


        public List<OrderObject> GetOrdersByMemberId(int memberId) => OrderDAO.Instance.GetOrdersByMemberId(memberId);


        public void InsertOrder(OrderObject order) => OrderDAO.Instance.InsertOrder(order);


        public void UpdateOrder(OrderObject order) => OrderDAO.Instance.UpdateOrder(order);


    }
}
