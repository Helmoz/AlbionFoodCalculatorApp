using AlbionFoodCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbionFoodCalculator.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FoodItem> FoodItems { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<FoodItemResource> FoodItemResources { get; set; }
    }
}
