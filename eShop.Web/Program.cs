using eShop.CoreBusiness.Services;
using eShop.CoreBusiness.Services.Interfaces;
//using eShop.DataStore.HardCoded;
using eShop.DataStore.SQL.Dapper;
using eShop.DataStore.SQL.Dapper.Helpers;
using eShop.ShoppingCart.LocalStorage;
using eShop.StateStore.DI;
using eShop.UseCases.AdminPortal.OrderDetailScreen;
using eShop.UseCases.AdminPortal.OrderDetailScreen.Interfaces;
using eShop.UseCases.AdminPortal.OutstandingOrdersScreen;
using eShop.UseCases.AdminPortal.ProcessedOrdersScreen;
using eShop.UseCases.OrderConfirmationScreen;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.UseCases.PluginInterfaces.UI;
using eShop.UseCases.SearchProductScreen;
using eShop.UseCases.ShoppingCartScreen;
using eShop.UseCases.ShoppingCartScreen.Interfaces;
using eShop.UseCases.ViewProductScreen;
using eShop.UseCases.ViewProductScreen.Interfaces;
using eShop.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAuthentication("eShop.CookieAuth")
    .AddCookie("eShop.CookieAuth", config =>
    {
        config.Cookie.Name = "eShop.CookieAuth";
        config.LoginPath = "/authenticate";
    });
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>();
builder.Services.AddScoped<IShoppingCartStateStore, ShoppingCartStateStore>();

builder.Services.AddTransient<IDataAccess>(c => new DataAccess(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<ISearchProductUseCase, SearchProductUseCase>();
builder.Services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
builder.Services.AddTransient<IAddProductToCartUseCase, AddProductToCartUseCase>();
builder.Services.AddTransient<IViewShoppingCartUseCase, ViewShoppingCartUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IUpdateQuantityUseCase, UpdateQuantityUseCase>();
builder.Services.AddTransient<IPlaceOrderUseCase, PlaceOrderUseCase>();
builder.Services.AddTransient<IViewOrderConfirmationUseCase, ViewOrderConfirmationUseCase>();
builder.Services.AddTransient<IViewProcessedOrdersUseCase, ViewProcessedOrdersUseCase>();
builder.Services.AddTransient<IViewOutstandingOrderUseCase, ViewOutstandingOrderUseCase>();
builder.Services.AddTransient<IProcessOrderUseCase, ProcessOrderUseCase>();
builder.Services.AddTransient<IViewOrderDetailUseCase, ViewOrderDetailUseCase>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
