using BusinessObject;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        DBContext FStoreContext = new DBContext();
        IMemberRepository MemberRepository = new MemberRepository();
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();



        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public void DeleteOrder(int orderId)
        {
            if (GetOrderById(orderId) != null)
            {
                FStoreContext.Orders.Remove(GetOrderById(orderId));
                FStoreContext.SaveChanges();
            }
            else
            {
                throw new Exception("Invalid Id");
            }
        }


        public List<OrderObject> GetOrdersByMemberId(int memberId)
        {
            List<OrderObject> orders = (from a in FStoreContext.Orders.ToList() where a.MemberId == memberId select a).ToList();
            return orders;
        }

        public void InsertOrder(OrderObject order)
        {
            if (DateTime.Compare(order.RequiredDate, order.OrderDate) >= 0 && DateTime.Compare(order.ShippedDate, order.RequiredDate) >= 0)
            {

                if (GetOrderById(order.OrderId) == null && MemberRepository.GetMemberByID(order.MemberId) != null)
                {
                    FStoreContext.Orders.Add(order);
                    FStoreContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Try again");
                }
            }
            else
            {
                throw new Exception("Try again");
            }
        }

        public IEnumerable<OrderObject> GetOrders => FStoreContext.Orders.Include(p => p.OrderDetails).ThenInclude(or=>or.Product).Include(p=>p.Member).OrderBy(p => p.OrderId);

        public void UpdateOrder(OrderObject order)
        {
            OrderObject order1 = GetOrderById(order.OrderId);
            MemberObject member = FStoreContext.Members.SingleOrDefault(p => p.MemberId == order.MemberId);
            try
            {
                if (order1 != null)
                {
                    order1.Freight = order.Freight;
                    order1.MemberId = order.MemberId;
                    order1.OrderDate = order.OrderDate;
                    order1.RequiredDate = order.RequiredDate;
                    order1.ShippedDate = order.ShippedDate;
                    order1.Member = member;

                    FStoreContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public OrderObject GetOrderById(int orderId)
        {
            var orderlist = FStoreContext.Orders.ToList();
            OrderObject order = FStoreContext.Orders.SingleOrDefault(p => p.OrderId == orderId);
            return order;
        }

    }
}
