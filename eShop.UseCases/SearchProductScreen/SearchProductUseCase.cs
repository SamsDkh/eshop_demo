using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;


namespace eShop.UseCases.SearchProductScreen
{
    public class SearchProductUseCase : ISearchProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public SearchProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Execute(string filter = null) => _productRepository.GetProducts(filter);
    }
}
