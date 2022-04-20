using OrderManager.Models;

namespace OrderManager.Service.Interfaces
{
    public interface ICommands 
    {
        Task<bool> AddCustomerAsync(Customer entry);
        Task<bool> DeleteCustomerAsync(int id);
        Task<bool> UpdateCustomerAsync(Customer entry);
        Task<bool> AddOrderAsync(Order entry);
        Task<bool> DeleteOrderAsync(int id);
        Task<bool> UpdateOrderAsync(Order entry);
        Task<bool> AddProductAsync(Product entry);
        Task<bool> DeleteProductAsync(int id);
        Task<bool> UpdateProductAsync(Product entry);

    }
}
