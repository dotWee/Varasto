using Varasto.Api.Controllers;
using Varasto.Core;
using Varasto.Core.Database;

namespace Varasto.Api.Test.Controllers
{
    public class CategoriesControllerTest
    {
        private readonly CategoriesController _categoriesController;

        public CategoriesControllerTest()
        {
            var databaseContext = new DatabaseContext(Globals.DbContextInMemoryConfig);
            _categoriesController = new CategoriesController(databaseContext);
        }
    }
}