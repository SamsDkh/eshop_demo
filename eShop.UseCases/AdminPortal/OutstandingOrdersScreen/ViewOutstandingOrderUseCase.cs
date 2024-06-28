using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.AdminPortal.OutstandingOrdersScreen
{
    public class ViewOutstandingOrderUseCase : IViewOutstandingOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public ViewOutstandingOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> Execute()
        {
            return _orderRepository.GetOutstandingOrders();
        }
    }
}
