using ForbExpress.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForbExpress.DAL.DbContexts
{
    public class UsersIdentityContext : IdentityDbContext<User>
    {
        public UsersIdentityContext(DbContextOptions<UsersIdentityContext> options) : base(options)
        { }
    }
}