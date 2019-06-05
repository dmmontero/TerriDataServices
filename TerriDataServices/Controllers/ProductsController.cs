namespace TerriDataServices.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;
    using TerriDataServices.Models;

    /// <summary>
    /// Defines the <see cref="ProductsController" />
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProductsController : ApiController
    {
        /// <summary>
        /// Defines the products
        /// </summary>
        internal Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        /// <summary>
        /// The GetAllProducts
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Product}"/></returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        /// <summary>
        /// The GetProduct
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="IHttpActionResult"/></returns>
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
