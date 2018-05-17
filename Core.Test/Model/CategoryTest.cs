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
            // Run the test against one instance of the context
            using (var context = new DatabaseContext(Globals.DbContextInMemoryConfig))
            {
                var newCategory = new Category() {Name = "Example"};
                context.Add(newCategory);
                context.SaveChanges();
            }

            // Use a separate instance of the context to verify correct category was saved to database
            using (var context = new DatabaseContext(Globals.DbContextInMemoryConfig))
            {
                Assert.Equal(1, context.Categories.Count());
                Assert.Equal("Example", context.Categories.Single().Name);
            }
        }

        [Fact]
        public void RemoveTest()
        {
            var newCategory = new Category() {Name = "Example"};
            int id;
            
            // Run the test against one instance of the context
            using (var context = new DatabaseContext(Globals.DbContextInMemoryConfig))
            {
                context.Add(newCategory);
                context.SaveChanges();
                id = newCategory.CategoryId;
            }
            
            // Use a separate instance of the context to verify correct category was saved to database and deleted after
            using (var context = new DatabaseContext(Globals.DbContextInMemoryConfig))
            {
                Assert.Equal(1, context.Categories.Count());
                Assert.Equal("Example", context.Categories.Single().Name);

                context.Remove(newCategory);
                Assert.Equal(0, context.Categories.Count());
                Assert.Null(context.Categories);
            }
        }
    }
}