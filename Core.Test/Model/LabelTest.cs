using System.Linq;
using Microsoft.EntityFrameworkCore;
using Varasto.Core.Database;
using Varasto.Core.Model;
using Xunit;

namespace Varasto.Core.Test.Model
{
    public class LabelTest
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
                var newLabel = new Label() {Description = "Example"};
                context.Add(newLabel);
                context.SaveChanges();
            }

            // Use a separate instance of the context to verify correct category was saved to database
            using (var context = new DatabaseContext(options))
            {
                Assert.Equal(1, context.Labels.Count());
                Assert.Equal("Example", context.Labels.Single().Description);
            }
        }
    }
}