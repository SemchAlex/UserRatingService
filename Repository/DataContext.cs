using System.Data.Entity;

namespace UserRatingService.Repository
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; } 

        public DataContext()
            : base("name=DataContext")
        {
        }

        public DataContext(string connString)
            : base(connString)
        {
            
        }
    }
}