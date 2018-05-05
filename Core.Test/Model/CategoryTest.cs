using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Varasto.Core.Database;
using Varasto.Core.Model;
using System.Linq;
using Xunit;

namespace Varasto.Core.Test.Model
{
    public class CategoryTest
    {
        [Fact]
        public void AddTest()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            // Run the test against one instance of the context
            using (var context = new DatabaseContext(options))
            {
                var newCategory = new Category() {Description = "Example"};
                context.Add(newCategory);
                context.SaveChanges();
            }

            // Use a separate instance of the context to verify correct category was saved to database
            using (var context = new DatabaseContext(options))
            {
                Assert.Equal(1, context.Categories.Count());
                Assert.Equal("Example", context.Categories.Single().Description);
            }
        }
    }
}