using Microsoft.AspNetCore.Mvc;
using StoreAPI.Application.Interfaces;
using StoreAPI.Domain.Entities;
using static StoreAPI.Application.Interfaces.IProductRepository;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct(Product product)
        {
            return Ok(await _productRepository.CreateNewProduct(product));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int idProduct, Product product)
        {
            return Ok(await _productRepository.UpdateProduct(idProduct, product));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int idProduct)
        {
            return Ok(await _productRepository.DeleteProduct(idProduct));
        }
    }
}
        //[HttpGet]
        //// GET: api/<ProductController>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ProductController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ProductController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
