using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Varasto.Core.Database;

namespace Varasto.Core
{
    public class Globals
    {
        public const string SchemaName = "Varasto";

        public static readonly DbContextOptions<DatabaseContext> DbContextInMemoryConfig = 
            new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: Globals.SchemaName)
                .Options;
    }
}