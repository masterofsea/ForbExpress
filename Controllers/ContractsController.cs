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
    [Authorize]
    public class ContractsController : Controller
    {
        private IContractsRepository ContractsRepository { get; }

        public ContractsController(IContractsRepository repository)
        {
            ContractsRepository = repository;
        }


        public IActionResult Summary(ContractsFilterBindingModel filter, int pageNumber = 1, int pageCapacity = 15)
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
                    ContractsFilterBindingModel = filter
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

        
        public IActionResult Index()
        {
            return View(new ContractsViewModel
            {
                Contracts = ContractsRepository.GetAllContracts(),
                PageViewModel = null,
                ContractsFilterBindingModel = null
            });
        }
        
        
        
        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var contract = ContractsRepository.GetContractById(id);

            if (!ContractsRepository.RemoveContractById(contract))
                    return NotFound();

            contract.ContractState = ContractState.Disabled;
            ContractsRepository.UpdateContract(contract);
            
            return RedirectToAction(nameof(Summary));
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

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult ContractFilter(ContractsFilterBindingModel filterBindingModel)
        {
            var ifts = Enum.GetValues(typeof(Ifts)).Cast<int>().ToArray();
            ViewBag.SelectItems = new SelectList(ifts, ifts.GetValue(0));
            
            return PartialView(filterBindingModel);
        }
        
        [HttpPost]
        public IActionResult AddContract(Contract contract)
        {
            ContractsRepository.AddContract(contract);

            return RedirectToAction(nameof(Summary));
        }
    }
}