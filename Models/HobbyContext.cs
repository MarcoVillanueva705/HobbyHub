using Microsoft.EntityFrameworkCore;

namespace HobbyHub.Models
{
    public class HobbyContext : DbContext
    {
       public HobbyContext(DbContextOptions options) : base(options) { }
        public DbSet<Fan> fans {get;set;}
        public DbSet<User> users {get;set;}
        public DbSet<Hobby> hobbies {get;set;} 
    }
}
