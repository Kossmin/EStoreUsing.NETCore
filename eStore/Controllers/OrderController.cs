using DataAccess.Repository;
using eStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Controllers
{
    public class OrderController : Controller
    {
        IOrderRepository _orderRepository = new OrderRepository();

        public IActionResult Index()
        {
            var orders = _orderRepository.GetOrders().ToList();
            return View(new OrderListModel
            {
                Orders = orders
            });
        }
    }
}
