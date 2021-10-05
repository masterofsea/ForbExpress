using Microsoft.AspNetCore.Mvc.Rendering;

namespace ForbExpress.Models.ViewModels.ContractsViewModels
{
    public class ContractsSortViewModel
    {
        public ContractsSortViewModel(ContractSortState sortOrder)
        {
            //SortChooseList = new SelectList(new [""], )
            Current = sortOrder;
        }
        
        public ContractSortState Current { get; set; }

        public SelectList SortChooseList { get; set; }
    }
}