using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ForbExpress.DAL.Repositories.PartnersRepository;
using ForbExpress.Models;

namespace ForbExpress.DAL.Repositories.ContractsRepository
{
    public class TestContractsRepository : IContractsRepository
    {
        private static TestPartnersRepository TestPartnersRepository { get; } = new();
        private static List<Contract> Contracts { get; }
        private static string[] Names { get; } = {"Борис", "Андрей", "Стас", "Игорь", "Егор", "Никита", "Людмила", "Арсений", "Салават"};
        private string[] Cities { get; } = {"Туристская", "Фомичева", "Ленина", "Первомайская"};
        
        private string[] Professions { get; } =
            {"Программист", "Шахтёр", "Пожарник", "Священник", "Менеджер", "Врач", "Учитель"};


        private static int upperId;

        static TestContractsRepository()
        {
            var rnd = new Random();
            Contracts = new List<Contract>();
            var iftss = Enum.GetValues(typeof(Ifts));
            var partnersCount = TestPartnersRepository.GetPartnersCount();

            upperId = 15;
            var leaseStartDate = new DateTime();
            
            for (var i = 1; i <= upperId; ++i)
            {
                var leaseEndDate = leaseStartDate + TimeSpan.FromDays(rnd.Next(1, 10000));
                
                Contracts.Add(new Contract
                {
                    Id = i,
                    Ifts = iftss.GetValue(rnd.Next(0, iftss.Length))?.ToString(),
                    Partner = TestPartnersRepository.GetPartnerById(rnd.Next(1, partnersCount)),
                    Lessee = new Lessee
                    {
                        Name = Names[rnd.Next() % Names.Length]
                    },
                    Penalty = new decimal(rnd.Next()),
                    Price1 = new decimal(rnd.Next()),
                    Price2 = new decimal(rnd.Next()),
                    ContractNumber = $"ПВ-{rnd.Next()}",
                    LeaseEndDate = leaseEndDate,
                    LeaseStartDate = leaseStartDate,
                    LeaseTerm = leaseEndDate.GetTotalMonthsFrom(leaseStartDate),
                    MonthlyActs = false,
                    RegistrationType = RegistrationType.New,
                    IsReturnableCopy = false,
                    
                    MailContract = rnd.Next() % 3 == 0? new MailContract
                    {
                        MailContractNumber = $"ПО-{rnd.Next()}"
                    } : null,

                    ConclusionDate = DateTime.UnixEpoch + TimeSpan.FromDays(i)
                });
            }
        }

        public IEnumerable<Contract> GetAllContracts() => Contracts.Where(c => c.ContractState == ContractState.Active);
        
        public Contract GetContractById(int id) => Contracts.First(i => i.Id == id);

        public IEnumerable<Contract> GetContractsSlice(int skip, int take) => 
            Contracts.Where(c => c.ContractState == ContractState.Active).Skip(skip).Take(take);
        
        public static IEnumerable<Contract> GetContractsSlice(IEnumerable<Contract> contracts, int skip, int take) => 
            contracts.Where(c => c.ContractState == ContractState.Active).Skip(skip).Take(take);
        public IEnumerable<Contract> GetContractSliceWithFilter(int skip, int take)
        {
            return Contracts.Skip(skip).Take(take);
        }

        public void UpdateContract(Contract contract)
        {
            var c = Contracts.First(i => i.Id == contract.Id);

            c.ContractState = contract.ContractState;
            c.ContractNumber = contract.ContractNumber;
            c.Price1 = contract.Price1;
            c.Price2 = contract.Price2;
            c.Ifts = contract.Ifts;
        }

        public int GetContractsCount() => Contracts.Count;
        public bool RemoveContractById(Contract contract)
        {
            return Contracts.Remove(contract);
        }

        public IEnumerable<Contract> GetArchivedContracts()
        {
            return Contracts.Where(c => c.ContractState == ContractState.Disabled);
        }

        public void AddContract(Contract contract)
        {
            contract.Id = Interlocked.Increment(ref upperId);
            
            Contracts.Add(contract);
        }
    }
}