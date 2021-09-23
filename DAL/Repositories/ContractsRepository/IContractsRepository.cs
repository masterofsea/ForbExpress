using System.Collections.Generic;
using ForbExpress.Models;

namespace ForbExpress.DAL.Repositories.ContractsRepository
{
    public interface IContractsRepository
    {
        IEnumerable<Contract> GetAllContracts();

        Contract GetContractById(int id);

        IEnumerable<Contract> GetContractsSlice(int skip, int take);

        IEnumerable<Contract> GetContractSliceWithFilter(int skip, int take);

        void UpdateContract(Contract contract);

        int GetContractsCount();
        bool RemoveContractById(Contract user);

        IEnumerable<Contract> GetArchivedContracts();

        void AddContract(Contract contract);
    }
}