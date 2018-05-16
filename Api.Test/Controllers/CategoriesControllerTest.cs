using System.Linq;
using Varasto.Api.Controllers;
using Varasto.Core;
using Varasto.Core.Database;
using Varasto.Core.Test.Database;
using Xunit;

namespace Varasto.Api.Test.Controllers
{
    public class CategoriesControllerTest
    {
        private readonly CategoriesController _categoriesController;
        private readonly DatabaseContext _databaseContext;

        public CategoriesControllerTest()
        {
            _databaseContext = new DatabaseContext(Globals.DbContextInMemoryConfig);
            _categoriesController = new CategoriesController(_databaseContext);
            
            if (!_databaseContext.Products.Any())
            {
                DatabaseSeeder.Seed(_databaseContext);
            }
        }
        
        [Fact]
        public void GetCategories_Test()
        {
            var categories = _categoriesController.GetCategories();
            Assert.Equal(_databaseContext.Categories.Count(), categories.Count());
        }
    }
}