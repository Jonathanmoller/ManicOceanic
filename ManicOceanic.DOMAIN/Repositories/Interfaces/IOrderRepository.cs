﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Sales;

namespace ManicOceanic.DOMAIN.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        void CreateOrderLine(OrderLine orderLine);
        void DeleteOrder(Order order);

        void UpdateOrder(Order order);
        Task<Order> GetOrderByOrderNumberAsync(int orderNumber);
        Task<int> GenerateOrderNumberAsync();
        EPayment GetPaymentMethod(string paymentOption);
        Task<IEnumerable<Order>> ListOrderAsync(Guid userId);
        Task<IEnumerable<OrderLine>> ListOrderLinesAsync(Guid orderId);
        Task<IEnumerable<Order>> ListOrdersAdmin();

    }
}
