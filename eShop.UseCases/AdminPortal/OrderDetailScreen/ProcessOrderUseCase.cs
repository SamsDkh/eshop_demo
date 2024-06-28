﻿using eShop.CoreBusiness.Services.Interfaces;
using eShop.UseCases.AdminPortal.OrderDetailScreen.Interfaces;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.AdminPortal.OrderDetailScreen
{
    public class ProcessOrderUseCase : IProcessOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderService _orderService;

        public ProcessOrderUseCase(IOrderRepository orderRepository, IOrderService orderService)
        {
            _orderRepository = orderRepository;
            _orderService = orderService;
        }

        public bool Execute(int orderId, string adminUserName)
        {
            var order = _orderRepository.GetOrder(orderId);
            order.AdminUser = adminUserName;
            order.DateProcessed = DateTime.Now;

            if (_orderService.ValidateProcessOrder(order))
            {
                _orderRepository.UpdateOrder(order);
                return true;
            }
            return false;
        }
    }
}
