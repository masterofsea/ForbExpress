using System.Collections.Generic;
using System.Linq;
using ForbExpress.DAL.DbContexts;
using ForbExpress.Models;

namespace ForbExpress.DAL.Repositories.ContractsRepository
{
    public class EfContractsRepository : IContractsRepository
    {
        private ForbDbContext Context { get; }
        public EfContractsRepository(ForbDbContext context)
        {
            Context = context;
        }
        
        public IEnumerable<Contract> GetAllContracts()
        {
            return Context.Contracts.ToList();
        }

        public Contract GetContractById(int id)
        {
            return Context.Contracts.Find(id);
        }

        public IEnumerable<Contract> GetContractsSlice(int skip, int take)
        {
            return Context.Contracts.Skip(skip).Take(take).AsEnumerable();
        }

        public IEnumerable<Contract> GetContractSliceWithFilter(int skip, int take)
        {
            return Context.Contracts.Skip(skip).Take(take).AsEnumerable();
        }

        public void UpdateContract(Contract contract)
        {
            Context.Contracts.Update(contract);
            Context.SaveChanges();
        }

        public int GetContractsCount()
        {
            return Context.Contracts.Count();
        }

        public bool RemoveContractById(Contract user)
        {
            Context.Contracts.Remove(user);
            Context.SaveChanges();
            return true;
        }

        public IEnumerable<Contract> GetArchivedContracts()
        {
            throw new System.NotImplementedException();
        }

        public void AddContract(Contract contract)
        {
            Context.Add(contract);
            Context.SaveChanges();
        }
    }
}