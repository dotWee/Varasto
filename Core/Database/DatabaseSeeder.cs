using System;
using System.Linq;
using Varasto.Core.Model;

namespace Varasto.Core.Database
{
    public class DatabaseSeeder
    {
        private const String CategoryDescriptionFood = "Food";
        private const String CategoryDescriptionOffice = "Office";
        
        public static async void Seed(DatabaseContext databaseContext)
        {
            SeedCategories(databaseContext);
            await databaseContext.SaveChangesAsync();
            
            SeedProducts(databaseContext);
            await databaseContext.SaveChangesAsync();
        }

        private static void SeedCategories(DatabaseContext databaseContext)
        {
            var categoryFood = new Category() {Description = CategoryDescriptionFood};
            databaseContext.Categories.Add(categoryFood);
            
            var categoryOffice = new Category() { Description = CategoryDescriptionOffice};
            databaseContext.Categories.Add(categoryOffice);
        }

        private static void SeedProducts(DatabaseContext databaseContext)
        {
            var categoryFood =
                databaseContext.Categories.Single(category => category.Description == CategoryDescriptionFood);
            
            var productApple = new Product() { Name = "Apple", CategoryId = categoryFood.CategoryId };
            databaseContext.Products.Add(productApple);
            
            var productSoup = new Product() { Name = "Soup", CategoryId = categoryFood.CategoryId };
            databaseContext.Products.Add(productSoup);
            
            var categoryOffice =
                databaseContext.Categories.Single(category => category.Description == CategoryDescriptionOffice);

            var productPencil = new Product() { Name = "Pencil", CategoryId = categoryOffice.CategoryId };
            databaseContext.Products.Add(productPencil);
        }
    }
}