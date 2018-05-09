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
            // Run the test against one instance of the context
            using (var context = new DatabaseContext(Globals.DbContextInMemoryConfig))
            {
                var newLabel = new Label() {Description = "Example"};
                context.Add(newLabel);
                context.SaveChanges();
            }

            // Use a separate instance of the context to verify correct category was saved to database
            using (var context = new DatabaseContext(Globals.DbContextInMemoryConfig))
            {
                Assert.Equal(1, context.Labels.Count());
                Assert.Equal("Example", context.Labels.Single().Description);
            }
        }
    }
}