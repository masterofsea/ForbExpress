using System.Collections.Generic;
using ForbExpress.Models;

namespace ForbExpress.DAL.Repositories.PartnersRepository
{
    public interface IPartnersRepository
    {
        IEnumerable<Partner> GetAllPartners();

        Partner GetPartnerById(int id);

        IEnumerable<Partner> GetPartnersSlice(int skip, int take);

        int GetPartnersCount();
    }
}