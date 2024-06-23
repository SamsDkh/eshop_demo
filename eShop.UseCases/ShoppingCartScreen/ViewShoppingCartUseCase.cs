using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.UI;
using eShop.UseCases.ShoppingCartScreen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.ShoppingCartScreen
{
    public class ViewShoppingCartUseCase : IViewShoppingCartUseCase
    {
        private readonly IShoppingCart _shoppingCart;

        public ViewShoppingCartUseCase(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public Task<Order> Execute()
        {
            return _shoppingCart.GetOrderAsync();
        }
    }
}
