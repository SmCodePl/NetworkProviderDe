using Microsoft.AspNetCore.Mvc;
using NetworkProviderDe.Domain.Entities;
using NetworkProviderDe.Domain.Models;
using NetworkProviderDe.Domain.Services;

namespace NetworkProviderDe.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly FiberNetService _fiberNetService;

        public ProductController(ILogger<ProductController> logger, FiberNetService fiberNetService)
        {
            _logger = logger;
            _fiberNetService = fiberNetService;
        }
        /// <summary>
        /// Get All Products 
        /// </summary>
        /// <returns> Product List </returns>
        [HttpGet("AllProducts")]
        public async Task<ActionResult<List<Product>>> GetAllProductsAsync()
        {
            var result = await _fiberNetService.GetAllProductsAsync();

            if (result == null || result.Count == 0)
                return NotFound("No FiberNetPlans found");
            else
                return Ok(result);
        }
        [HttpGet("ProductByName")]
        public async Task<ActionResult<List<Product>>> GetProductsbyNameAsync([FromQuery] string productName)
        {
            var result = await _fiberNetService.GetProductByNameAsync(productName);

            if (result == null || result.Count == 0)
                return NotFound("No products has been found");
            else
                return Ok(result);
        }
        /// <summary>
        /// HttpPost AddProduct 
        /// </summary>
        /// <param name="ProductResult"></param>
        /// <returns>Product</returns>
        [HttpPost("AddProduct")]
        public async Task<ActionResult<Product>> AddProductAsync([FromBody] ProductResult product)
        {
            var result = await _fiberNetService.AddProductAsync(product);

            if (result == null)
                return BadRequest("Product not added");
            else
                return Ok(result);
        }
        /// <summary>
        /// HttpPost UpdateProduct 
        /// </summary>
        /// <param name="ProductResult"></param>
        /// <returns>Bool True or false</returns>
        [HttpPut("UpdateProduct")]
        public async Task<ActionResult<bool>> UpdateProductAsync([FromBody] ProductResult product)
        {
            var result = await _fiberNetService.UpdateProductAsync(product);

            if (!result )
                return NotFound("Product not updated");
            else
                return Ok(result);
        }
    }
}
