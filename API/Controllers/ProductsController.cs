using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]

        
/*

                // synchronous request
                // our request is gonna been blocked until the request to sql is finnished
        
        public ActionResult<List<Product>> GetProducts()
        {
                //gets our list of products
                //this is gonna execute a select query on our DB and return the result in the variable 'products'
            
            var products = _context.Products.ToList(); 
            
                return Ok(products);
        }

*/

        [HttpGet("GetAll")]
        // asynchronous request
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            //gets our list of products
            var products = await _context.Products.ToListAsync(); 
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async  Task<ActionResult<Product>> GetProduct(int id) //folosim 'int id' ca sa obtinem un singur produs
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
