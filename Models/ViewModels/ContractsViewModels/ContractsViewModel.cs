using System.Collections.Generic;

namespace ForbExpress.Models.ViewModels.ContractsViewModels
{
    public class ContractsViewModel
    {
        public IEnumerable<Contract> Contracts { get; set; }
        
        public PageViewModel PageViewModel { get; set; }
        
        public ContractsFilterViewModel  ContractsFilterViewModel { get; set; }
    }
}