using OrderManager.Models;

namespace OrderManager.Service.Interfaces
{
    public interface IQueries
    {
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Order> GetOrderByIdAsync(int id);
        Task<Product> GetProductByIdAsync(int id);
        Task<List<Customer>> GetCustomersAsync();
        Task<List<Order>> GetOrdersAsync();
        Task<List<Product>> GetProductsAsync();
        Task<List<Order>> GetOrdersByCustomerIdAsync(int id);
    }
}
