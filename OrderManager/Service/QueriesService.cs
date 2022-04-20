using OrderManager.Models;

namespace OrderManager.Service
{
    public class QueriesService : IQueries
    {
        private readonly DataContext _context;
        public QueriesService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            try
            {
                return await _context.Customers.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Customer>();
            }
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            try
            {
                return await _context.Orders.Include(o => o.Items).ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Order>();
            }
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Product>();
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return new Customer();
            }
            return customer;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                .Where(o => o.OrderId == id)
                .Include(o => o.Items).FirstOrDefaultAsync();
            if (order == null)
            {
                return new Order();
            }
            return order;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return new Product();
            }
            return product;
        }

        public async Task<List<Order>> GetOrdersByCustomerIdAsync(int id)
        {
            var orders = await _context.Orders
                .Where(k => k.CustomerId == id)
                .Include(o => o.Items).ToListAsync();
            if (orders == null)
            {
                return new List<Order>();
            }
            return orders;
        }
    }
}
