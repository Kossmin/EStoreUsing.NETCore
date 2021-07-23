using BusinessObject;
using DataAccess.Repository;
using eStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eStore.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        IOrderRepository _orderRepository = new OrderRepository();
        IOrderDetailRepository _orderDetailRepository = new OrderDetailRepository();
        IProductRepository _productRepository = new ProductRepository();
        IMemberRepository _memberRepository = new MemberRepository();

        

        public IActionResult Index()
        {
            var user = _memberRepository.GetMemberByEmail(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var orderObject = (from a in _orderRepository.GetOrders() where a.MemberId == user.MemberId select a).ToList();
            var orderDetailObject = _orderDetailRepository.GetAllOrderDetailObjects().ToList();
            return View(new CartModel
            {
                Orders = orderObject,
                OrderDetails = orderDetailObject,
            });
        }

        public IActionResult Add(int id)
        {
            var user = _memberRepository.GetMemberByEmail(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var product = _productRepository.GetProductById(id);
            var orderObject = _orderRepository.GetOrders().SingleOrDefault(order => order.isOrdered == false && order.MemberId == user.MemberId);
            if (orderObject!=null)
            {
                var orderDetailObject = _orderDetailRepository.GetOrderDetail(orderObject.OrderId, id);
                if (orderDetailObject == null)
                {
                    var orderdetail = new OrderDetailObject
                    {
                        Quantity = 1,
                        ProductId = product.ProductId,
                        OrderId = _orderRepository.GetOrders().SingleOrDefault(order => order.isOrdered == false && order.MemberId == user.MemberId).OrderId
                    };
                    _orderDetailRepository.Add(orderdetail);
                }
                else
                {
                    orderDetailObject.Quantity = orderDetailObject.Quantity + 1;
                    _orderDetailRepository.Update(orderDetailObject);
                }
            }
            else
            {
                var order = new OrderObject { 
                    isOrdered = false,
                    MemberId =user.MemberId,
                    OrderDate = DateTime.UtcNow,
                    RequiredDate= DateTime.Now,
                    ShippedDate =  DateTime.Now
                };
                _orderRepository.InsertOrder(order);
                var orderDetailObject = _orderDetailRepository.GetOrderDetail(order.OrderId, id);
                if (orderDetailObject == null)
                {
                    var orderdetail = new OrderDetailObject
                    {
                        Quantity = 1,
                        ProductId = product.ProductId,
                        OrderId = _orderRepository.GetOrders().SingleOrDefault(o => o.isOrdered == false && order.MemberId == user.MemberId).OrderId
                    };
                    _orderDetailRepository.Add(orderdetail);
                }
                else
                {
                    orderDetailObject.Quantity = orderDetailObject.Quantity + 1;
                    _orderDetailRepository.Update(orderDetailObject);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            var user = _memberRepository.GetMemberByEmail(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var orderObject = (from a in _orderRepository.GetOrders() where (a.MemberId == user.MemberId && a.isOrdered == false) select a).SingleOrDefault();
            var orderDetailList = _orderDetailRepository.GetOrderDetails(orderObject.OrderId).ToList();
            foreach (var item in orderDetailList)
            {
                item.Product.UnitInStock = item.Product.UnitInStock - item.Quantity;
                _productRepository.Update(item.Product);
            }
            orderObject.isOrdered = true;
            _orderRepository.UpdateOrder(orderObject);
            return RedirectToAction("Index","Home");
        }
    }
}
