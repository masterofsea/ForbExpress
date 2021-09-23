using System.Collections.Generic;
using ForbExpress.Models;

namespace ForbExpress.DAL.Repositories.CorrespondenceRepository
{
    public interface ICorrespondenceRepository
    {
        IEnumerable<Correspondence> GetAllCorrespondence();

        Correspondence GetCorrespondenceById(int id);

        IEnumerable<Correspondence> GetCorrespondenceSlice(int skip, int take);

        int GetCorrespondenceCount();
    }
}