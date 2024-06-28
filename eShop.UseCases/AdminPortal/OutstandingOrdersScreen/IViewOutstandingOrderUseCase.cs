using eShop.CoreBusiness.Models;

namespace eShop.UseCases.AdminPortal.OutstandingOrdersScreen
{
    public interface IViewOutstandingOrderUseCase
    {
        IEnumerable<Order> Execute();
    }
}