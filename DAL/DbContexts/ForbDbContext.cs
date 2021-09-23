using ForbExpress.Models;
using Microsoft.EntityFrameworkCore;

namespace ForbExpress.DAL.DbContexts
{
    public class ForbDbContext : DbContext
    {
        public ForbDbContext(DbContextOptions<ForbDbContext> options) : base(options)
        {
        }
        
        public DbSet<Partner> Partners { get; set; }
        
        public DbSet<Contract> Contracts { get; set; }
        
        public DbSet<MailContract> MailContracts { get; set; }
    }
}