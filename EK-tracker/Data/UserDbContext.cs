using EK_tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace EK_tracker.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<UserRegistrationModel> users { get; set; }
    }
}
