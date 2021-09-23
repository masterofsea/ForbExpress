using System.Collections.Generic;
using System.Linq;
using ForbExpress.DAL.DbContexts;
using ForbExpress.Models;

namespace ForbExpress.DAL.Repositories.PartnersRepository
{
    public class EfPartnersRepository : IPartnersRepository
    {
        private ForbDbContext Context { get; }

        public EfPartnersRepository(ForbDbContext context)
        {
            Context = context;
        }
        public IEnumerable<Partner> GetAllPartners()
        {
            return Context.Partners.ToList();
        }

        public Partner GetPartnerById(int id)
        {
           return Context.Partners.Find(id);
        }

        public IEnumerable<Partner> GetPartnersSlice(int skip, int take)
        {
            return Context.Partners.Skip(skip).Take(take);
        }

        public int GetPartnersCount()
        {
            return Context.Partners.Count();
        }
    }
}