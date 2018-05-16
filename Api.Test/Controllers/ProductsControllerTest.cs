using Varasto.Api.Controllers;
using Varasto.Core;
using Varasto.Core.Database;

namespace Varasto.Api.Test.Controllers
{
    public class ProductsControllerTest
    {
        private readonly ProductsController _productsController;

        public ProductsControllerTest()
        {
            var databaseContext = new DatabaseContext(Globals.DbContextInMemoryConfig);
            _productsController = new ProductsController(databaseContext);
        }
    }
}