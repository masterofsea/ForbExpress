using System;
using System.Linq;
using ForbExpress.DAL.Repositories.ContractsRepository;
using ForbExpress.Models;
using ForbExpress.Models.ViewModels;
using ForbExpress.Models.ViewModels.ContractsViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ForbExpress.Controllers
{
    [AllowAnonymous]
    public class ContractsController : Controller
    {
        private IContractsRepository ContractsRepository { get; }

        public ContractsController(IContractsRepository repository)
        {
            ContractsRepository = repository;
        }


        public IActionResult Summary(ContractsFilterViewModel contractsFilter, int pageNumber = 1, int pageCapacity = 15)
        {
            var filteredContracts = ContractsRepository.GetAllContracts();

            var contractsCount = filteredContracts.Count();

            try
            {
                var pagingModel = new PageViewModel(contractsCount, pageNumber, pageCapacity);

                var contractsAtPage = ContractsRepository.GetContractsSlice((pageNumber - 1) * pageCapacity, pageCapacity);

                return View(new ContractsViewModel
                {
                    Contracts = contractsAtPage,
                    PageViewModel = pagingModel,
                    ContractsFilterViewModel = contractsFilter
                });
            }
            catch (PageModelException)
            {
                return new NotFoundResult();
            }
        }

        public IActionResult Archive()
        {
            return NotFound();
        }

        public IActionResult Index(int page = 1, int pageCapacity = 15, ContractSortState sortOrder = ContractSortState.ConclusionDateDesc,
            ContractsFilterViewModel filter = null)
        {
            var rawContracts = ContractsRepository.GetAllContracts();
            
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Address))
                {
                    rawContracts = rawContracts.Where(c => c.Address == filter.Address);
                }

                if (!string.IsNullOrEmpty(filter.ContractNumber))
                {
                    rawContracts = rawContracts.Where(c => c.ContractNumber == filter.ContractNumber);
                }

                if (!string.IsNullOrEmpty(filter.PartnerName))
                {
                    rawContracts = rawContracts.Where(c => c.Partner.Name == filter.PartnerName);
                }

                if (!string.IsNullOrEmpty(filter.LesseeName))
                {
                    rawContracts = rawContracts.Where(c => c.Lessee.Name == filter.LesseeName);
                }
                
                
                if (!string.IsNullOrEmpty(filter.PostalServiceContractNumber))
                {
                    rawContracts = rawContracts.Where(c => c.MailContract.MailContractNumber == filter.PostalServiceContractNumber);
                }

                if (filter.Paid)
                {
                    rawContracts = rawContracts.Where(c => c.Paid == filter.Paid);
                }
            }

            var sortedContracts = sortOrder switch
            {
                ContractSortState.ConclusionDateDesc => rawContracts.OrderByDescending(c => c.ConclusionDate),
                ContractSortState.ContractNumberAsc => rawContracts.OrderBy(c => c.ContractNumber),
                ContractSortState.LesseeNameAsc => rawContracts.OrderBy(c => c.Lessee.Name),
                ContractSortState.PartnerNameAsc => rawContracts.OrderBy(s => s.Partner.Name),
                _ => rawContracts.OrderBy(c => c.ConclusionDate),
            };


            var count = rawContracts.Count();
            var contracts = sortedContracts.Skip((page - 1) * pageCapacity).Take(pageCapacity).ToList();

            var pageViewModel = new PageViewModel(count, page, pageCapacity);
            return View(new ContractsViewModel
            {
                Contracts = contracts,
                PageViewModel = pageViewModel,
                ContractsFilterViewModel = filter
            });
        }

        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var contract = ContractsRepository.GetContractById(id);

            if (!ContractsRepository.RemoveContractById(contract))
                return NotFound();

            // contract.ContractState = ContractState.Disabled;
            // ContractsRepository.UpdateContract(contract);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Restore(int id)
        {
            var contract = ContractsRepository.GetContractById(id);

            if (!ContractsRepository.RemoveContractById(contract))
                return NotFound();

            contract.ContractState = ContractState.Active;
            ContractsRepository.UpdateContract(contract);

            return RedirectToAction(nameof(Summary));
        }

        [HttpPost]
        public IActionResult Update(Contract contract)
        {
            ContractsRepository.UpdateContract(contract);

            return RedirectToAction(nameof(Summary));
        }

        public IActionResult ContractDetails(int id)
        {
            var contract = ContractsRepository.GetContractById(id);

            return PartialView(contract);
        }

        public IActionResult Create(int id)
        {
            Contract contract = null;
            if (id != 0)
            {
                contract = ContractsRepository.GetContractById(id);
            }
            
            return View(contract);
        }

        public IActionResult ContractFilter(ContractsFilterViewModel contractsFilterViewModel)
        {
            var ifts = Enum.GetValues(typeof(Ifts)).Cast<int>().ToArray();
            ViewBag.SelectItems = new SelectList(ifts, ifts.GetValue(0));

            return PartialView(contractsFilterViewModel);
        }

        [HttpPost]
        public IActionResult AddContract(Contract contract)
        {
            ContractsRepository.AddContract(contract);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult MailContractDetails(int id)
        {
            var rnd = new Random();
            var mailContract = new MailContract
            {
                Id = id,
                Price1 = rnd.Next()
            };
            return PartialView(mailContract);
        }
    }
}