using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ForbExpress.Models.ViewModels.ContractsViewModels
{
    public class ContractsFilterBindingModel
    {
        [DisplayName("Номер договора")]
        public string ContractNumber { get; set; }
        
        
        [DisplayName("Номер договора почтового обслуживания")]
        public string PostalServiceContractNumber { get; set; }
        
        
        [DisplayName("Адрес")]
        public string Address { get; set; }
        
        
        [DisplayName("ИНН арендатора")]
        public long? Inn { get; set; }
        
        
        [DisplayName("Id партнера")]
        public long? PartnerId { get; set; }
        
        
        [DisplayName("Возвратный экземпляр")]
        public bool? ReturnableInstance { get; set; }
        
        
        [DisplayName("ИФНС")]
        public string Ifts { get; set; }
        
        
        [DisplayName("Оплачено")]
        public bool? Paid { get; set; }
        
        
        [DisplayName("Дата начала")]
        // ReSharper disable once Mvc.TemplateNotResolved
        [UIHint("text")]
        public DateTime? ConclusionDate { get; set; }
        
        
        public int? Price1LowerBound { get; set; }
        
        
        public int? Price1UpperBound { get; set; }
    }
}