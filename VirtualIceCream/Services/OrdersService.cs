using System;
using System.Collections.Generic;
using VirtualIceCream.Models;
using VirtualIceCream.Repositories;

namespace VirtualIceCream.Services
{
    public class OrdersService
    {
        private readonly OrdersRepository _ordersRepo;
        public OrdersService(OrdersRepository ordersRepo)
        {
            _ordersRepo = ordersRepo;
        }

        internal List<Order> GetOrders()
        {
            List<Order> orders = _ordersRepo.GetOrders();
            return orders;
        }

        internal Order Create(Order newOrder)
        {
            return _ordersRepo.Create(newOrder);
        }

        internal Order GetOne(int id)
        {
            Order order = _ordersRepo.GetOne(id);
            if (order == null)
            {
                throw new Exception ("No order at that Id");
            }
            return order;
        }
    }
}