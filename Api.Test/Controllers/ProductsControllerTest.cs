using Varasto.Api.Controllers;
using Varasto.Core;
using Varasto.Core.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Varasto.Core.Database;
using Varasto.Core.Model;
using Varasto.Core.Test.Database;
using Xunit;

namespace Varasto.Api.Test.Controllers
{
    public class ProductsControllerTest
    {
        private readonly ProductsController _productsController;
        private readonly DatabaseContext _databaseContext;

        public ProductsControllerTest()
        {
            _databaseContext = new DatabaseContext(Globals.DbContextInMemoryConfig);
            _productsController = new ProductsController(_databaseContext);
            
            if (!_databaseContext.Products.Any())
            {
                DatabaseSeeder.Seed(_databaseContext);
            }
        }

        [Fact]
        public void GetProducts_Test()
        {
            var products = _productsController.GetProducts();
            Assert.Equal(_databaseContext.Products.Count(), products.Count());
        }
    }
}