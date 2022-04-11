using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BitBolt.Models;

namespace BitBolt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BitBolt.Models.Termekek> Termekek { get; set; }

        internal DbSet<Termekek> Kereses(string keresettSzo)
        {
            throw new NotImplementedException();
        }
    }
}