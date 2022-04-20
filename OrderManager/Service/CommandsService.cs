using OrderManager.Models;

namespace OrderManager.Service
{
    public class CommandsService : ICommands
    {
        private readonly DataContext _context;
        public CommandsService(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCustomerAsync(Customer entry)
        {
            await _context.Customers.AddAsync(entry);
            return true;
        }

        public async Task<bool> AddOrderAsync(Order entry)
        {
            await _context.Orders.AddAsync(entry);
            return true;
        }

        public async Task<bool> AddProductAsync(Product entry)
        {
            await _context.Products.AddAsync(entry);
            return true;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            try
            {
                var entryExists = await _context.Customers.FindAsync(id);
                if (entryExists != null)
                {
                    _context.Customers.Remove(entryExists);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            try
            {
                var entryExists = await _context.Orders.FindAsync(id);
                if (entryExists != null)
                {
                    _context.Orders.Remove(entryExists);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var entryExists = await _context.Products.FindAsync(id);
                if (entryExists != null)
                {
                    _context.Products.Remove(entryExists);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateCustomerAsync(Customer entry)
        {
            try
            {
                var entryExists = await _context.Customers.FindAsync(entry.CustomerId);

                if (entryExists == null)
                    return false;

                entryExists.CustomerId = entry.CustomerId;
                entryExists.FirstName = entry.FirstName;
                entryExists.LastName = entry.LastName;
                entryExists.Address = entry.Address;
                entryExists.PostalCode = entry.PostalCode;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateOrderAsync(Order entry)
        {
            try
            {
                var entryExists = await _context.Orders.FindAsync(entry.OrderId);

                if (entryExists == null)
                    return false;

                entryExists.CustomerId = entry.CustomerId;
                entryExists.OrderId = entry.OrderId;
                entryExists.Date = entry.Date;
                entryExists.TotalPrice = entry.TotalPrice;
                entryExists.Items = entry.Items;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProductAsync(Product entry)
        {
            try
            {
                var entryExists = await _context.Products.FindAsync(entry.ProductId);

                if (entryExists == null)
                    return false;

                entryExists.ProductId = entry.ProductId;
                entryExists.ProductName = entry.ProductName;
                entryExists.ProductPrice = entry.ProductPrice;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
