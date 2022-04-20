using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManager.Models;

namespace OrderManager.Controllers
{
    [Route("manager/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManagerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Commands
        [HttpPost("customer")]
        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer customer)
        {
            //execute command
            if (!await _unitOfWork.commandsService.AddCustomerAsync(customer))
            {
                return BadRequest("Customer is not added");
            }
            //save
            await _unitOfWork.CompleteAsync();
            return Ok(customer);
        }

        [HttpPost("order")]
        public async Task<ActionResult<List<Order>>> AddOrder(Order order)
        {
            //execute command
            if (!await _unitOfWork.commandsService.AddOrderAsync(order))
            {
                return BadRequest("Order is not added");
            }
            //save
            await _unitOfWork.CompleteAsync();
            return Ok(order);
        }

        [HttpPost("product")]
        public async Task<ActionResult<List<Customer>>> AddProduct(Product product)
        {
            //execute command
            if (!await _unitOfWork.commandsService.AddProductAsync(product))
            {
                return BadRequest("Product is not added");
            }
            //save
            await _unitOfWork.CompleteAsync();
            return Ok(product);
        }

        [HttpPut("customer")]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer updateCustomer)
        {
            if (!await _unitOfWork.commandsService.UpdateCustomerAsync(updateCustomer))
            {
                return BadRequest("Customer is not updated");
            }
            await _unitOfWork.CompleteAsync();
            return Ok(updateCustomer);
        }

        [HttpPut("order")]
        public async Task<ActionResult<List<Order>>> UpdateOrder(Order updateOrder)
        {
            if (!await _unitOfWork.commandsService.UpdateOrderAsync(updateOrder))
            {
                return BadRequest("Customer is not updated");
            }
            await _unitOfWork.CompleteAsync();
            return Ok(updateOrder);
        }

        [HttpPut("product")]
        public async Task<ActionResult<List<Customer>>> UpdateProduct(Product updateproduct)
        {
            if (!await _unitOfWork.commandsService.UpdateProductAsync(updateproduct))
            {
                return BadRequest("Product is not updated");
            }
            await _unitOfWork.CompleteAsync();
            return Ok(updateproduct);
        }

        [HttpDelete("customer/{id}")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            if(! await _unitOfWork.commandsService.DeleteCustomerAsync(id))
            {
                return BadRequest("Customer not Deleted! Check id");
            }
            await _unitOfWork.CompleteAsync();
            return Ok(id);
        }

        [HttpDelete("order/{id}")]
        public async Task<ActionResult<List<Order>>> DeleteOrder(int id)
        {
            if (!await _unitOfWork.commandsService.DeleteOrderAsync(id))
            {
                return BadRequest("Order not Deleted! Check id");
            }
            await _unitOfWork.CompleteAsync();
            return Ok(id);
        }

        [HttpDelete("product/{id}")]
        public async Task<ActionResult<List<Order>>> DeleteProduct(int id)
        {
            if (!await _unitOfWork.commandsService.DeleteProductAsync(id))
            {
                return BadRequest("Product not Deleted! Check id");
            }
            await _unitOfWork.CompleteAsync();
            return Ok(id);
        }
        #endregion

        #region Queries
        [HttpGet("customer")]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            return Ok(await _unitOfWork.queriesService.GetCustomersAsync());
        }

        [HttpGet("order")]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            return Ok(await _unitOfWork.queriesService.GetOrdersAsync());
        }

        [HttpGet("product")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await _unitOfWork.queriesService.GetProductsAsync());
        }

        [HttpGet("customer/{id}")]
        public async Task<ActionResult<List<Customer>>> GetCustomerById(int id)
        {
            return Ok(await _unitOfWork.queriesService.GetCustomerByIdAsync(id));
        }
        
        [HttpGet("order/{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            return Ok(await _unitOfWork.queriesService.GetOrderByIdAsync(id));
        }

        [HttpGet("product/{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return Ok(await _unitOfWork.queriesService.GetProductByIdAsync(id));
        }

        [HttpGet("orders/{customerId}")]
        public async Task<ActionResult<Order>> GetOrdersByCustomerId(int customerId)
        {
            return Ok(await _unitOfWork.queriesService.GetOrdersByCustomerIdAsync(customerId));
        }
        #endregion
    }
}
