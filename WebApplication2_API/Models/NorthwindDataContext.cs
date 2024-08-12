using Microsoft.EntityFrameworkCore;

namespace WebApplication2_API.Models
{
    public class NorthwindDataContext:DbContext
    {
        public NorthwindDataContext(DbContextOptions<NorthwindDataContext> options):base(options)
        {
                
        }

        public DbSet<CategoryModel> Categories { get; set; }
    }
}
