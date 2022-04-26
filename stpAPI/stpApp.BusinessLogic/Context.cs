using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace stpApp.BusinessLogic
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Pixel> Pixels { get; set; }
    }


}