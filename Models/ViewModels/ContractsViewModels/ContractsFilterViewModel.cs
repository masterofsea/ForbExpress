using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ForbExpress.Models.ViewModels.ContractsViewModels
{
    public class ContractsFilterViewModel
    {
        [Display(Name="Номер договора", Prompt = "Номер договора")]
        public string ContractNumber { get; set; }
        
        [Display(Name="Номер договора почтового обслуживания", Prompt = "Номер договора почтового обслуживания")]
        public string PostalServiceContractNumber { get; set; }
        
        
        [Display(Name="Адрес", Prompt = "Адрес")]
        public string Address { get; set; }
        
        
        [DisplayName("ИНН арендатора")]
        public long Inn { get; set; }
        
        
        [DisplayName("Id партнера")]
        public long PartnerId { get; set; }
        
        
        [DisplayName("Возвратный экземпляр")]
        public bool? ReturnableInstance { get; set; }
        
        
        [DisplayName("ИФНС")]
        public string Ifts { get; set; }
        
        
        [DisplayName("Оплачено")]
        public bool Paid { get; set; }
        
        
        [DisplayName("Дата начала")]
        // ReSharper disable once Mvc.TemplateNotResolved
        [UIHint("text")]
        public DateTime? ConclusionDate { get; set; }
        
        [Display(Name="Имя партнера", Prompt = "Название организации партнера")]
        public string PartnerName { get; set; }
        
        
        [Display(Name="Имя арендатора", Prompt = "Название организации арендатора")]
        public string LesseeName { get; set; }
        
        
        public int? Price1LowerBound { get; set; }
        
        
        public int? Price1UpperBound { get; set; }
    }
}