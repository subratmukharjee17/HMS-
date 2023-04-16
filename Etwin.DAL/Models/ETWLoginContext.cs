using Etwin.DAL.Models;
using EtwLogin.Repository;
using Microsoft.EntityFrameworkCore;

namespace EtwLogin.Models
{
    public class ETWLoginContext:DbContext

    {
        
        public ETWLoginContext(DbContextOptions<ETWLoginContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Operators>(entity =>
            {
                entity.HasKey(k => k.Username);
            });
        }
        public DbSet<Operators> Operators { get; set; }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<Departments> Departments { get; set; }
    }
}
